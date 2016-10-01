using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace TStateMachineLibrary
{
    public delegate void TChangeStateEvent(TStateMachine Sender, TStateControl FromState, TStateControl ToState);
    public delegate void TStateExceptionEvent(TStateMachine Sender, TStateControl Node);

    [Designer(typeof(TStateMachineDesigner))]
    [ToolboxItem(true)]
    [DesignTimeVisible(true)]
    public class TStateMachine : UserControl //Control
    {
        public int PenWidth = 1;
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var p = new Pen(Brushes.DeepSkyBlue, PenWidth))
            {
                //p.Alignment=PenAlignment.Inset;
                p.Color = System.Drawing.Color.Blue;

                Rectangle rc = new Rectangle(
                    ClientRectangle.Left,
                    ClientRectangle.Top,
                    ClientRectangle.Width - (PenWidth),
                    ClientRectangle.Height - (PenWidth));

                e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.DarkGray), rc);

                //e.Graphics.DrawRectangle(Pens.Blue, rc);
                e.Graphics.DrawRectangle(p, rc);
            }

            if (!IsInDesignMode && Options != TStateMachineOptions.Interactive)
                return;
            base.OnPaint(e);

            if (FDesignMoving == TDesignMove.FirstHandle ||
                FDesignMoving == TDesignMove.LastHandle)
                FConnector.PaintFlipLine();
        }

        protected override Control.ControlCollection CreateControlsInstance()
        {
            return new TStateMachineControlCollection(this);
        }

        public bool Active { get; set; }

        private TStateControl _state;
        public TStateControl State
        {
            get
            {
                if (IsInDesignMode || !(Active))
                {
                    return _state;
                }
                else
                {
                    return _thread.State;
                }
            }
            set
            {
                if (value != null && value.StateMachine != this)
                    throw new Exception("Cannot change to state in another state machine");

                if (Active)
                {
                    Debug.Assert(_thread != null);
                    _thread.State = value;
                }
                else
                {
                    _state = value;
                }
            }
        }

        public TStateMachineOptions Options { get; set; }

        [Category("StateManage")]
        public event EventHandler<ChangeStateEventArgs> OnChangeState;

        [Category("StateManage")]
        public event EventHandler OnException;

        [Category("StateManage")]
        public event EventHandler OnStart;

        [Category("StateManage")]
        public event EventHandler OnStop;

        [Category("StateManage")]
        public event EventHandler OnThreadStart;

        public void ThreadStart()
        {
            if (OnThreadStart != null)
                OnThreadStart(this, EventArgs.Empty);
        }

        [Category("StateManage")]
        public event EventHandler OnThreadStop;

        public void ThreadStop()
        {
            if (OnThreadStop != null)
                OnThreadStop(this, EventArgs.Empty);
        }

        [Category("StateManage")]
        public event EventHandler OnSingleStep;

        public object Align;
        public object Color;
        public object Font;
        private TStateControl FState = null;
        private TStateConnector FConnector = null;

        public TStateConnector Connector
        {
            get { return FConnector; }
        }
        private TDesignMove FDesignMoving;
        private Point[] Lines = new Point[TDesignMove.Destination];
        private TStateThread _thread = null;

        /// <summary>
        /// Is in design mode.
        /// </summary>
        protected bool IsInDesignMode 
        {
            get { return LicenseManager.UsageMode == LicenseUsageMode.Designtime; } 
        }
                

        public TStateMachine()
        {
            //IsInDesignMode =
            FDesignMoving = TDesignMove.None;

            OnSingleStep = null;
            OnThreadStop = null;
            OnThreadStart = null;
            OnStop = null;
            OnStart = null;
            OnException = null;
            OnChangeState = null;

            this.Options = TStateMachineOptions.Interactive;
            Active = false;

            this.ControlRemoved += TStateMachine_ControlRemoved;
        }

        void TStateMachine_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control == this.FState)
                FState = null;

            if (e.Control is TStateControl &&
                ((TStateControl)e.Control).StateMachine == this)
                this.Invalidate();
        }

        // ------------------------------------------------------------------------------
        //@ Destructor  Destroy()
        ~TStateMachine()
        {
        }
        // ------------------------------------------------------------------------------
        public void DestroyThread()
        {
            if (_thread == null)
                return;

            _thread.Terminate();
            /*
             if (GetCurrentThreadID = MainThreadID) then
      _thread.WaitFor;
    FreeAndNil(_thread);
             */
            //if(Thread.CurrentThread.ManagedThreadId)
        }

        // ------------------------------------------------------------------------------
        public void CreateThread()
        {
            DestroyThread();

            Debug.Assert(_thread == null);

            if (_thread == null)
            {
                _thread = new TStateThread(this);
                _thread.Start();
            }
        }

        // ------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            if (Active)
            {
                Active = false;
                Execute();
            }
            base.OnLoad(e);
        }

        // ------------------------------------------------------------------------------
        public void Execute(bool wait = false)
        {
            if (State == null)
                throw new ArgumentNullException("No initial state specified");

            if (Active)
                throw new Exception("Already executing");

            TStateControl initialState = State;
            State = null;

            CreateThread();
            Active = true;

            State = initialState;

            if (!wait)
                return;

            while (Active)
                Application.DoEvents();
        }

        // ------------------------------------------------------------------------------
        public void Stop()
        {
            if (!Active)
                return;

            State = null;
            Active = false;
        }



        // ------------------------------------------------------------------------------
        public bool HandlesTransitionEvent()
        {
            return OnChangeState != null;
        }

        // ------------------------------------------------------------------------------
        public void DoTransition()
        {
            if (_thread.OldState != null)
                _thread.OldState.Invalidate();

            if (_thread.NewState != null)
                _thread.NewState.Invalidate();

            if (OnChangeState == null)
                return;

            try
            {
                OnChangeState(this, new ChangeStateEventArgs(_thread.OldState, _thread.NewState));
            }
            catch (Exception)
            {
                DoException(null);
                throw;
            }
        }

        // ------------------------------------------------------------------------------
        public void DoException(TStateControl Node)
        {
            if (OnException != null)
                OnException(this, EventArgs.Empty);
        }

        // ------------------------------------------------------------------------------
        public void DoStart()
        {
            if (OnStart == null)
                return;
            try
            {
                OnStart(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                DoException(null);
                throw;
            }
        }

        // ------------------------------------------------------------------------------
        public void DoStop()
        {
            if (OnStop == null)
                return;
            try
            {
                OnStop(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                DoException(null);
                throw;
            }
        }

        // ------------------------------------------------------------------------------
        public void DoOnSingleStep()
        {
            if (OnSingleStep == null)
                return;
            try
            {
                OnSingleStep(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                DoException(null);
                throw;
            }
        }

        // ------------------------------------------------------------------------------
        public bool CMDesignHitTest_TestConnector(TStateConnector Connector, Point p)
        {
            bool result = false;
            return result;
        }

        // ------------------------------------------------------------------------------
        //public void CMDesignHitTest(ref TWMMouse Msg)
        //{
        //}

        // ------------------------------------------------------------------------------
        public void MouseDown(MouseButtons Button, Keys Shift, int X, int Y)
        {
        }

        // Function to determine on which side of the vector c1->c2 the point a lies
        public int MouseMove_cross(Point a, Rectangle c)
        {
            int result = 0;
            return result;
        }

        public TStatePath MouseMove_NewState(TStatePath OldState, TDesignMove Handle, Rectangle Diagonal, Point OldHandle, Point NewHandle)
        {
            TStatePath result = TStatePath.Auto;
            return result;
        }

        // ------------------------------------------------------------------------------
        public void MouseMove(Keys Shift, int X, int Y)
        {
        }

        // ------------------------------------------------------------------------------
        public void MouseUp(MouseButtons Button, Keys Shift, int X, int Y)
        {
        }

    }// end TStateMachine

    public class ChangeStateEventArgs : EventArgs
    {
        public TStateControl FromState { get; set; }
        public TStateControl ToState { get; set; }

        public ChangeStateEventArgs(TStateControl fromState, TStateControl toState)
        {
            FromState = fromState;
            ToState = toState;
        }
    }
}

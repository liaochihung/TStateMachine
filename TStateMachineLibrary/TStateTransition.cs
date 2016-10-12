using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using Plasmoid.Extensions;

namespace TStateMachineLibrary
{
    /// <summary>
    /// TStateTransition
    /// </summary>
    [ToolboxItem(true)]
    public class TStateTransition : TStateControl
    {
        public TStateTransition()
        {
            _toConnector = AddConnector(TStatePathOwner.OwnedBySource);
            _fromConnector = AddConnector(TStatePathOwner.OwnedByDestination);
            SetBounds(0, 0, 41, 41);
        }

        public TStateControl FromState
        {
            get { return _fromState; }
            set { _fromState = value; }
        }
        public TStateControl ToState
        {
            get { return _toState; }
            set { _toState = value; }
        }

        public event EventHandler OnTransition;

        private TStateControl _fromState = null;
        private TStateControl _toState = null;
        private event EventHandler FOnTransition = null;
        private TStateConnector _toConnector = null;
        private TStateConnector _fromConnector = null;
        // ------------------------------------------------------------------------------
        // TStateTransition
        // ------------------------------------------------------------------------------
        //Constructor  Create( AOwner)
        //public TStateTransition(Component AOwner):base(AOwner)
        //{
        //    _toConnector = AddConnector(TStatePathOwner.OwnedBySource);
        //    _fromConnector = AddConnector(TStatePathOwner.OwnedByDestination);
        //    SetBounds(0, 0, 41, 41);
        //}
        // ------------------------------------------------------------------------------
        //@ Destructor  Destroy()
        ~TStateTransition()
        {
            _fromState = null;
            _fromConnector = null;
            _toState = null;
            _toConnector = null;
        }
        // ------------------------------------------------------------------------------
        public void SetParent(Control AParent)
        {
            base.SetParent(AParent);
        }

        // ------------------------------------------------------------------------------
        public void SetBounds(int ALeft, int ATop, int AWidth, int AHeight)
        {
            base.SetBounds(ALeft, ATop, AWidth, AHeight);
            _toConnector.Offset = 0;
            _fromConnector.Offset = 0;
        }

        // ------------------------------------------------------------------------------
        public void Notification(Component AComponent, TOperation Operation)
        {
        }

        // ------------------------------------------------------------------------------
        protected override void PaintConnector()
        {
            base.PaintConnector();
            StateMachine.PenWidth = 1;
            _fromConnector.Paint();
            _toConnector.Paint();
        }

        // ------------------------------------------------------------------------------
        public TStateConnector HitTest(Point Mouse)
        {
            if (_toConnector.HitTest(Mouse))
            {
                return _toConnector;
            }
            else
            {
                if (_fromConnector.HitTest(Mouse))
                    return _fromConnector;
            }
            return null;
        }

        // ------------------------------------------------------------------------------
        public void PrepareCanvas(TVisualElement Element)
        {
            /*
               case (Element) of
    veText:
      if not((Assigned(FFromState)) and (Assigned(FToState)) or
        (csDesigning in ComponentState)) then
        Canvas.Font.Color := clGray;

             */
            base.PrepareCanvas(Element);
            if (Element == TVisualElement.Text)
            {
                if (_fromState != null && _toState != null || IsInDesignMode)
                {
                    Canvas.FontColor = Color.Gray;
                }
            }
        }

        // ------------------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            int RoundSize = 16;
            if (Height < RoundSize)
                RoundSize = Height;
            if (Width < RoundSize)
                RoundSize = Width;

            Rectangle rc = this.ClientRectangle;

            Graphics g = e.Graphics;
            PrepareCanvas(TVisualElement.Shadow);
            g.DrawRoundedRectangle(Pens.Brown, rc.Top, rc.Left, rc.Width - 1, rc.Height - 1, 10);
            g.FillRoundedRectangle(
                new SolidBrush(Color.FromArgb(100, 70, 130, 180)),
                rc.Top, rc.Left, rc.Width - 1, rc.Height - 1, 10);

            DrawName(g);
        }

        protected override void DrawName(Graphics g)
        {
            PrepareCanvas(TVisualElement.Text);
            DrawLetter(g, Text);
        }

        public bool HandlesEnterEvent()
        {
            bool result = false;
            return result;
        }

        public void DoEnter()
        {
            base.DoEnter();
        }

        public TStateControl __Default()
        {
            TStateControl result = null;
            return result;
        }

    }//end TStateTransition
}
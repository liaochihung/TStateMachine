using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TStateMachineLibrary
{
    public delegate void TBooleanStateEvent(TStateBoolean sender, bool Result);

    [ToolboxItem(true)]
    public class TStateBoolean : TStateNodeBase
    {
        public TStateBoolean()
        {
        }
        public TBooleanStateEvent OnEnterState
        {
            get
            {
                return FOnEnterState;
            }
            set
            {
                FOnEnterState = value;
            }
        }
        public object OnExitState;
        public TStateControl TrueState
        {
            get
            {
                return _fTrueState;
            }
            set
            {
                SetTrueState(value);
            }
        }

        public TStateControl FalseState
        {
            get
            {
                return FFalseState;
            }
            set
            {
                SetFalseState(value);
            }
        }

        public bool DefaultState
        {
            get
            {
                return FDefault;
            }
            set
            {
                SetDefault(value);
            }
        }
        private TBooleanStateEvent FOnEnterState = null;
        private TStateControl _fTrueState = null;
        private TStateControl FFalseState = null;
        private TStateConnector FTrueConnector = null;
        private TStateConnector FFalseConnector = null;
        private bool FResult = false;
        private bool FDefault = true;
        // ------------------------------------------------------------------------------
        // TStateBoolean
        // ------------------------------------------------------------------------------
        //Constructor  Create( AOwner)
        //public TStateBoolean(Component AOwner)
        //{
        //}
        // ------------------------------------------------------------------------------
        //@ Destructor  Destroy()
        ~TStateBoolean()
        {
        }
        // ------------------------------------------------------------------------------
        public void SetBounds(int ALeft, int ATop, int AWidth, int AHeight)
        {
        }

        // ------------------------------------------------------------------------------
        public void Notification(Component AComponent, TOperation Operation)
        {
        }

        // ------------------------------------------------------------------------------
        public void PaintConnector()
        {
        }

        // ------------------------------------------------------------------------------
        public TStateConnector HitTest(Point Mouse)
        {
            TStateConnector result = null;
            return result;
        }

        // ------------------------------------------------------------------------------

        // ------------------------------------------------------------------------------
        public override void DoPaint(Graphics g)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddPolygon(new Point[]
            {
                new Point(0, Height/2), 
                new Point(Width/2,0), 
                new Point(Width-1,Height/2),
                new Point(Width/2,Height-1) 
            });

            PrepareCanvas(TVisualElement.Shadow);
            g.DrawPath(Canvas.MyPen, gp);

            var rgn = new Region(gp);
            g.FillRegion(Canvas.Brush, rgn);

            var rc =
                new Rectangle(
                    Width / 7,
                    Height / 7,
                    Width - (Width / 7) * 2,
                    Height - (Height / 7) * 2);

            // draw rectangle
            PrepareCanvas(TVisualElement.Panel);
            g.FillRectangle(Canvas.Brush, rc);

            PrepareCanvas(TVisualElement.Frame);
            g.DrawRectangle(Canvas.MyPen, rc);

            // draw name
            PrepareCanvas(TVisualElement.Text);
            DrawLetter(g, Text);
        }

        protected override void PrepareCanvas(TVisualElement element)
        {
            base.PrepareCanvas(element);

            switch (element)
            {
                case TVisualElement.Text:
                    // todo : add condition below 
                    //if not(Assigned(OnEnterState) or (csDesigning in ComponentState)) then
                    if (IsInDesignMode)
                        Canvas.FontColor = Color.Gray;
                    break;
                case TVisualElement.Shadow:
                    Canvas.MyPen.Color = Color.Black;
                    break;
            }
        }


        // ------------------------------------------------------------------------------
        public void SetTrueState(TStateControl Value)
        {
            _fTrueState = Value;
            FTrueConnector.Destination = Value;

            // True and False should not be the same
            if (Value != null && FalseState == Value)
                FFalseState = null;

            if (StateMachine != null)
                StateMachine.Invalidate();
        }

        // ------------------------------------------------------------------------------
        public void SetFalseState(TStateControl Value)
        {
            FFalseState = Value;
            FFalseConnector.Destination = Value;

            // True and False should not be the same
            if (Value != null && _fTrueState == Value)
                _fTrueState = null;

            if (StateMachine != null)
                StateMachine.Invalidate();
        }

        // ------------------------------------------------------------------------------
        public void SetDefault(bool Value)
        {
            if (Value != FDefault)
            {
                FDefault = Value;
                StateMachine.Invalidate();
            }
        }

        // ------------------------------------------------------------------------------
        public bool HandlesEnterEvent()
        {
            bool result = false;
            return result;
        }

        // ------------------------------------------------------------------------------
        public void DoEnter()
        {
            base.DoEnter();

            FResult = DefaultState;

            if (FOnEnterState == null)
                return;

            try
            {
                FOnEnterState(this, FResult);
            }
            catch (Exception)
            {
                DoException();
                throw;
            }

            if (StateMachine.State == this)
            {
                if (FResult)
                {
                    if (_fTrueState != null)
                        StateMachine.State = _fTrueState;
                }
                else
                {
                    if (FFalseState != null)
                        StateMachine.State = FFalseState;
                }
            }
        }

        // ------------------------------------------------------------------------------
        public override TStateControl Default()
        {
            return DefaultState ? TrueState : FalseState;
        }

        protected new void DrawLetter(Graphics g, string letter)
        { var rc = new Rectangle(
                    Width / 7,
                    Height / 7,
                    Width - (Width / 7) * 2,
                    Height - (Height / 7) * 2);

            float width = ((float)this.ClientRectangle.Width);
            float height = ((float)this.ClientRectangle.Width);

            float emSize = height;
            var font = new Font(FontFamily.GenericSansSerif, emSize, Canvas.FontStyle);
            font = FindBestFitFont(g, letter, font, this.ClientRectangle.Size);

            SizeF size = g.MeasureString(letter, font);

            StringFormat sf = new StringFormat();
            //sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            //g.DrawString(letter, font, new SolidBrush(Color.Black), (width - size.Width) / 2, 0);
            //g.DrawString(letter, font, new SolidBrush(Canvas.FontColor), ClientRectangle, sf);
            g.DrawString(letter, font, new SolidBrush(Canvas.FontColor), rc, sf);
            font.Dispose();
        }
    }//end TStateBoolean
}
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
            get { return FOnEnterState; }
            set { FOnEnterState = value; }
        }
        public object OnExitState;
        public TStateControl TrueState
        {
            get { return _trueState; }
            set
            {
                _trueState = value;
                _trueConnector.Destination = value;

                // True and False should not be the same
                if (value != null && FalseState == value)
                    _falseState = null;

                if (StateMachine != null)
                    StateMachine.Invalidate();
            }
        }

        public TStateControl FalseState
        {
            get { return _falseState; }
            set
            {
                _falseState = value;
                _falseConnector.Destination = value;

                // True and False should not be the same
                if (value != null && _trueState == value)
                    _trueState = null;

                if (StateMachine != null)
                    StateMachine.Invalidate();
            }
        }

        public bool DefaultState
        {
            get { return _default; }
            set
            {
                if (value != _default)
                {
                    _default = value;
                    StateMachine.Invalidate();
                }
            }
        }
        private TBooleanStateEvent FOnEnterState = null;
        private TStateControl _trueState = null;
        private TStateControl _falseState = null;
        private TStateConnector _trueConnector = null;
        private TStateConnector _falseConnector = null;
        private bool _result = false;
        private bool _default = true;
        
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
        public TStateConnector HitTest(Point Mouse)
        {
            TStateConnector result = null;
            return result;
        }

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
                    if (IsInDesignMode || (OnEnterState==null))
                        Canvas.FontColor = Color.Gray;
                    break;
                case TVisualElement.Shadow:
                    Canvas.MyPen.Color = Color.Black;
                    break;
            }
        }

        public bool HandlesEnterEvent()
        {
            bool result = false;
            return result;
        }

        public void DoEnter()
        {
            base.DoEnter();

            _result = DefaultState;

            if (FOnEnterState == null)
                return;

            try
            {
                FOnEnterState(this, _result);
            }
            catch (Exception)
            {
                DoException();
                throw;
            }

            if (StateMachine.State != this) 
                return;
            if (_result)
            {
                if (_trueState != null)
                    StateMachine.State = _trueState;
            }
            else
            {
                if (_falseState != null)
                    StateMachine.State = _falseState;
            }
        }

        // ------------------------------------------------------------------------------
        public override TStateControl Default()
        {
            return DefaultState ? TrueState : FalseState;
        }

        protected new void DrawLetter(Graphics g, string letter)
        {
            var rc = new Rectangle(
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
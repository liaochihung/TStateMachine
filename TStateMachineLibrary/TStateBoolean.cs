using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TStateMachineLibrary
{
    [ToolboxItem(true)]
    [DefaultEvent("OnEnterState")]
    public class TStateBoolean : TStateNodeBase
    {
        public TStateBoolean()
        {
            _default = true;

            _trueConnector = AddConnector(TStatePathOwner.OwnedBySource);
            _falseConnector = AddConnector(TStatePathOwner.OwnedBySource);
        }

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

        private TStateControl _trueState = null;
        private TStateControl _falseState = null;
        private TStateConnector _trueConnector = null;
        private TStateConnector _falseConnector = null;

        private bool _result = false;
        private bool _default;

        ~TStateBoolean()
        {
        }
        // ------------------------------------------------------------------------------
        //public void SetBounds(int ALeft, int ATop, int AWidth, int AHeight)
        //{
        //}


        // ------------------------------------------------------------------------------
        public TStateConnector HitTest(Point Mouse)
        {
            TStateConnector result = null;
            return result;
        }

        [Category("StateManage")]
        new public event EventHandler<BooleanStateArgs> OnEnterState;

        protected override void PaintConnector()
        {
            base.PaintConnector();

            if (DefaultState)
            {
                Canvas.MyPen.Width = 2;
            }
            else
            {
                Canvas.MyPen.Width = 1;
            }

            _trueConnector.Paint(Color.Green);

            if (!DefaultState)
            {
                Canvas.MyPen.Width = 2;
            }
            else
            {
                Canvas.MyPen.Width = 1;
            }
            _falseConnector.Paint(Color.Red);
        }

        public override void DoPaint(Graphics g)
        {
            var gp = new GraphicsPath();
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
                    if (IsInDesignMode || (OnEnterState == null))
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

        public override void DoEnter()
        {
            _result = DefaultState;

            if (OnEnterState == null)
                return;

            var res = new BooleanStateArgs();
            try
            {
                OnEnterState(this, res);
            }
            catch (Exception)
            {
                DoException();
                throw;
            }

            if (StateMachine.State != this)
                return;

            if (res.Result)
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

            //float width = ((float)this.ClientRectangle.Width);
            //float height = ((float)this.ClientRectangle.Width);

            //float emSize = height;
            float emSize = 9;
            var font = new Font(FontFamily.GenericMonospace, emSize, Canvas.FontStyle);
            //font = FindBestFitFont(g, letter, font, this.ClientRectangle.Size);

            var size = g.MeasureString(letter, font);

            var sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            //g.DrawString(letter, font, new SolidBrush(Color.Black), (width - size.Width) / 2, 0);
            //g.DrawString(letter, font, new SolidBrush(Canvas.FontColor), ClientRectangle, sf);
            g.DrawString(letter, font, new SolidBrush(Color.Black), rc, sf);
            font.Dispose();
        }
    }//end TStateBoolean

    public class BooleanStateArgs : EventArgs
    {
        public bool Result { get; set; }
    }
}
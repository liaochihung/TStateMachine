using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Plasmoid.Extensions;

namespace TStateMachineLibrary
{
    [ToolboxItem(true)]
    [DefaultEvent("")]
    public class TStateLink : TStateControl
    {
        public TStateLink()
        {
            _direction = TLinkDirection.Outgoing;
            _connector = AddConnector(TStatePathOwner.OwnedBySource);
            SetBounds(0, 0, 41, 41);
        }

        public TStateControl Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                //if (value != null)// && (value.StateMachine != CheckStateMachine))
                //    throw new Exception("Cannot connect to node in other state machine");

                if (value == this)
                    throw new Exception("Cannot connect link to self");

                _destination = value;

                if (value != null)
                {
                    if (value is TStateLink)
                    {
                        _direction = TLinkDirection.Outgoing;
                        if (_connector != null)
                            _connector.Destination = null;
                    }
                    else
                    {
                        _direction = TLinkDirection.Incoming;
                        if (_connector != null)
                            _connector.Destination = value;
                    }
                    _connector.Paint();
                }

                if (StateMachine != null)
                    StateMachine.Invalidate();
            }
        }
        public TLinkDirection Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                if (value == _direction)
                    return;

                _direction = value;
                Destination = null;

                if (StateMachine != null)
                    StateMachine.Invalidate();
            }
        }
        private TStateControl _destination = null;
        private TStateConnector _connector = null;
        private TLinkDirection _direction;

        ~TStateLink()
        {
            _connector = null;
            _destination = null;
            Dispose();
        }


        // ------------------------------------------------------------------------------
        public void SetBounds(int ALeft, int ATop, int AWidth, int AHeight)
        {
            if (AWidth != Width)
                AHeight = AWidth;
            else if (AHeight != Height)
                AWidth = AHeight;

            base.SetBounds(ALeft, ATop, AWidth, AHeight);
            _connector.Offset = 0;
        }



        // ------------------------------------------------------------------------------
        protected override void PaintConnector()
        {
            base.PaintConnector();

            _connector.Paint();
        }


        // ------------------------------------------------------------------------------
        public void PrepareCanvas(TVisualElement Element)
        {
            base.PrepareCanvas(Element);

            if (Element == TVisualElement.Text)
            {
                if (_destination == null || IsInDesignMode)
                {
                    Canvas.FontColor = Color.Gray;
                }
            }
        }

        // ------------------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            var rc = this.ClientRectangle;
            var g = e.Graphics;

            PrepareCanvas(TVisualElement.Shadow);
            g.FillEllipse(
                Canvas.Brush,
                TStateConst.ShadowHeight,
                TStateConst.ShadowHeight,
                rc.Right - 2,
                rc.Height - 2);

            // draw rectangle
            PrepareCanvas(TVisualElement.Panel);
            rc.Offset(-TStateConst.ShadowHeight * 2, -TStateConst.ShadowHeight * 2);
            g.FillEllipse(Canvas.Brush, rc);

            PrepareCanvas(TVisualElement.Frame);
            g.DrawEllipse(Canvas.MyPen,
                0,
                0,
                rc.Width,
                rc.Height);

            // draw name
            PrepareCanvas(TVisualElement.Text);
            DrawLetter(g, Text);

            PaintConnector();
        }

        public override TStateControl Default()
        {
            return Destination;
        }
        
        //public override void SetParent(Control aParent)
        //{
        //    if (aParent != null && !(aParent is TStateMachine))
        //        throw new Exception(this.Name + " must have a TStateMachine as parent");

        //    StateMachine = aParent as TStateMachine;
        //}
    }//end TStateLink
}
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Plasmoid.Extensions;

namespace TStateMachineLibrary
{
    [ToolboxItem(true)]
    public class TStateLink : TStateControl
    {
        public TStateLink()
        {
            FDirection = TLinkDirection.Outgoing;
            FConnector = AddConnector(TStatePathOwner.OwnedBySource);
            SetBounds(0, 0, 41, 41);
        }

        public TStateControl Destination
        {
            get
            {
                return FDestination;
            }
            set
            {
                SetDestination(value);
            }
        }
        public TLinkDirection Direction
        {
            get
            {
                return FDirection;
            }
            set
            {
                SetDirection(value);
            }
        }
        private TStateControl FDestination = null;
        private TStateConnector FConnector = null;
        private TLinkDirection FDirection;
        // ------------------------------------------------------------------------------
        // TStateLink
        // ------------------------------------------------------------------------------
        //Constructor  Create( AOwner)
        //public TStateLink(Component AOwner)
        //    : base(AOwner)
        //{
        //    FDirection = TLinkDirection.Outgoing;
        //    FConnector = AddConnector(TStatePathOwner.OwnedBySource);
        //    SetBounds(0, 0, 41, 41);
        //}

        // ------------------------------------------------------------------------------
        //@ Destructor  Destroy()
        ~TStateLink()
        {
            FConnector = null;
            FDestination = null;
            Dispose();
        }
        // ------------------------------------------------------------------------------
        public void SetParent(Control AParent)
        {
        }

        // ------------------------------------------------------------------------------
        public void SetBounds(int ALeft, int ATop, int AWidth, int AHeight)
        {
            if (AWidth != Width)
                AHeight = AWidth;
            else if (AHeight != Height)
                AWidth = AHeight;

            base.SetBounds(ALeft, ATop, AWidth, AHeight);
            FConnector.Offset = 0;
        }

        // ------------------------------------------------------------------------------
        public void Notification(Component AComponent, TOperation Operation)
        {

        }

        // ------------------------------------------------------------------------------
        protected override void PaintConnector()
        {
            base.PaintConnector();
            FConnector.Paint();
        }

        // ------------------------------------------------------------------------------
        public TStateConnector HitTest(Point Mouse)
        {
            TStateConnector result = null;
            return result;
        }

        // ------------------------------------------------------------------------------
        public void PrepareCanvas(TVisualElement Element)
        {
            base.PrepareCanvas(Element);

            if (Element == TVisualElement.Text)
            {
                if (FDestination == null || IsInDesignMode)
                {
                    Canvas.FontColor = Color.Gray;
                }
            }
        }

        // ------------------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            Rectangle rc = this.ClientRectangle;
            Graphics g = e.Graphics;

            PrepareCanvas(TVisualElement.Shadow);
            g.FillEllipse(
                Canvas.Brush, 
                TStateConst.ShadowHeight, 
                TStateConst.ShadowHeight,
                rc.Right-2,
                rc.Height-2);

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
        }

        // ------------------------------------------------------------------------------
        public void SetDestination(TStateControl Value)
        {
            if (Value != null && (Value.StateMachine != CheckStateMachine))
                throw new Exception("Cannot connect to node in other state machine");

            if (Value == this)
                throw new Exception("Cannot connect link to self");

            FDestination = Value;

            if (Value != null)
            {
                if (Value is TStateLink)
                {
                    FDirection= TLinkDirection.Outgoing;
                    FConnector.Destination = null;
                }
                else
                {
                    FDirection= TLinkDirection.Incoming;
                    FConnector.Destination = Value;
                }
                FConnector.Paint();
            }

            StateMachine.Invalidate();
        }

        // ------------------------------------------------------------------------------
        public void SetDirection(TLinkDirection Value)
        {
            if (Value == FDirection)
                return;
            FDirection = Value;
            Destination = null;
            StateMachine.Invalidate();
        }

        // ------------------------------------------------------------------------------
        public TStateControl __Default()
        {
            return Destination;
        }

    }//end TStateLink
}
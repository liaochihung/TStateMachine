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
            FToConnector = AddConnector(TStatePathOwner.OwnedBySource);
            FFromConnector = AddConnector(TStatePathOwner.OwnedByDestination);
            SetBounds(0, 0, 41, 41);
        }

        public TStateControl FromState
        {
          get {
            return FFromState;
          }
          set {
            SetFromState(value);
          }
        }
        public TStateControl ToState
        {
          get {
            return FToState;
          }
          set {
            SetToState(value);
          }
        }

        public event EventHandler OnTransition;
      
        private TStateControl FFromState = null;
        private TStateControl FToState = null;
        private event EventHandler FOnTransition = null;
        private TStateConnector FToConnector = null;
        private TStateConnector FFromConnector = null;
        // ------------------------------------------------------------------------------
        // TStateTransition
        // ------------------------------------------------------------------------------
        //Constructor  Create( AOwner)
        //public TStateTransition(Component AOwner):base(AOwner)
        //{
        //    FToConnector = AddConnector(TStatePathOwner.OwnedBySource);
        //    FFromConnector = AddConnector(TStatePathOwner.OwnedByDestination);
        //    SetBounds(0, 0, 41, 41);
        //}
        // ------------------------------------------------------------------------------
        //@ Destructor  Destroy()
        ~TStateTransition()
        {
            FFromState = null;
            FFromConnector = null;
            FToState = null;
            FToConnector = null;
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
            FToConnector.Offset = 0;
            FFromConnector.Offset = 0;
        }

        // ------------------------------------------------------------------------------
        public void Notification(Component AComponent, TOperation Operation)
        {
        }

        // ------------------------------------------------------------------------------
        public void PaintConnector()
        {
            base.PaintConnector();
            StateMachine.PenWidth = 1;
            FFromConnector.Paint();
            FToConnector.Paint();
        }

        // ------------------------------------------------------------------------------
        public TStateConnector HitTest(Point Mouse)
        {
            if (FToConnector.HitTest(Mouse))
            {
                return FToConnector;
            }
            else
            {
                if (FFromConnector.HitTest(Mouse))
                    return FFromConnector;
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
                if (FFromState != null && FToState != null || IsInDesignMode)
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
            g.DrawRoundedRectangle(Pens.Brown, rc.Top,rc.Left,rc.Width-1,rc.Height-1,10);
            g.FillRoundedRectangle(
                new SolidBrush(Color.FromArgb(100,70,130,180)),
                rc.Top,rc.Left,rc.Width-1,rc.Height-1,10);

            DrawName(g);
        }

        protected override void DrawName(Graphics g)
        {
            PrepareCanvas(TVisualElement.Text);
            DrawLetter(g, Text);
        }

        // ------------------------------------------------------------------------------
        public void SetFromState(TStateControl Value)
        {
        }

        // ------------------------------------------------------------------------------
        public void SetToState(TStateControl Value)
        {
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
        }

        // ------------------------------------------------------------------------------
        public TStateControl __Default()
        {
            TStateControl result = null;
            return result;
        }

    }//end TStateTransition
}
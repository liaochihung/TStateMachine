
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TStateMachineLibrary
{
    /// <summary>
    /// TStateNode
    /// </summary>
    [DefaultEvent("OnEnterState")]
    [ToolboxItem(true)]
    public class TStateNode : TStateNodeBase
    {
        public TStateControl DefaultTransition
        {
            get
            {
                return FDefaultTransition;
            }
            set
            {
                FDefaultTransition = value;
                FToConnector.Destination = value;
                if (StateMachine != null)
                    StateMachine.Invalidate();
            }
        }

        private TStateMachine FStateMachine = null;
        private TStateControl FDefaultTransition = null;
        private TStateConnector FToConnector = null;

        public TStateNode()
        {
            FToConnector = AddConnector(TStatePathOwner.OwnedBySource);
        }

        ~TStateNode()
        {
        }

        public void SetBounds(int ALeft, int ATop, int AWidth, int AHeight)
        {
        }

        public void Notification(Component AComponent, TOperation Operation)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintConnector();
        }

        public void PaintConnector()
        {
            return;
            base.PaintConnector();
            //StateMachine.CreateGraphics()
            FToConnector.Paint();
        }

        // ------------------------------------------------------------------------------
        public TStateConnector HitTest(Point Mouse)
        {
            TStateConnector result = null;
            return result;
        }

        // ------------------------------------------------------------------------------
        protected override void PrepareCanvas(TVisualElement element)
        {
            base.PrepareCanvas(element);

            // todo: add not assigned onenterstate condition
            if (element == TVisualElement.Text || IsInDesignMode)
                Canvas.FontColor = Color.Gray;
        }

        public override TStateControl Default()
        {
            return DefaultTransition;
        }


        // ------------------------------------------------------------------------------
    }//end TStateNode
}
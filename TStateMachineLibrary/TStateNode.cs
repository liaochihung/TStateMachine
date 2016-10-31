
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
    [ToolboxBitmap(typeof(TStateNode), @"D:\Projects\CSharp\TStateMachine\TStateMachineLibrary\Resources\TStateNode.bmp")]
    public class TStateNode : TStateNodeBase
    {
        public TStateControl DefaultTransition
        {
            get
            {
                return _defaultTransition;
            }

            set
            {
                _defaultTransition = value;
                _toConnector.Destination = value;

                if (StateMachine != null)
                    StateMachine.Invalidate();
            }
        }

        private TStateControl _defaultTransition = null;
        private TStateConnector _toConnector = null;

        public TStateNode()
        {
            _toConnector = AddConnector(TStatePathOwner.OwnedBySource);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintConnector();
        }

        protected override void PaintConnector()
        {
            base.PaintConnector();
            _toConnector.Paint();
        }

        protected override void PrepareCanvas(TVisualElement element)
        {
            base.PrepareCanvas(element);

            // todo: add not assigned onenterstate condition
            if (element == TVisualElement.Text || IsInDesignMode)
                Canvas.FontColor = Color.Black;
        }

        public override TStateControl Default()
        {
            return DefaultTransition;
        }


        // ------------------------------------------------------------------------------
    }//end TStateNode
}
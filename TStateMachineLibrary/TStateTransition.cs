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
    [DefaultEvent("OnTransition")]
    public class TStateTransition : TStateControl
    {
        public TStateTransition()
        {
            ToState = null;
            FromState = null;

            _toConnector = AddConnector(TStatePathOwner.OwnedBySource);
            _fromConnector = AddConnector(TStatePathOwner.OwnedByDestination);

            SetBounds(0, 0, 41, 41);
        }

        private TStateControl _fromState;
        public TStateControl FromState
        {
            get { return _fromState; }
            set
            {
                _fromState = value;
                if (_fromConnector != null)
                    _fromConnector.Destination = value;

                if (StateMachine != null)
                    StateMachine.Invalidate();
            }
        }

        private TStateControl _toState;
        public TStateControl ToState
        {
            get { return _toState; }
            set
            {
                _toState = value;

                if (_toConnector != null)
                    _toConnector.Destination = value;

                if (StateMachine != null)
                    StateMachine.Invalidate();
            }
        }

        public event EventHandler OnTransition;

        private TStateConnector _toConnector = null;
        private TStateConnector _fromConnector = null;

        ~TStateTransition()
        {
            FromState = null;
            _fromConnector = null;

            ToState = null;
            _toConnector = null;
        }

        public void SetBounds(int ALeft, int ATop, int AWidth, int AHeight)
        {
            base.SetBounds(ALeft, ATop, AWidth, AHeight);

            _toConnector.Offset = 0;
            _fromConnector.Offset = 0;
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
        //public TStateConnector HitTest(Point Mouse)
        //{
        //    if (_toConnector.HitTest(Mouse))
        //    {
        //        return _toConnector;
        //    }
        //    else
        //    {
        //        if (_fromConnector.HitTest(Mouse))
        //            return _fromConnector;
        //    }
        //    return null;
        //}

        // ------------------------------------------------------------------------------
        public void PrepareCanvas(TVisualElement Element)
        {
            base.PrepareCanvas(Element);
            if (Element == TVisualElement.Text)
            {
                if (FromState != null && ToState != null || IsInDesignMode)
                {
                    Canvas.FontColor = Color.Gray;
                }
            }
        }

        // ------------------------------------------------------------------------------
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            var RoundSize = 16;
            if (Height < RoundSize)
                RoundSize = Height;
            if (Width < RoundSize)
                RoundSize = Width;

            var rc = this.ClientRectangle;

            using (var g = e.Graphics)
            {
                PrepareCanvas(TVisualElement.Shadow);
                g.DrawRoundedRectangle(Pens.Brown, rc.Top, rc.Left, rc.Width - 1, rc.Height - 1, 10);
                //g.FillRoundedRectangle(
                //    new SolidBrush(Color.FromArgb(100, 70, 130, 180)),
                //    rc.Top, rc.Left, rc.Width - 1, rc.Height - 1, 10);

                DrawName(g);
            }

            PaintConnector();
        }

        public override void DoEnter()
        {
            base.DoEnter();

            try
            {
                if (OnTransition != null)
                    OnTransition(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                DoException();
            }
        }

        protected override void DrawName(Graphics g)
        {
            PrepareCanvas(TVisualElement.Text);
            DrawLetter(g, Text);
        }

        public override TStateControl Default()
        {
            return ToState;
        }
    }//end TStateTransition
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using TStateMachine;

namespace TStateMachineLibrary
{

    public delegate void TNotifyEvent(object sender, EventArgs e);

    [ToolboxItem(false)]
    [Designer(typeof(TStateControlDesigner))]
    [DefaultEvent("OnEnterState")]
    public class TStateControl : Control
    {
        protected TCanvas Canvas = TCanvas.Instance;

        public virtual TStateControl Default()
        {
            return null;
        }

        public event EventHandler MyClick;

        protected virtual void OnMyClick()
        {
            var e = MyClick;
            if (e != null)
                e(this, EventArgs.Empty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_disposer.Dispose();
                base.Dispose(disposing);
            }
        }

        protected bool IsInDesignMode;
        protected TStateControl()
        {
            ParentChanged += TStateControl_ParentChanged;

            SetBounds(0, 0, 69, 41);
            FConnectors = new List<TStateConnector>();
            IsInDesignMode =
                LicenseManager.UsageMode == LicenseUsageMode.Designtime;

            //SetParent(this.Parent);
        }

        void TStateControl_ParentChanged(object sender, EventArgs e)
        {
            SetParent(Parent);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Debug.Assert(!FPainting, "Recursion detected in TStateControl.OnPaint");

            FPainting = true;
            try
            {
                DoPaint(e.Graphics);
                PaintConnector();
            }
            finally
            {
                FPainting = false;
            }

        }

        protected void DrawLetter(Graphics g, string letter)
        {
            var width = ((float)this.ClientRectangle.Width);
            var height = ((float)this.ClientRectangle.Width);

            var emSize = height;
            var font = new Font(FontFamily.GenericSansSerif, emSize, Canvas.FontStyle);
            font = FindBestFitFont(g, letter, font, this.ClientRectangle.Size);

            var size = g.MeasureString(letter, font);

            var sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            //g.DrawString(letter, font, new SolidBrush(Color.Black), (width - size.Width) / 2, 0);
            g.DrawString(letter, font, new SolidBrush(Canvas.FontColor), ClientRectangle, sf);
            font.Dispose();
        }

        protected Font FindBestFitFont(Graphics g, String text, Font font, Size proposedSize)
        {
            // Compute actual size, shrink if needed
            while (true)
            {
                var size = g.MeasureString(text, font);

                // It fits, back out
                if (size.Height <= proposedSize.Height &&
                     size.Width <= proposedSize.Width) { return font; }

                // Try a smaller font (90% of old size)
                var oldFont = font;
                font = new Font(font.Name, (float)(font.Size * .9), font.Style);
                oldFont.Dispose();
            }
        }
        protected override void OnParentChanged(EventArgs e)
        {
            // Allow a null parent to support drag-and-drop
            // (from one TStateMachine to another) at design time.
            if ((this.Parent is TStateMachine) || (this.Parent == null))
            {
                base.OnParentChanged(e);
            }
            else
            {
                throw new NotSupportedException("A TStateControl control can only be added to a TStateMachine control");
            }
        }

        protected TStateMachine CheckStateMachine
        {
            get
            {
                //if (StateMachine == null)
                //    throw new Exception("Orphan " + this.Name);
                return StateMachine;
            }
        }

        public TStateMachine StateMachine
        {
            get { return _stateMachine; }
            set { _stateMachine = value; }
        }

        public bool Active
        {
            get
            {
                if (CheckStateMachine != null)
                {
                    return CheckStateMachine.State == this;
                }
                else
                {
                    return false;
                }
            }

            set
            {
                if (CheckStateMachine == null)
                    return;

                CheckStateMachine.State = value ? this : null;
            }
        }

        public List<TStateConnector> Connectors
        {
            get { return FConnectors; }
        }

        [Category("StateManage")]
        public event EventHandler OnEnterState;

        [Category("StateManage")]
        public event EventHandler OnExitState;

        public string Hint
        {
            get { return GetHint(); }
            set { SetHint(value); }
        }

        public bool Synchronize
        {
            get { return FSynchronize; }
            set { FSynchronize = value; }
        }

        protected TStateMachine _stateMachine = null;
        private List<TStateConnector> FConnectors = null;
        private bool FPainting = false;
        private bool FSynchronize = false;

        // ------------------------------------------------------------------------------
        // TStateControl
        // ------------------------------------------------------------------------------
        //Constructor  Create( AOwner)
        //public TStateControl(Component AOwner)
        //{
        //    SetBounds(0, 0, 69,41);
        //    FConnectors = new List<TStateConnector>();
        //}

        public TStateConnector AddConnector(TStatePathOwner OwnerRole)
        {
            var result = new TStateConnector(this, OwnerRole);
            Connectors.Add(result);
            return result;
        }

        // ------------------------------------------------------------------------------
        //public void DefineProperties(TFiler Filer)
        //{
        //}

        // ------------------------------------------------------------------------------
        //public void WriteConnectors(BinaryWriter Writer)
        //{
        //}

        // ------------------------------------------------------------------------------
        //public void ReadConnectors(BinaryReader Reader)
        //{
        //}

        // ------------------------------------------------------------------------------
        public void SetParent(Control aParent)
        {
            if (aParent != null && !(aParent is TStateMachine))
                throw new Exception(this.Name + " must have a TStateMachine as parent");

            _stateMachine = aParent as TStateMachine;
        }

        // ------------------------------------------------------------------------------
        public void SetBounds(int ALeft, int ATop, int AWidth, int AHeight)
        {
            base.SetBounds(ALeft, ATop, AWidth, AHeight);

            if (StateMachine != null)
                StateMachine.Invalidate();
        }

        // ------------------------------------------------------------------------------
        public TStateMachine GetCheckStateMachine()
        {
            //if (StateMachine == null)
            //    throw new Exception("Orphan " + this.Name);

            return StateMachine;
        }

        // ------------------------------------------------------------------------------
        public void SetHint(string Value)
        {
        }

        // ------------------------------------------------------------------------------
        public string GetHint()
        {
            string result = String.Empty;
            return result;
        }

        // ------------------------------------------------------------------------------
        protected virtual void PrepareCanvas(TVisualElement element)
        {
            switch (element)
            {
                case TVisualElement.Shadow:
                    Canvas.MyPen.Width = 1;
                    Canvas.MyPen.Color = Color.Gray;
                    Canvas.MyPen.DashStyle = DashStyle.Solid;
                    Canvas.Brush = Canvas.ShadowBrush;
                    break;
                case TVisualElement.Frame:
                    Canvas.MyPen.Color = Color.Black;
                    Canvas.MyPen.Width = Active ? 2 : 1;
                    break;
                case TVisualElement.Panel:
                    Canvas.Brush = Active ? Canvas.ActiveBrush : Canvas.InActiveBrush;
                    break;
                case TVisualElement.Text:
                    Canvas.FontColor = Active ? Color.White : Color.Black;
                    break;
                case TVisualElement.Connector:
                    Canvas.MyPen.Width = 1;
                    Canvas.MyPen.Color = Color.Black;
                    break;
            }
        }

        // ------------------------------------------------------------------------------
        public void DrawText(Rectangle Rect)
        {
        }

        // ------------------------------------------------------------------------------
        public virtual void DoPaint(Graphics g)
        {
            var rc = new Rectangle(TStateConst.ShadowHeight, TStateConst.ShadowHeight, Width, Height);
            DrawShadow(g, rc);

            rc.Offset(-TStateConst.ShadowHeight * 2, -TStateConst.ShadowHeight * 2);
            DrawPanel(g, rc);
            DrawBorder(g, rc);

            DrawName(g);
        }

        protected virtual void DrawName(Graphics g)
        {
            // draw name
            PrepareCanvas(TVisualElement.Text);
            DrawLetter(g, Text);
        }

        protected virtual void DrawBorder(Graphics g, Rectangle rc)
        {
            // draw border
            PrepareCanvas(TVisualElement.Frame);
            g.DrawRectangle(Canvas.MyPen, 0, 0, rc.Width - 2, rc.Height - 2);
        }

        protected virtual void DrawPanel(Graphics g, Rectangle rc)
        {
            // draw rectangle
            PrepareCanvas(TVisualElement.Panel);
            g.FillRectangle(Canvas.Brush, rc);
        }

        protected virtual void DrawShadow(Graphics g, Rectangle rc)
        {
            // draw shadow
            PrepareCanvas(TVisualElement.Shadow);
            g.FillRectangle(Canvas.Brush, rc);
        }

        // ------------------------------------------------------------------------------
        protected virtual void PaintConnector()
        {
            PrepareCanvas(TVisualElement.Connector);
        }

        // ------------------------------------------------------------------------------
        public virtual void DoEnter()
        {
            try
            {
                if (OnEnterState != null)
                    OnEnterState(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                DoException();
            }
        }

        // ------------------------------------------------------------------------------
        public void DoExit()
        {
            try
            {
                if (OnExitState != null)
                    OnExitState(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                DoException();
            }
        }

        // ------------------------------------------------------------------------------
        public void DoException()
        {
            StateMachine.DoException(this);
        }

        // ------------------------------------------------------------------------------
        public bool HandlesEnterEvent()
        {
            bool result = false;
            return result;
        }

        // ------------------------------------------------------------------------------
        public bool HandlesExitEvent()
        {
            bool result = false;
            return result;
        }


        // ------------------------------------------------------------------------------
        public TStateConnector HitTest(Point Mouse)
        {
            TStateConnector result = null;
            return result;
        }
    }
}
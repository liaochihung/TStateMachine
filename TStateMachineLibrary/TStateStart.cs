using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TStateMachineLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(TStateStart), @"D:\Projects\CSharp\TStateMachine\TStateMachineLibrary\Resources\TStateStart.bmp")]
    public class TStateStart : TStateNode
    {
        public TStateStart()
        {

        }

        ~TStateStart()
        {

        }

        protected override void DrawBorder(Graphics g, Rectangle rc)
        {
            PrepareCanvas(TVisualElement.Frame);
            float shrinkAmount = Canvas.MyPen.Width / 2;
            g.DrawRectangle(
                Canvas.MyPen,
                shrinkAmount,
                shrinkAmount,
                rc.Width - shrinkAmount,
                rc.Height - shrinkAmount);
        }

        protected override void DrawPanel(Graphics g, Rectangle rc)
        {
            PrepareCanvas(TVisualElement.Panel);
            float shrinkAmount = Canvas.MyPen.Width;
            Rectangle oriRc = rc;
            oriRc.Inflate((int)shrinkAmount * -1, (int)shrinkAmount * -1);
            RectangleF r = oriRc;
            r.Offset(shrinkAmount * 2, shrinkAmount * 2);
            //g.FillRectangle(new SolidBrush(Color.Red), r);
            g.FillRectangle(Canvas.Brush, r);
        }

        protected override void DrawName(Graphics g)
        {
            // draw name
            PrepareCanvas(TVisualElement.Text);
            DrawLetter(g, Text);
        }

        protected override void PrepareCanvas(TVisualElement element)
        {
            base.PrepareCanvas(element);
            switch (element)
            {
                case TVisualElement.Frame:
                    Canvas.MyPen.Width = 2;
                    Canvas.MyPen.Alignment = PenAlignment.Inset;
                    Canvas.MyPen.Color = Color.Green;
                    break;
                case TVisualElement.Text:
                    Canvas.FontStyle = FontStyle.Bold;
                    //Canvas.FontColor = Color.White;
                    Canvas.FontColor = Active ? Color.White : Color.Black;
                    break;
            }
        }

    }//end TStateStart
}
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TStateMachineLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(true)]
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

        protected override void DrawFrame(Graphics g, Rectangle rc)
        {
            PrepareCanvas(TVisualElement.Panel);
            float shrinkAmount = Canvas.MyPen.Width;
            Rectangle oriRc = rc;
            oriRc.Inflate((int) shrinkAmount*-1, (int) shrinkAmount*-1);
            RectangleF r = oriRc;
            r.Offset(shrinkAmount*2,shrinkAmount*2);
            g.FillRectangle(new SolidBrush(Color.Red), r);
        }

        protected override void DrawName(Graphics g)
        {
            // draw name
            PrepareCanvas(TVisualElement.Text);
            DrawLetter(g, Text);
        }

        protected void PrepareCanvas(TVisualElement Element)
        {
            //base.PrepareCanvas(Element);
            switch (Element)
            {
                case TVisualElement.Frame:
                    Canvas.MyPen.Width = 2;
                    Canvas.MyPen.Alignment = PenAlignment.Inset;
                    Canvas.MyPen.Color = Color.Green;
                    break;
                case TVisualElement.Text:
                    Canvas.FontStyle = FontStyle.Bold;
                    Canvas.FontColor = Color.White;
                    break;
            }
        }

    }//end TStateStart
}
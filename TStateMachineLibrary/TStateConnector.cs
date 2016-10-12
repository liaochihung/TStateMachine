using System;
using System.Drawing;

namespace TStateMachineLibrary
{
    public class TStateConnector
    {
        private Rectangle BoundsRect;

        public TStatePath _actualPath { get; set; }

        public int Offset { get; set; }

        private readonly TStatePathOwner _owner;

        public TStatePath Path { get; set; }

        private bool _selected;

        public TStateControl Source { get; set; }

        public TStateControl Destination { get; set; }

        private readonly bool IsInDesignMode;

        public TStateConnector()
        {
            IsInDesignMode =
                System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
        }

        ~TStateConnector()
        {
        }

        public TStateConnector(TStateControl aOwner, TStatePathOwner ownerRole)
        {
            _owner = ownerRole;
            if (ownerRole == TStatePathOwner.OwnedBySource)
            {
                Source = aOwner;
            }
            else
            {
                Destination = aOwner;
            }

            Path = TStatePath.Auto;
            _actualPath = Path;
        }

        public bool GetLines(ref Point[] lines)
        {
            //  OverlapX            ,
            bool OverlapY;
            Point p1, p2;
            Rectangle r1, r2;
            int dx, dy;
            int d2x, d2y;
            int DirectionX = 0, DirectionY = 0;
            //                   +--------+
            //                   |  Dest  |
            //                d1 |   p2   | ^
            //                   |        | |
            //                   +--------+ |
            //          ^            d2     |
            //          |                   |
            //         d2y                  |
            //          |                   dy
            //     s2   v                   |
            // +--------+<--d2x->           |
            // | Source |                   |
            // |   p1   | s1                v
            // |        |
            // +--------+
            //      <------- dx ----->

            if (Source == null || Destination == null)
                return false;

            r1 = Source.Bounds;
            r2 = Destination.Bounds;

            p1 = new Point(r1.Left + Source.Width / 2, r1.Top + Source.Height / 2);
            p2 = new Point(r2.Left + Destination.Width / 2, r2.Top + Destination.Height / 2);

            dx = p2.X - p1.X;
            dy = p2.Y - p1.Y;
            if (dx == 0)
                DirectionX = 0;
            else
                DirectionX = dx / Math.Abs(dx);

            if (dy == 0)
                DirectionY = 0;
            else
                DirectionY = dy / Math.Abs(dy);

            d2x = Math.Abs(dx) - (Source.Width + Destination.Width) / 2;
            d2y = Math.Abs(dy) - (Source.Height + Destination.Height) / 2;

            OverlapY = (d2y <= TStateConst.OverlapYMargin);

            _actualPath = Path;
            if (_actualPath == TStatePath.RightBottom &&
                ((Math.Abs(dx) - (Source.Width / 2) < TStateConst.OverlapXmargin) ||
                 (d2y + (Source.Height / 2) < TStateConst.OverlapYMargin)) ||
                ((_actualPath == TStatePath.TopLeft) &&
                 ((Math.Abs(dy) - (Source.Height / 2) < TStateConst.OverlapYMargin) ||
                  (d2x + (Source.Width / 2) < TStateConst.OverlapXmargin))))
                _actualPath = TStatePath.Auto;

            if (_actualPath == TStatePath.Auto || _actualPath == TStatePath.Direct)
            {
                if (OverlapY || (d2x > d2y))
                    _actualPath = TStatePath.LeftRight;
                else
                    _actualPath = TStatePath.TopBottom;
            }
            else
            {
                _actualPath = this.Path;
            }

            switch (_actualPath)
            {
                case TStatePath.RightBottom:
                case TStatePath.LeftRight:
                    if (DirectionX > 0)
                        lines[TDesignMove.Source] = 
                            new Point(r1.Right + 1, p1.Y);
                    else if (DirectionX < 0)
                        lines[TDesignMove.Source] = 
                            new Point(r1.Left - 1, p1.Y);
                    else
                        lines[TDesignMove.Source] = p1;
                    break;
                case TStatePath.TopLeft:
                case TStatePath.TopBottom:
                    if (DirectionY > 0)
                        lines[TDesignMove.Source] = 
                            new Point(p1.X, r1.Bottom + 1);
                    else if (DirectionY < 0)
                        lines[TDesignMove.Source] = 
                            new Point(p1.X, r1.Top - 1);
                    else
                        lines[TDesignMove.Source] = p1;
                    break;
            }

            switch (_actualPath)
            {
                case TStatePath.TopLeft:
                case TStatePath.LeftRight:
                    if (DirectionX > 0)
                        lines[TDesignMove.Destination] = 
                            new Point(r2.Left - 1, p2.Y);
                    else if (DirectionX < 0)
                        lines[TDesignMove.Destination] = 
                            new Point(r2.Right + 1, p2.Y);
                    else
                        lines[TDesignMove.Destination] = p2;
                    break;
                case TStatePath.RightBottom:
                case TStatePath.TopBottom:
                    if (DirectionY > 0)
                        lines[TDesignMove.Destination] = 
                            new Point(p2.X, r2.Top - 1);
                    else if (DirectionY < 0)
                        lines[TDesignMove.Destination] = 
                            new Point(p2.X, r2.Bottom + 1);
                    else
                        lines[TDesignMove.Destination] = p2;
                    break;
            }

            if (this.Path == TStatePath.Direct)
                _actualPath = TStatePath.Direct;

            switch (_actualPath)
            {
                case TStatePath.Direct:
                    dx = (lines[TDesignMove.Destination].X - lines[TDesignMove.Source].X) / 4;
                    dy = (lines[TDesignMove.Destination].Y - lines[TDesignMove.Source].Y) / 4;
                    lines[TDesignMove.FirstHandle] =
                        new Point(lines[TDesignMove.Source].X+dx, 
                            lines[TDesignMove.Source].Y + dy);
                    lines[TDesignMove.Offset] =
                        new Point(lines[TDesignMove.Source].X + dx * 2, 
                            lines[TDesignMove.Source].Y + dy * 2);
                    lines[TDesignMove.LastHandle] = 
                        new Point(lines[TDesignMove.Source].X + dx * 3,
                            lines[TDesignMove.Source].Y + dy * 3);
                    break;

                case TStatePath.LeftRight:
                    lines[TDesignMove.FirstHandle] =
                        new Point(
                            lines[TDesignMove.Source].X + DirectionX * d2x / 2, p1.Y);
                    lines[TDesignMove.LastHandle] =
                        new Point(lines[TDesignMove.Source].X + DirectionX * d2x / 2, p2.Y);
                    break;

                case TStatePath.TopBottom:
                    lines[TDesignMove.FirstHandle] =
                        new Point(p1.X, lines[TDesignMove.Source].Y + DirectionY * d2y / 2);
                    lines[TDesignMove.LastHandle] =
                        new Point(p2.X, lines[TDesignMove.Source].Y + DirectionY * d2y / 2);
                    break;

                case TStatePath.RightBottom:
                    lines[TDesignMove.FirstHandle] =
                        new Point(lines[TDesignMove.Source].X + (p2.X - lines[TDesignMove.Source].X) / 2, p1.Y);
                    lines[TDesignMove.LastHandle] = new Point(p2.X,
                        lines[TDesignMove.Destination].Y - (lines[TDesignMove.Destination].Y - p1.Y) / 2);
                    break;

                case TStatePath.TopLeft:
                    lines[TDesignMove.FirstHandle] =
                        new Point(p1.X, lines[TDesignMove.Source].Y + (p2.Y - lines[TDesignMove.Source].Y) / 2);
                    lines[TDesignMove.LastHandle] =
                        new Point(lines[TDesignMove.Destination].X - (lines[TDesignMove.Destination].X - p1.X) / 2, p2.Y);
                    break;

            }

            switch (_actualPath)
            {
                case TStatePath.LeftRight:
                    lines[TDesignMove.FirstHandle] =
                        new Point(lines[TDesignMove.FirstHandle].X + Offset, lines[TDesignMove.FirstHandle].Y);
                    lines[TDesignMove.LastHandle] =
                        new Point(lines[TDesignMove.FirstHandle].X, lines[TDesignMove.LastHandle].Y);
                    lines[TDesignMove.Offset] =
                        new Point(
                            lines[TDesignMove.FirstHandle].X,
                            lines[TDesignMove.FirstHandle].Y +
                            (lines[TDesignMove.LastHandle].Y - lines[TDesignMove.FirstHandle].Y) / 2);
                    break;

                case TStatePath.TopLeft:
                    lines[TDesignMove.Offset] = new Point(lines[TDesignMove.FirstHandle].X,
                        lines[TDesignMove.LastHandle].Y);
                    break;

                case TStatePath.TopBottom:
                    lines[TDesignMove.FirstHandle] =
                        new Point(lines[TDesignMove.FirstHandle].X, lines[TDesignMove.FirstHandle].Y + Offset);
                    lines[TDesignMove.LastHandle] =
                        new Point(lines[TDesignMove.LastHandle].X,
                        lines[TDesignMove.FirstHandle].Y);
                    lines[TDesignMove.Offset] = new Point(
                        lines[TDesignMove.FirstHandle].X +
                        (lines[TDesignMove.LastHandle].X - lines[TDesignMove.FirstHandle].X) / 2,
                        lines[TDesignMove.FirstHandle].Y);
                    break;
                case TStatePath.RightBottom:
                    lines[TDesignMove.Offset] = new Point(lines[TDesignMove.LastHandle].X,
                        lines[TDesignMove.FirstHandle].Y);
                    break;
            }
            return true;
        }

        protected TStateControl GetPeer(int index)
        {
            if (_owner == TStatePathOwner.OwnedBySource)
            {
                return Destination;
            }
            else
            {
                return Source;
            }
        }

        public static bool PtInRect(int x, int y, Rectangle rect)
        {
            return ((x >= rect.X) && (x <= (rect.X + rect.Width)) &&
                    (y >= rect.Y) && (y <= (rect.Y + rect.Height)));
        }

        public bool HitTest(Point Mouse)
        {
            return PtInRect(Mouse.X, Mouse.Y, BoundsRect);
        }

        public static Rectangle MakeRect(Point pa, Point pb)
        {
            var a = Math.Min(pa.X, pb.X);
            var b = Math.Min(pa.Y, pb.Y);
            var c = Math.Max(pa.Y, pb.Y);
            var d = Math.Max(pa.Y, pb.Y);
            return new Rectangle(a, b, c, d);
        }

        public void Paint()
        {
            var lines = new Point[TDesignMove.None];
            if (!GetLines(ref lines))
                return;

            var g = Source.StateMachine.CreateGraphics();
            var size = 4;
            TStatePath workPath;
            var saveWidth = 0;
            var direction = 0;
            var arrow = new Point[3];

            arrow[0] = lines[TDesignMove.Destination];
            if (_actualPath == TStatePath.Direct)
            {
                workPath = Math.Abs(lines[TDesignMove.Destination].X - lines[TDesignMove.Source].X) >
                           Math.Abs(lines[TDesignMove.Destination].Y - lines[TDesignMove.Source].Y) ? TStatePath.LeftRight : TStatePath.TopBottom;
            }
            else
            {
                workPath = _actualPath;
            }

            switch (workPath)
            {
                case TStatePath.LeftRight:
                case TStatePath.TopLeft:
                    direction = lines[TDesignMove.Destination].X - lines[TDesignMove.LastHandle].X;
                    if (direction != 0)
                        direction = direction / Math.Abs(direction);

                    lines[TDesignMove.Destination] = new Point(
                        lines[TDesignMove.Destination].X - Source.StateMachine.PenWidth * direction,
                        lines[TDesignMove.Destination].Y);
                    arrow[1] = new Point(arrow[0].X - (3 + size) * direction, arrow[0].Y - (3 + size));
                    arrow[2] = new Point(arrow[0].X - (3 + size) * direction, arrow[0].Y + (3 + size));
                    break;
                case TStatePath.TopBottom:
                case TStatePath.RightBottom:
                    direction = lines[TDesignMove.Destination].Y - lines[TDesignMove.LastHandle].Y;
                    if (direction != 0)
                        direction = direction / Math.Abs(direction);

                    lines[TDesignMove.Destination] =
                        new Point(lines[TDesignMove.Destination].X, lines[TDesignMove.Destination].Y -
                                                                    Source.StateMachine.PenWidth * direction);
                    arrow[1] = new Point(arrow[0].X - (3 + size), arrow[0].Y - (3 + size) * direction);
                    arrow[2] = new Point(arrow[0].X + (3 + size), arrow[0].Y - (3 + size) * direction);
                    break;
            }
            
            //g.DrawRectangle(Pens.Chocolate, 10, 10, 100, 100);
            //g.DrawPolygon(new Pen(Color.Black), lines);
            g.DrawLines(new Pen(Color.Black), lines);

            saveWidth = Source.StateMachine.PenWidth;
            Source.StateMachine.PenWidth = 1;
            g.DrawPolygon(new Pen(Color.Black), arrow);
            g.FillPolygon(new SolidBrush(Color.Black), arrow);
            Source.StateMachine.PenWidth = saveWidth;

            if (IsInDesignMode)
            {
                if (_selected && Source.StateMachine.Connector == this)
                {
                    for (int i = 1; i < TDesignMove.LastHandle; i++)
                    {
                        if (i != TDesignMove.Offset ||
                            !(_actualPath == TStatePath.TopLeft || _actualPath == TStatePath.RightBottom))
                        {
                            g.DrawRectangle(
                                Pens.BlueViolet, 
                                lines[i].X - 2, 
                                lines[i].Y - 2, 
                                lines[i].X + 2, 
                                lines[i].Y + 2);
                        }
                    }
                }

                BoundsRect = MakeRect(lines[TDesignMove.Source], lines[TDesignMove.Destination]);
                BoundsRect.Inflate(TStateConst.SelectMarginX, TStateConst.SelectMarginY);

                // todo: fix code below
                //BoundsRect.Inflate(BoundsRect);

                g.Dispose();
            }
        }

        public void PaintFlipLine()
        {
            if ((Source == null) || (Destination == null))
                return;

            Source.StateMachine.PenWidth = 1;
            Point p = TStateConnector.RectCenter(Source.Bounds);
            Source.StateMachine.Location = p;
            p = TStateConnector.RectCenter(Destination.Bounds);
            //Source.TStateMachine.CreateGraphics().DrawLine();
        }

        public static Point RectCenter(Rectangle r)
        {
            return new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
        }

        protected void SetPeer(int Index, TStateControl Value)
        {
            if ((Index == 1 && _owner == TStatePathOwner.OwnedBySource) ||
                ((Index == 2) && _owner == TStatePathOwner.OwnedByDestination))
            {
                throw new Exception("Cannot modify owner of connector");
            }

            switch (Index)
            {
                case 0:
                    if (_owner == TStatePathOwner.OwnedBySource)
                    {
                        Destination = Value;
                    }
                    else
                    {
                        Source = Value;
                    }
                    break;
                case 1:
                    Source = Value;
                    break;
                case 2:
                    Destination = Value;
                    break;
            }
        }

    }//end TStateConnector
}
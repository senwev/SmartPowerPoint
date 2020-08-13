using MouseClick.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MouseClick
{
    public class DrawingHelper
    {
        public event EventHandler DrawingRefreshEvent;

        public UWBAnchorArea UWBAnchorArea { get; private set; }

        public int PointWidth = 10;

        public int PointHeight = 10;

        public DrawingHelper()
        {

        }

        public void Draw(Graphics g, Rectangle area)
        {
            if (this.UWBAnchorArea == null)
            {
                return;
            }
            DrawAnchor($"Anchor0\r\nx:{this.UWBAnchorArea.Anchor0.Y},y:{this.UWBAnchorArea.Anchor0.X}", g, this.UWBAnchorArea.Anchor0, area);
            DrawAnchor($"Anchor1\r\nx:{this.UWBAnchorArea.Anchor1.Y},y:{this.UWBAnchorArea.Anchor1.X}", g, this.UWBAnchorArea.Anchor1, area);
            DrawAnchor($"Anchor2\r\nx:{this.UWBAnchorArea.Anchor2.Y},y:{this.UWBAnchorArea.Anchor2.X}", g, this.UWBAnchorArea.Anchor2, area);
            DrawAnchor($"Anchor3\r\nx:{this.UWBAnchorArea.Anchor3.Y},y:{this.UWBAnchorArea.Anchor3.X}", g, this.UWBAnchorArea.Anchor3, area);
            DrawTarget(g, this.UWBAnchorArea.TargetCursor, area);
        }

        public void Update(double[] points)
        {
            this.UWBAnchorArea.UpdateCursor(points);
            this.DrawingRefreshEvent?.Invoke(this, null);
        }

        public void Update(double pointX, double pointY)
        {
            this.UWBAnchorArea.UpdateCursor(pointX, pointY);
            this.DrawingRefreshEvent?.Invoke(this, null);
        }

        public void Paint(UWBAnchorArea area)
        {
            this.UWBAnchorArea = area;
        }

        private void DrawAnchor(string msg, Graphics g, Point p, Rectangle area)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle newArea = new Rectangle((int)(area.X + 1.0 * area.Width / 6), (int)(area.Y + 1.0 * area.Height / 3), (int)(area.Width * 2.0 / 3), (int)(area.Height * 1.0 / 3));
            var point = Transform(p, this.UWBAnchorArea.Axes, newArea);
            var brush = new SolidBrush(this.UWBAnchorArea.AnchorColor);

            g.FillEllipse(brush, new RectangleF(point, new SizeF(PointWidth, PointHeight)));
            g.DrawString(msg, new Font("宋体", 10), new SolidBrush(this.UWBAnchorArea.AnchorColor), point.X - 25, point.Y + 15);
            brush.Dispose();
        }

        private void DrawTarget(Graphics g, Point p, Rectangle area)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle newArea = new Rectangle((int)(area.X + 1.0 * area.Width / 6), (int)(area.Y + 1.0 * area.Height / 3), (int)(area.Width * 2.0 / 3), (int)(area.Height * 1.0 / 3));
            var point = Transform(p, this.UWBAnchorArea.Axes, newArea);
            var brush = new SolidBrush(this.UWBAnchorArea.TargetColor);

            g.FillEllipse(brush, new RectangleF(point, new SizeF(PointWidth, PointHeight)));
            g.DrawString($"Cursor\r\nx:{p.Y},y:{p.X}", new Font("宋体", 10), new SolidBrush(this.UWBAnchorArea.TargetColor), point.X - 25, point.Y + 15);

            brush.Dispose();
        }

        private Rectangle Transform(Rectangle rect, Rectangle axes, Rectangle area)
        {
            float w_ratio = 1.0f * area.Width / axes.Width;
            float h_ratio = 1.0f * area.Height / axes.Height;

            float x = 1.0f * (rect.X - axes.X) * w_ratio + area.X;// + area.Width * 1 / 6;
            float y = 1.0f * (rect.Y - axes.Y) * h_ratio + area.Y;// + area.Height * 1 / 6;
            float w = rect.Width * w_ratio;
            float h = rect.Height * h_ratio;

            return new Rectangle((int)x, (int)y, (int)w, (int)h);

        }

        private PointF Transform(Point p, Rectangle axes, Rectangle area)
        {
            float w_ratio = 1.0f * area.Width / axes.Width;
            float h_ratio = 1.0f * area.Height / axes.Height;

            float x = 1.0f * (p.X - axes.X) * w_ratio + area.X;// + area.Width * 1 / 6;
            float y = 1.0f * (p.Y - axes.X) * h_ratio + area.Y;// + area.Height * 1 / 6;

            return new Point((int)x, (int)y);
        }

    }
}

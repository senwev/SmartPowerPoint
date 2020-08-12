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

        public Point Anchor1 { get; set; }

        public Point Anchor2 { get; set; }

        public Point Anchor3 { get; set; }

        public Point Anchor4 { get; set; }

        public Point Cursor { get; set; }

        public int Width = 120;

        public int Height = 100;

        public Color AnchorColor = Color.Red;

        public Color TargetColor = Color.Green;

        public Rectangle Axes;

        public DrawingHelper()
        {

        }

        private void DrawAnchor(Graphics g, Point p, Rectangle area)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = Width;
            int h = Height;
            //Rectangle rect = new Rectangle((int)(p.X - w / 2.0), (int)(p.Y - h / 2.0), Width, Height);

            Rectangle newArea = new Rectangle((int)(area.X + 1.0 * area.Width / 6), (int)(area.Y + 1.0 * area.Height / 3), (int)(area.Width * 2.0 / 3), (int)(area.Height * 1.0 / 3));
            var point = Transform(p, this.Axes, newArea);
            var brush = new SolidBrush(AnchorColor);

            g.FillEllipse(brush, new RectangleF(point, new SizeF(10, 10)));
            brush.Dispose();
        }

        private void DrawTarget(Graphics g, Point p, Rectangle area)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = Width;
            int h = Height;
            //Rectangle rect = new Rectangle((int)(p.X - w / 2.0), (int)(p.Y - h / 2.0), Width, Height);
            //Rectangle newArea = new Rectangle((int)(area.X + 1.0 * area.Width / 6), (int)(area.Y + 1.0 * area.Height / 3), (int)(area.Width * 2.0 / 3), (int)(area.Height * 1.0 / 3));
            //var trect = Transform(rect, this.Axes, newArea);
            //var brush = new SolidBrush(TargetColor);
            Rectangle newArea = new Rectangle((int)(area.X + 1.0 * area.Width / 6), (int)(area.Y + 1.0 * area.Height / 3), (int)(area.Width * 2.0 / 3), (int)(area.Height * 1.0 / 3));
            var point = Transform(p, this.Axes, newArea);
            var brush = new SolidBrush(AnchorColor);

            g.FillEllipse(brush, new RectangleF(point, new SizeF(10, 10)));

            //g.FillEllipse(brush, trect);
            brush.Dispose();
        }

        public void Draw(Graphics g, Rectangle area)
        {
            DrawAnchor(g, Anchor1, area);
            DrawAnchor(g, Anchor2, area);
            DrawAnchor(g, Anchor3, area);
            DrawAnchor(g, Anchor4, area);
            DrawTarget(g, Cursor, area);
        }

        public void Update(double[] point)
        {
            var p = new Point((int)point[0], (int)point[1]);
            this.Cursor = p;
            this.DrawingRefreshEvent?.Invoke(this, null);
        }

        public void Update(Tuple<double, double> anchor1, Tuple<double, double> anchor2, Tuple<double, double> anchor3, Tuple<double, double> anchor4)
        {
            this.Anchor1 = new Point((int)anchor1.Item1, (int)anchor1.Item2);
            this.Anchor2 = new Point((int)anchor2.Item1, (int)anchor2.Item2);
            this.Anchor3 = new Point((int)anchor3.Item1, (int)anchor3.Item2);
            this.Anchor4 = new Point((int)anchor4.Item1, (int)anchor4.Item2);
            //this.DrawingRefreshEvent?.Invoke(this, null);
            var x_list = new List<double>();
            x_list.Add(anchor1.Item1);
            x_list.Add(anchor2.Item1);
            x_list.Add(anchor3.Item1);
            x_list.Add(anchor4.Item1);

            var y_list = new List<double>();
            y_list.Add(anchor1.Item2);
            y_list.Add(anchor2.Item2);
            y_list.Add(anchor3.Item2);
            y_list.Add(anchor4.Item2);

            var width = x_list.Max((x) => x);
            var height = y_list.Max((y) => y);

            this.Axes = new Rectangle(0, 0, (int)width, (int)height);
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

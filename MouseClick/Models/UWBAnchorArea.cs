using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseClick.Models
{
    public class UWBAnchorArea
    {
        public Point Anchor0 { get; private set; }

        public Point Anchor1 { get; private set; }

        public Point Anchor2 { get; private set; }

        public Point Anchor3 { get; private set; }

        public Color AnchorColor => Color.Red;

        public Color TargetColor => Color.Green;

        public Rectangle Axes { get; private set; }

        public int Width
        {
            get
            {
                return this.Axes.Width;
            }
        }

        public int Height
        {
            get
            {
                return this.Axes.Height;
            }
        }

        public Point TargetCursor { get; private set; }

        public double Coff_A { get; set; }

        public double Coff_B { get; set; }

        public UWBAnchorArea()
        {
            var coff_A = 1;
            var coff_B = 0;
            this.Coff_A = coff_A;
            this.Coff_B = coff_B;
        }

        public void Render(Tuple<double, double> anchor1, Tuple<double, double> anchor2, Tuple<double, double> anchor3, Tuple<double, double> anchor4)
        {
            this.Anchor0 = new Point((int)anchor1.Item2, (int)anchor1.Item1);
            this.Anchor1 = new Point((int)anchor2.Item2, (int)anchor2.Item1);
            this.Anchor2 = new Point((int)anchor3.Item2, (int)anchor3.Item1);
            this.Anchor3 = new Point((int)anchor4.Item2, (int)anchor4.Item1);

            var x_list = new List<double>();
            x_list.Add(anchor1.Item2);
            x_list.Add(anchor2.Item2);
            x_list.Add(anchor3.Item2);
            x_list.Add(anchor4.Item2);

            var y_list = new List<double>();
            y_list.Add(anchor1.Item1);
            y_list.Add(anchor2.Item1);
            y_list.Add(anchor3.Item1);
            y_list.Add(anchor4.Item1);

            var width = x_list.Max((x) => x);
            var height = y_list.Max((y) => y);

            this.Axes = new Rectangle(0, 0, (int)width, (int)height);
            Random rand = new Random();

            this.TargetCursor = new Point(rand.Next(0, this.Axes.Width), rand.Next(0, this.Axes.Height));
        }

        public void UpdateCursor(double pointX, double pointY)
        {
            var p = new Point((int)pointY, (int)pointX);
            this.TargetCursor = p;
        }

        public void UpdateCursor(double[] points)
        {
            var p = new Point((int)points[1], (int)points[0]);
            this.TargetCursor = p;

        }

        public List<Tuple<double, double>> ToAnchorList()
        {
            var list = new List<Tuple<double, double>>();
            list.Add(ConvertToTuple(Anchor0));
            list.Add(ConvertToTuple(Anchor1));
            list.Add(ConvertToTuple(Anchor2));
            list.Add(ConvertToTuple(Anchor3));
            return list;
        }

        private Tuple<double, double> ConvertToTuple(Point p)
        {
            var t = new Tuple<double, double>(p.X, p.Y);
            return t;
        }
    }
}

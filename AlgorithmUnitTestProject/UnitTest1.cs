using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using MouseClick.Solvers;
using System.Linq;
using System.Drawing.Drawing2D;
using MouseClick;
using System.Threading;

namespace AlgorithmUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var list = new List<Point>();

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                var p = new Point(random.Next(1, 100), random.Next(1, 100));
                list.Add(p);
            }
            for (int k = 0; k < 10; k++)
            {
                var center = new Point(random.Next(1, 100), random.Next(1, 100));

                double[] ds = new double[4];

                for (int i = 0; i < 4; i++)
                {
                    ds[i] = Distance(center, list[i]) + random.NextDouble() * 1.5;
                }

                var solver = new UWBPositionSolver2D(list.Select((p) => new Tuple<double, double>(p.X, p.Y)).ToArray(), 1, 0);

                var solution = solver.Update(ds);
                Console.WriteLine($"第{k + 1}次");
                Console.WriteLine($"real   X:{center.X}         Y:{center.Y}");
                Console.WriteLine($"solve   X:{solution[0]}         Y:{solution[1]}");
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            uint num = 0;
            num = num - 1;
            var arr = BitConverter.GetBytes(num);
            Console.WriteLine("{0:X}{1:X}{2:X}{3:X}", arr[0], arr[1], arr[2], arr[3]);
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var list = new List<Tuple<double, double, double>>();

            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                var p = new Tuple<double, double, double>(random.Next(1, 100), random.Next(1, 100), random.Next(1, 100));
                list.Add(p);
            }
            for (int k = 0; k < 10; k++)
            {
                var center = new Tuple<double, double, double>(random.Next(1, 100), random.Next(1, 100), random.Next(1, 100));

                double[] ds = new double[4];

                for (int i = 0; i < 4; i++)
                {
                    ds[i] = Distance3D(center, list[i]) + random.NextDouble() * 1.5;
                }

                var solver = new UWBPositionSolver3D(list, 1, 0);

                var solution = solver.Update(ds);
                Console.WriteLine($"第{k + 1}次");
                Console.WriteLine($"real   X:{center.Item1}         Y:{center.Item2}         Z:{center.Item3}");
                Console.WriteLine($"solve   X:{solution[0]}         Y:{solution[1]}         Y:{solution[2]}");
            }
        }

        private double Distance3D(Tuple<double, double, double> p1, Tuple<double, double, double> p2)
        {
            return Math.Sqrt((p1.Item1 - p2.Item1) * (p1.Item1 - p2.Item1) +
                (p1.Item2 - p2.Item2) * (p1.Item2 - p2.Item2) +
                (p1.Item3 - p2.Item3) * (p1.Item3 - p2.Item3));
        }

        [TestMethod]
        public void TestMethod4()
        {
            var area = new Rectangle(0, 0, 500, 300);
            var axes = new Rectangle(0, 0, 4200, 1800);

            Rectangle newArea = new Rectangle((int)(area.X + 1.0 * area.Width / 6), (int)(area.Y + 1.0 * area.Height / 3), (int)(area.Width * 2.0 / 3), (int)(area.Height * 1.0 / 3));
            var rect1 = new Rectangle(0, 0, 100, 100);
            var result1 = Transform(rect1, axes, newArea);
            var rect2 = new Rectangle(4200, 1800, 100, 100);
            var result2 = Transform(rect2, axes, newArea);
            var rect3 = new Rectangle(0, 1800, 100, 100);
            var result3 = Transform(rect2, axes, newArea);
            var rect4 = new Rectangle(4200, 0, 100, 100);
            var result4 = Transform(rect2, axes, newArea);
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


        [TestMethod]
        public void TestMethod_SmoothHelper()
        {
            SmoothValueHelper helper = new SmoothValueHelper(10, 3);
            helper.startTrigger();
            for (int i =0; i < 3;i++)
            {
                helper.postValue(new float[] { (float)i, (float)(i-0.5), (float)(i+0.5 )});
                for (int j = 0; j < 100; j++)
                {
                    Console.WriteLine(helper.getSmoothValue()[0].ToString() + "|" + helper.getSmoothValue()[1].ToString() + "|" + helper.getSmoothValue()[2].ToString());
                    Thread.Sleep(10);
                }
                
            }
        }

    }
}

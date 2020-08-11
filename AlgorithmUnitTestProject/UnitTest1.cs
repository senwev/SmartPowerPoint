using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using MouseClick.Solvers;
using System.Linq;
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

                var solver = new UWBPositionSolver(list.Select((p) => new Tuple<double, double>(p.X, p.Y)).ToArray(), 1, 0);

                var solution = solver.Update(ds);
                Console.WriteLine($"第{k+1}次");
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
    }
}

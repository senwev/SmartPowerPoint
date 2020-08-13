using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseClick
{
    using Solvers;
    class Global
    {
        static public double[] Position = new double[3] {1.213,1.163,1.229};

        static public MovingAverage XMovingAverage = new MovingAverage(10);

        static public MovingAverage YMovingAverage = new MovingAverage(10);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseClick
{
    using Utils;
    class Global
    {
        static public double[] Position = new double[3] { 1.213, 1.163, 1.229 };

        static public volatile double[] Viewer3DCamera = new double[2];

        static public MovingAverage XMovingAverage = new MovingAverage(20);

        static public MovingAverage YMovingAverage = new MovingAverage(20);

        //配置全局设置
        static public bool shouldShowHideBlock = false;
    }
}

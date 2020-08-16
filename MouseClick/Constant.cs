using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseClick
{
    using Devices;
    using MouseClick.Models;
    using MouseClick.Solvers;
    using System.Data;

    public class Constant
    {

        public static DrawingHelper DrawingHelper = new DrawingHelper();

        public static UWBAnchorArea UWBAnchorArea = new UWBAnchorArea();

        public static UWBPositionSolver2D solver2D;

        public static UWBPositionSolver3D solver3D;

        public static SerialHelper SerialHelper = new SerialHelper();

        public static EventHandler<Tuple<double, double, double>> Viewer3DOrientationChanged;

        public static EventHandler<double> Viewer3DDistanceChanged;

        public static void SendViewer3DOrientation(double x, double y, double z)
        {
            Viewer3DOrientationChanged?.Invoke(null,
                new Tuple<double, double, double>(x, y, z));
        }

        public static void SendViewer3DOrientation(double d)
        {
            Viewer3DDistanceChanged?.Invoke(null, d);
        }

    }
}

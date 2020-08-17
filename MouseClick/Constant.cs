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

        public static EventHandler<Tuple<float, float, float, float>> Viewer3DOrientationChanged;

        public static EventHandler<double> Viewer3DDistanceChanged;

        public static void SendViewer3DOrientation(float x, float y, float z, float w)
        {
            Viewer3DOrientationChanged?.Invoke(null,
                new Tuple<float, float, float, float>(x, y, z, w));
        }

        public static void SendViewer3DDistance(double d)
        {
            Viewer3DDistanceChanged?.Invoke(null, d);
        }

    }
}

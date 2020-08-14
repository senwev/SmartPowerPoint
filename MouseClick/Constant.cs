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

    public class Constant
    {

        public static DrawingHelper DrawingHelper = new DrawingHelper();

        public static UWBAnchorArea UWBAnchorArea = new UWBAnchorArea();

        public static UWBPositionSolver2D solver2D;

        private UWBPositionSolver3D solver3D;

        public static SerialHelper SerialHelper = new SerialHelper();

    }
}

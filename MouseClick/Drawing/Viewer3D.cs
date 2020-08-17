
using System;
using System.Windows.Forms;



namespace MouseClick
{
    public partial class Viewer3D : Form
    {
        public Viewer3D()
        {
            InitializeComponent();
            Constant.Viewer3DOrientationChanged += new System.EventHandler<System.Tuple<float, float, float, float>>(Handle_Viewer3DOrientationChanged);
            Constant.Viewer3DDistanceChanged += new EventHandler<double>(Handle_Viewer3DDistanceChanged);
        }


        private void Viewer3D_FormClosing(object sender, FormClosingEventArgs e)
        {
            Constant.Viewer3DOrientationChanged -= new System.EventHandler<System.Tuple<float, float, float, float>>(Handle_Viewer3DOrientationChanged);
            Constant.Viewer3DDistanceChanged -= new EventHandler<double>(Handle_Viewer3DDistanceChanged);
            this.viewer3DControl1.OnClosing();
        }

        private void Handle_Viewer3DOrientationChanged(object sender, Tuple<float, float, float, float> e)
        {
            this.viewer3DControl1?.OnAdjustToAngle(e.Item1, e.Item2, e.Item3, e.Item4);
        }

        private void Handle_Viewer3DDistanceChanged(object sender, double d)
        {
            this.viewer3DControl1?.OnAdjustToDistance((float)d);
        }

        private void Viewer3D_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
    }
}

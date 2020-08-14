
using System;
using System.Windows.Forms;



namespace MouseClick
{
    public partial class Viewer3D : Form
    {
        public Viewer3D()
        {
            InitializeComponent();
            Constant.Viewer3DOrientationChanged +=
                new System.EventHandler<System.Tuple<double, double>>(Handle_Viewer3DOrientationChanged);
        }

        private void Viewer3D_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.viewer3DControl1.OnClosing();
        }

        private void Handle_Viewer3DOrientationChanged(object sender,Tuple<double,double> e)
        {
            this.viewer3DControl1?.OnMoveToAngle(e.Item1, e.Item2);
        }
    }
}

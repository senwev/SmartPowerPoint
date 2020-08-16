
using System;
using System.Windows.Forms;



namespace MouseClick.Drawing
{
    public partial class Viewer3DPanel : UserControl
    {
        public Viewer3DPanel()
        {
            InitializeComponent();
            Constant.Viewer3DOrientationChanged += new System.EventHandler<System.Tuple<float, float, float, float>>(Handle_Viewer3DOrientationChanged);
        }

        private void Handle_Viewer3DOrientationChanged(object sender, Tuple<float, float, float, float> e)
        {

            this.viewer3DControl1?.OnAdjustToAngle(e.Item1, e.Item2, e.Item3, e.Item4);
        }

        public void Close()
        {
            Constant.Viewer3DOrientationChanged -= new System.EventHandler<System.Tuple<float, float, float, float>>(Handle_Viewer3DOrientationChanged);
            this.viewer3DControl1.OnClosing();
        }

    }
}

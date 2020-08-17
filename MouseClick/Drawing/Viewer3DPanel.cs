
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
            Constant.Viewer3DDistanceChanged += new EventHandler<double>(Handle_Viewer3DDistanceChanged);
        }

        private void Handle_Viewer3DOrientationChanged(object sender, Tuple<float, float, float, float> e)
        {

            this.viewer3DControl1?.OnAdjustToAngle(e.Item1, e.Item2, e.Item3, e.Item4);
        }

        private void Handle_Viewer3DDistanceChanged(object sender, double d)
        {
            this.viewer3DControl1?.OnAdjustToDistance((float)d);
        }

        public void OpenFile(string fileName)
        {
            this.viewer3DControl1.OpenFile(fileName);
        }

        public void Close()
        {
            Constant.Viewer3DOrientationChanged -= new System.EventHandler<System.Tuple<float, float, float, float>>(Handle_Viewer3DOrientationChanged);
            Constant.Viewer3DDistanceChanged -= new EventHandler<double>(Handle_Viewer3DDistanceChanged);
            this.viewer3DControl1.OnClosing();
        }

    }
}

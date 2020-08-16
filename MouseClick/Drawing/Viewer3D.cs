﻿
using System;
using System.Windows.Forms;



namespace MouseClick
{
    public partial class Viewer3D : Form
    {
        public Viewer3D()
        {
            InitializeComponent();
            Constant.Viewer3DOrientationChanged = new System.EventHandler<System.Tuple<float, float, float, float>>(Handle_Viewer3DOrientationChanged);
        }

        private void Viewer3D_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.viewer3DControl1.OnClosing();
        }

        private void Handle_Viewer3DOrientationChanged(object sender, Tuple<float, float, float, float> e)
        {
            this.viewer3DControl1?.OnAdjustToAngle(e.Item1, e.Item2, e.Item3, e.Item4);
        }

        private void Viewer3D_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
    }
}

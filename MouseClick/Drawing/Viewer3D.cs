
using System.Windows.Forms;



namespace MouseClick
{
    public partial class Viewer3D : Form
    {
        public Viewer3D()
        {
            InitializeComponent();
        }

        private void Viewer3D_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.viewer3DControl1.OnClosing();
        }
    }
}

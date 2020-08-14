using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClick
{
    public partial class DemoWindow : Form
    {
        public DemoWindow()
        {
            InitializeComponent();
        }

        private void DemoWindow_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
            this.WindowState = FormWindowState.Maximized;    //最大化窗体 
        }

        private void DemoWindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClick
{
    public partial class ToastWindow : Form
    {
        public ToastWindow()
        {
            InitializeComponent();
        }

        private void ToastWindow_Load(object sender, EventArgs e)
        {
            var task = Task.Factory.StartNew(waitClose);

        }

        private void waitClose()
        {
            Thread.Sleep(2000);
            this.Invoke((MethodInvoker)delegate
            {

                this.Close();
            });
        }
    }
}

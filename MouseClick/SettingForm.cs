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


    public partial class SettingForm : Form
    {

        static public string config_Host = "0.0.0.0";
        public SettingForm()
        {
            InitializeComponent();
        }

        private void 开启遮挡_Click(object sender, EventArgs e)
        {
            Form1 mainform = new Form1();
            mainform.Show();
        }

        private void IptextBox_TextChanged(object sender, EventArgs e)
        {
            config_Host = IptextBox.Text;
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //Uri uri = new Uri("javascript:alert('asd')");
            //webBrowser1.Url = uri;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //webBrowser1.ScriptErrorsSuppressed = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new WebBrowserForm().Show();
        }

        private void serialSettingControl1_Load(object sender, EventArgs e)
        {

        }
    }
}

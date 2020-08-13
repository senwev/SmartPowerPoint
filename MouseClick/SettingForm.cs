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
            this.Init();
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
            //new WebBrowserForm().Show();
            var view = new Viewer3D();
            view.ShowDialog();
            view.Dispose();
        }

        private void serialSettingControl1_Load(object sender, EventArgs e)
        {

        }

        private void button_Apply_Anchor_Click(object sender, EventArgs e)
        {
            Constant.UWBAnchorArea = new Models.UWBAnchorArea();

            var anchor0_x = Convert.ToDouble(this.textBox_Anchor0_X.Text);
            var anchor0_y = Convert.ToDouble(this.textBox_Anchor0_Y.Text);
            var anchor1_x = Convert.ToDouble(this.textBox_Anchor1_X.Text);
            var anchor1_y = Convert.ToDouble(this.textBox_Anchor1_Y.Text);
            var anchor2_x = Convert.ToDouble(this.textBox_Anchor2_X.Text);
            var anchor2_y = Convert.ToDouble(this.textBox_Anchor2_Y.Text);
            var anchor3_x = Convert.ToDouble(this.textBox_Anchor3_X.Text);
            var anchor3_y = Convert.ToDouble(this.textBox_Anchor3_Y.Text);

            var p0 = new Tuple<double, double>(anchor0_x, anchor0_y);
            var p1 = new Tuple<double, double>(anchor1_x, anchor1_y);
            var p2 = new Tuple<double, double>(anchor2_x, anchor2_y);
            var p3 = new Tuple<double, double>(anchor3_x, anchor3_y);

            Constant.UWBAnchorArea.Render(p0, p1, p2, p3);
            Constant.DrawingHelper.Paint(Constant.UWBAnchorArea);
        }

        private void button_Reset_Anchor_Click(object sender, EventArgs e)
        {
            Init();
            Constant.UWBAnchorArea = new Models.UWBAnchorArea();

            var anchor0_x = Convert.ToDouble(this.textBox_Anchor0_X.Text);
            var anchor0_y = Convert.ToDouble(this.textBox_Anchor0_Y.Text);
            var anchor1_x = Convert.ToDouble(this.textBox_Anchor1_X.Text);
            var anchor1_y = Convert.ToDouble(this.textBox_Anchor1_Y.Text);
            var anchor2_x = Convert.ToDouble(this.textBox_Anchor2_X.Text);
            var anchor2_y = Convert.ToDouble(this.textBox_Anchor2_Y.Text);
            var anchor3_x = Convert.ToDouble(this.textBox_Anchor3_X.Text);
            var anchor3_y = Convert.ToDouble(this.textBox_Anchor3_Y.Text);

            var p0 = new Tuple<double, double>(anchor0_x, anchor0_y);
            var p1 = new Tuple<double, double>(anchor1_x, anchor1_y);
            var p2 = new Tuple<double, double>(anchor2_x, anchor2_y);
            var p3 = new Tuple<double, double>(anchor3_x, anchor3_y);

            Constant.UWBAnchorArea.Render(p0, p1, p2, p3);
            Constant.DrawingHelper.Paint(Constant.UWBAnchorArea);
        }

        private void Init()
        {
            var anchor0 = new Tuple<double, double>(1800, 0);
            var anchor1 = new Tuple<double, double>(0, 0);
            var anchor2 = new Tuple<double, double>(0, 4200);
            var anchor3 = new Tuple<double, double>(1800, 4200);

            this.textBox_Anchor0_X.Text = anchor0.Item1.ToString("f2");
            this.textBox_Anchor0_Y.Text = anchor0.Item2.ToString("f2");
            this.textBox_Anchor1_X.Text = anchor1.Item1.ToString("f2");
            this.textBox_Anchor1_Y.Text = anchor1.Item2.ToString("f2");
            this.textBox_Anchor2_X.Text = anchor2.Item1.ToString("f2");
            this.textBox_Anchor2_Y.Text = anchor2.Item2.ToString("f2");
            this.textBox_Anchor3_X.Text = anchor3.Item1.ToString("f2");
            this.textBox_Anchor3_Y.Text = anchor3.Item2.ToString("f2");
        }
    }
}

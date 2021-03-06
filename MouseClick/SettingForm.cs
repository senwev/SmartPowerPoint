﻿using MouseClick.Drawing;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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


        Form1 mainform;

        private void 开启遮挡_Click(object sender, EventArgs e)
        {
            //
            if (开启遮挡.Text == "打开遮罩窗")
            {
                if (mainform != null)
                {
                    mainform.Visible = true;
                    mainform.Show();
                }
                else
                {
                    mainform = new Form1();
                    mainform.Show();
                }
                开启遮挡.Text = "关闭遮罩窗";
            }
            else
            {
                mainform.Visible = false;
                开启遮挡.Text = "打开遮罩窗";
            }
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
            //加载并查看本机IP
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
            foreach (IPAddress ipa in ipadrlist)
            {
                if (ipa.AddressFamily == AddressFamily.InterNetwork)
                {
                    iplist.Items.Add(ipa.ToString());
                    //Console.WriteLine(ipa.ToString());
                }
            }

            this.LoadAppSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var viewer3D = new Viewer3D();
            var directory = Environment.CurrentDirectory;
            var fileName = System.IO.Path.Combine(directory, "Resources/Coronavirus_obj/covid19.obj");
            viewer3D.Show();
            if (System.IO.File.Exists(fileName))
            {
                viewer3D.OpenFile(fileName);
            }
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

            //保存用户配置
            this.SaveAppSettings();
        }

        private void button_Reset_Anchor_Click(object sender, EventArgs e)
        {
            //加载用户配置
            this.LoadAppSettings();

            //重新初始化基站区域
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

            //重新渲染
            Constant.UWBAnchorArea.Render(p0, p1, p2, p3);

            //重新绘制
            Constant.DrawingHelper.Paint(Constant.UWBAnchorArea);

        }

        private void LoadAppSettings()
        {
            //初始化布局
            Constant.UWBAnchorArea = new Models.UWBAnchorArea();

            //加载坐标位置信息
            var anchor0 = new Tuple<double, double>(AppSettings.Default.Anchor0_X, AppSettings.Default.Anchor0_Y);
            var anchor1 = new Tuple<double, double>(AppSettings.Default.Anchor1_X, AppSettings.Default.Anchor1_Y);
            var anchor2 = new Tuple<double, double>(AppSettings.Default.Anchor2_X, AppSettings.Default.Anchor2_Y);
            var anchor3 = new Tuple<double, double>(AppSettings.Default.Anchor3_X, AppSettings.Default.Anchor3_Y);

            //渲染布局
            Constant.UWBAnchorArea.Render(anchor0, anchor1, anchor2, anchor3);

            //绘制布局
            Constant.DrawingHelper.Paint(Constant.UWBAnchorArea);

            //界面显示
            this.textBox_Anchor0_X.Text = anchor0.Item1.ToString("f2");
            this.textBox_Anchor0_Y.Text = anchor0.Item2.ToString("f2");
            this.textBox_Anchor1_X.Text = anchor1.Item1.ToString("f2");
            this.textBox_Anchor1_Y.Text = anchor1.Item2.ToString("f2");
            this.textBox_Anchor2_X.Text = anchor2.Item1.ToString("f2");
            this.textBox_Anchor2_Y.Text = anchor2.Item2.ToString("f2");
            this.textBox_Anchor3_X.Text = anchor3.Item1.ToString("f2");
            this.textBox_Anchor3_Y.Text = anchor3.Item2.ToString("f2");
        }

        private void SaveAppSettings()
        {
            try
            {
                var anchor0_x = Convert.ToDouble(this.textBox_Anchor0_X.Text);
                var anchor0_y = Convert.ToDouble(this.textBox_Anchor0_Y.Text);
                var anchor1_x = Convert.ToDouble(this.textBox_Anchor1_X.Text);
                var anchor1_y = Convert.ToDouble(this.textBox_Anchor1_Y.Text);
                var anchor2_x = Convert.ToDouble(this.textBox_Anchor2_X.Text);
                var anchor2_y = Convert.ToDouble(this.textBox_Anchor2_Y.Text);
                var anchor3_x = Convert.ToDouble(this.textBox_Anchor3_X.Text);
                var anchor3_y = Convert.ToDouble(this.textBox_Anchor3_Y.Text);

                AppSettings.Default.Anchor0_X = anchor0_x;
                AppSettings.Default.Anchor0_Y = anchor0_y;
                AppSettings.Default.Anchor1_X = anchor1_x;
                AppSettings.Default.Anchor1_Y = anchor1_y;
                AppSettings.Default.Anchor2_X = anchor2_x;
                AppSettings.Default.Anchor2_Y = anchor2_y;
                AppSettings.Default.Anchor3_X = anchor3_x;
                AppSettings.Default.Anchor3_Y = anchor3_y;
                AppSettings.Default.Save();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                MessageBox.Show("填入的坐标参数不正确！请检查后重试！", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void serialSettingControl2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form demoWindow = new DemoWindow();
            demoWindow.Show();
        }

        Process eyecareConsoleProcess = new Process();
        private void openEyecare_Click(object sender, EventArgs e)
        {
            Process process = eyecareConsoleProcess;

            if (openEyecare.Text == "关闭智慧眼")
            {
                process.Kill();
                openEyecare.Text = "打开智慧眼";
                return;
            }
            else
            {
                openEyecare.Text = "关闭智慧眼";
            }

            try
            {
                process.StartInfo.UseShellExecute = false;   //是否使用操作系统shell启动 
                process.StartInfo.CreateNoWindow = true;   //是否在新窗口中启动该进程的值 (不显示程序窗口)
                process.StartInfo.RedirectStandardInput = true;  // 接受来自调用程序的输入信息 
                process.StartInfo.RedirectStandardOutput = true;  // 由调用程序获取输出信息
                process.StartInfo.RedirectStandardError = true;  //重定向标准错误输出
                process.StartInfo.FileName = "cmd.exe";
                process.Start();                         // 启动程序
                process.StandardInput.WriteLine("e:\ncd E:\\研究生电子设计大赛\\EyeCare\\detector\nconda activate eyecare\npython webcam_detector.py\n"); //向cmd窗口发送输入信息
                //process.StandardInput.WriteLine("cd E:\\研究生电子设计大赛\\EyeCare\\detector"); //向cmd窗口发送输入信息
                //process.StandardInput.WriteLine("conda activate eyecare"); //向cmd窗口发送输入信息
                //process.StandardInput.WriteLine("python webcam_detector.py"); //向cmd窗口发送输入信息

                process.StandardInput.AutoFlush = true;
                // 前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
                //process.StandardInput.WriteLine("exit");

                StreamReader reader = process.StandardOutput;//获取exe处理之后的输出信息
                string curLine = reader.ReadLine(); //获取错误信息到error

                //开启线程读取输出
                Thread thread2 = new Thread(() =>
                {

                    while (!reader.EndOfStream)
                    {
                        if (!string.IsNullOrEmpty(curLine))
                        {
                            ////主线程操作，使用委托
                            //this.Invoke((MethodInvoker)delegate
                            //{

                            //    eyeCareOutput.Text += curLine + "\r\n";
                            //    //eyeCareOutput.Focus();
                            //    //eyeCareOutput.Select(eyeCareOutput.Text.Length, 0);
                            //    //eyeCareOutput.ScrollToCaret();

                            //});

                            if (curLine.Contains("画面OK了"))
                            {
                                MessageBox.Show("智慧眼开启成功");
                                break;
                            }

                        }
                        curLine = reader.ReadLine();
                        Thread.Sleep(1);
                    }
                    reader.Close(); //close进程

                    process.WaitForExit();  //等待程序执行完退出进程
                    process.Close();
                }

                );
                thread2.Start();




            }
            catch (Exception ex)
            {

            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //配置是否开启遮挡
            Global.shouldShowHideBlock = checkBox1.Checked;
        }


        private async void SendTest()
        {
            //await Task.Delay(10000);
            Random random = new Random();
            float x = 0f;
            float y = 0;
            float z = -0.785f;
            int i = 0;
            int flag = 1;
            int count = random.Next(400, 600);
            int w = 0;
            Constant.SendViewer3DOrientation(x, y, z, w);

            while (true)
            {
                //if (i < count && flag % 3 == 1)
                //{
                //    x += 1.0 / 100;
                //}


                //if (i < count && flag % 3 == 2)
                //{
                //    y += 1.0 / 100;
                //}

                //if (i < count && flag % 3 == 0)
                //{
                //    z += 1.0 / 100;
                //}

                //if (i >= count)
                //{
                //    i = 0;
                //    count = random.Next(400, 600);
                //    flag++;
                //}
                //i++;
                y += 1.0f / 10;//Global.Viewer3DCamera[0];
                z += 1.0f / 10;
                //y += random.NextDouble() /10;//Global.Viewer3DCamera[1];
                //x = Global.Viewer3DCamera[0];
                //y = Global.Viewer3DCamera[1];
                Constant.SendViewer3DOrientation(x, y, z, w);
                await Task.Delay(10);
            }
        }

        private void testrotate_Click(object sender, EventArgs e)
        {
            SendTest();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendTest();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //float d = float.Parse(textBox_D.Text);
            //Constant.SendViewer3DDistance(d);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //float x = float.Parse(textBox_X.Text);
            //float y = float.Parse(textBox_Y.Text);
            //float z = float.Parse(textBox_Z.Text);
            //Constant.SendViewer3DOrientation(x, y, z, 0);
        }

        private void toasst_Click(object sender, EventArgs e)
        {
            ToastWindow toastWindow = new ToastWindow();
            Global.toastString = "测试输出";
            toastWindow.Show();
        }

        private void buttonOpenPaintPanel_Click(object sender, EventArgs e)
        {
            var paintForm = new PaintPanel();
            paintForm.ShowDialog();
        }

        private void toast_Click(object sender, EventArgs e)
        {

        }
    }
}

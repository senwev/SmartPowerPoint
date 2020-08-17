using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Fleck;
using System.Runtime.CompilerServices;

namespace MouseClick
{

    public partial class Form1 : Form
    {


        //创建套接字  
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private static byte[] result = new byte[512];
        static private Form _mainform;
        static DateTime lasttime = DateTime.Now;
        static bool inprocess = false;

        static volatile bool running = false;

        static int debugMode = 0;//0 for socket

        private static Stopwatch stopwatch = new Stopwatch();

        public static void SocketServie()
        {
            Console.WriteLine("服务端已启动");
            string host = SettingForm.config_Host;//IP地址
            int port = 2000;//端口
            socket.Bind(new IPEndPoint(IPAddress.Parse(host), port));
            //socket.Listen(100);//设定最多100个排队连接请求   
            //Thread myThread = new Thread(ListenClientConnect);//通过多线程监听客户端连接  
            //myThread.Start();
            running = true;
            var task = Task.Factory.StartNew(ListenClientConnect);
            //Console.ReadLine();
            stopwatch.Start();
        }

        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private static void ListenClientConnect()
        {
            while (running)
            {
                //Socket clientSocket = socket.Accept();
                var buffer = new byte[1000];

                EndPoint remote = new IPEndPoint(IPAddress.Any, 0);//用来保存发送方的ip和端口号

                int num = socket.ReceiveFrom(buffer, ref remote);
                


                if (remote != null && num > 0)
                {
                    //clientSocket.Send(Encoding.UTF8.GetBytes("服务器连接成功"));
                    UdpReceiveMessage(buffer.Take(num).ToArray(), num);
                }

                //空出时间周期
                //Thread.Sleep(2);
                //MessageBox.Show("有客户端连接成功！");
                //Thread receiveThread = new Thread(ReceiveMessage);
                //receiveThread.Start(clientSocket);
            }
        }

        /// <summary>
        /// 引用user32.dll动态链接库（windows api），
        /// 使用库中定义 API：SetCursorPos 
        /// </summary>
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);




        /// <summary>
        /// 移动鼠标到指定的坐标点
        /// </summary>
        public void MoveMouseToPoint(Point p)
        {
            SetCursorPos(p.X, p.Y);
        }
        /// <summary>
        /// 设置鼠标的移动范围
        /// </summary>
        public void SetMouseRectangle(Rectangle rectangle)
        {
            System.Windows.Forms.Cursor.Clip = rectangle;
        }
        /// <summary>
        /// 设置鼠标位于屏幕中心
        /// </summary>
        public void SetMouseAtCenterScreen()
        {
            int winHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            int winWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            Point centerP = new Point(winWidth / 2, winHeight / 2);
            MoveMouseToPoint(centerP);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;


        static private float initRotate_X = 0, initRotate_Y = 0, initRotate_Z = 0;

        static private int iskeydown = 0;
        static private int lastiskeydown = 0;

        static int lastX = 0;
        static int lastY = 0;




        static public DateTime last3DOprTime = System.DateTime.Now;

        static public bool shouldBlockShow = false;//是否应该显示黑块（依据Python返回）

        public static long elapsedMs = 0;

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private static void UdpReceiveMessage(byte[] buffer, int length)
        {
            try
            {

                //弹窗提示消息
                string receiveStr1 = Encoding.UTF8.GetString(buffer);
                //string receiveStr1 = Encoding.UTF8.GetString(buffer);


                string[] dataStrs = receiveStr1.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var dataStr in dataStrs)
                {

                    try
                    {
                        //判断语音flag
                        if (dataStr.Length >= 6)
                        {
                            if (dataStr.Substring(0, 6).Equals("voice,"))
                            {
                                var voicestr = dataStr.Substring(6, dataStr.Length - 6);


                                if (voicestr.Contains("水果忍者"))
                                {
                                    ProcessStartInfo info = new ProcessStartInfo();
                                    info.FileName = @"E:\\研究生电子设计大赛\\水果忍者\\水果忍者.exe";
                                    info.Arguments = "";
                                    info.WindowStyle = ProcessWindowStyle.Minimized;
                                    Process pro = Process.Start(info);
                                    //pro.WaitForExit();
                                }
                                else if (voicestr.Contains("请问"))
                                {
                                    if (voicestr.Contains("时间"))
                                    {
                                        Global.toastString = "现在是北京时间：凌晨2点";
                                    }
                                    else if (voicestr.Contains("天气"))
                                    {
                                        Global.toastString = "现在是北京时间：凌晨2点";
                                    }
                                    ToastWindow toastWindow = new ToastWindow();
                                    toastWindow.Show();
                                }
                                else
                                {
                                    //设置到剪贴板
                                    _mainform.Invoke((MethodInvoker)delegate
                                    {
                                        Clipboard.SetText(voicestr);
                                        SendKeys.Send("^{V}");
                                    });
                                }
                                
                                    


                                //MessageBox.Show("粘贴成功:"+voicestr);
                                return;
                            }
                        }

                        if (dataStr.Equals("mouse_on"))
                        {
                            mousePosUpdater.startTrigger();
                        }
                        else if (dataStr.Equals("mouse_off"))
                        {
                            mousePosUpdater.stopTrigger();
                        }
                        else if (dataStr.Equals("eyecare_on"))
                        {
                            _mainform.Invoke((MethodInvoker)delegate
                            {
                                _mainform.Visible = true;
                            });
                                headPosUpdater.startTrigger();
                        }
                        else if (dataStr.Equals("eyecare_off"))
                        {
                            _mainform.Invoke((MethodInvoker)delegate
                            {
                                _mainform.Visible = false;
                            });
                            headPosUpdater.stopTrigger();
                        }
                        else if (dataStr.Equals("3d_on"))
                        {
                            rotateUpdater.startTrigger();
                        }
                        else if (dataStr.Equals("3d_off"))
                        {
                            rotateUpdater.stopTrigger();
                        }


                        String str0 = dataStr.Split(',')[0];
                        String str1 = dataStr.Split(',')[1];
                        String str2 = dataStr.Split(',')[2];

                        if (str0.Equals("ol"))
                        {



                            String str3 = "";
                            String str4 = "";

                            str3 = dataStr.Split(',')[3];

                            str4 = dataStr.Split(',')[4];

                            var thisRX = float.Parse(str1) - initRotate_X;
                            var thisRY = float.Parse(str2) - initRotate_Y;
                            var thisRZ = float.Parse(str3) - initRotate_Z;


                            //rotateUpdater.postValue(new float[] { thisRX + (float)Math.PI / 2f, thisRZ + (float)Math.PI, thisRY });
                            //rotateUpdater.startTrigger();
                            //Global.Viewer3DCamera[0] = thisRZ;
                            //Global.Viewer3DCamera[1] = thisRX;

                            var xx = (float)(thisRX);
                            var yy = (float)(thisRY);
                            var zz = (float)(thisRZ);



                            //这里改代码

                            float act_screenBottomHeight = 0.874f;//投影幕布底部距离地面距离
                            float act_screenLeft = 0.686f;//投影幕布左侧距离坐标原点的水平距离


                            float posX = (float)Global.Position[0];
                            float posY = (float)Global.Position[1];
                            float posZ = (float)Global.Position[2];

                            Global.Viewer3DCamera = new double[] { posX, posY, posZ };


                            float act_screen_width = 2.584f;
                            float act_screen_height = 1.632f;

                            float pix_screen_width = 1920f;
                            float pix_screen_height = 1080f;

                            float act_start_x = posY - act_screenLeft;
                            float act_start_y = posZ - act_screenBottomHeight;


                            float act_screen_distance = posX;//距离屏幕距离

                            float pix_start_x = act_start_x / act_screen_width * pix_screen_width;
                            float pix_start_y = act_start_y / act_screen_height * pix_screen_height;

                            float act_pix_ratio_x = pix_screen_width / act_screen_width;
                            float act_pix_ratio_y = pix_screen_height / act_screen_height;

                            float mul_x = act_screen_distance * act_pix_ratio_x;
                            float mul_y = act_screen_distance * act_pix_ratio_y;

                            int corsorX = (int)Math.Round(pix_start_x - mul_x * Math.Tan(thisRZ));
                            int corsorY = (int)Math.Round(pix_screen_height - pix_start_y - mul_y * Math.Tan(thisRX));

                            //Global.XMovingAverage.Push(corsorX);
                            //Global.YMovingAverage.Push(corsorY);


                            //int realCursorX = (int)Global.XMovingAverage.Current;
                            //int realCursorY = (int)Global.YMovingAverage.Current;

                            mousePosUpdater.postValue(new float[] { (float)corsorX, (float)corsorY });
                            //mousePosUpdater.startTrigger();//开始事件通知

                            if (str4.Equals("1"))
                            {
                                //1代表按下瞬间
                                mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)corsorX, (uint)corsorY, 1, 1);
                            }
                            else if (str4.Equals("2"))
                            {
                                mouse_event(MOUSEEVENTF_LEFTUP, (uint)corsorX, (uint)corsorY, 1, 1);
                            }

                            return;





                        }
                        else if (str0.Equals("ax"))
                        {

                            String str3 = "";
                            String str4 = "";

                            str3 = dataStr.Split(',')[3];

                            str4 = dataStr.Split(',')[4];

                            var thisRX = float.Parse(str1);
                            var thisRY = float.Parse(str2);
                            var thisRZ = float.Parse(str3);
                            var thisRW = float.Parse(str4);

                            //接受轴向角的信息
                            rotateUpdater.postValue(new float[] { thisRX, thisRY, thisRZ, thisRW });

                            return;


                        }
                        else if (str0.Equals("m"))
                        {


                            //String str3 = "";

                            //if (dataStr.Split(',').Length > 3)
                            //    str3 = dataStr.Split(',')[3];


                            ////鼠标移动定位的代码应该就在这里
                            //_mainform.Invoke((MethodInvoker)delegate
                            //{
                            //    if (str3 != "")
                            //    {
                            //        _mainform.Width = Int32.Parse(str3);
                            //        _mainform.Height = Int32.Parse(str3);
                            //    }
                            //    try
                            //    {
                            //        //SetPosition((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height / 2f));

                            //        float mul = 1920f / 1.12f; //这是2.14是距离屏幕的距离


                            //        SetCursorPos((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height / 2f));
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //    }

                            //});

                        }
                        else if (str0.Equals("b"))
                        {
                            //if (Global.shouldShowHideBlock == false)
                            //    return;
                            // EyeCare 接受坐标
                            String str3 = "";

                            if (dataStr.Split(',').Length > 3)
                                str3 = dataStr.Split(',')[3];


                            //post 窗口位置和大小
                            if (str3 != "")
                            {
                                //配置窗口宽度
                                float w = float.Parse(str3);
                                float h = float.Parse(str3);

                                float X = float.Parse(str1);
                                float Y = float.Parse(str2);

                                float thisX = X - w / 2f;
                                float thisY = Y - h / 2f;
                                headPosUpdater.postValue(new float[] { thisX, thisY, float.Parse(str3) });
                                headPosUpdater.startTrigger();//当识别到人就触发窗口更新
                            }


                        }
                        else if (str0.Equals("nb"))
                        {
                            //当未识别到人就隐藏黑块
                            //shouldBlockShow = false;

                            _mainform.Invoke((MethodInvoker)delegate
                            {
                                //_mainform.Visible = false;
                                headPosUpdater.stopTrigger();//当没识别到人就停止出发窗口更新
                            });


                        }
                        else if (str0.Equals("reset"))
                        {
                            //执行校准
                            String str3 = "";
                            String str4 = "";

                            str3 = dataStr.Split(',')[3];

                            str4 = dataStr.Split(',')[4];
                            //initRotate_X = float.Parse(str1);
                            //initRotate_Y = float.Parse(str2);
                            //initRotate_Z = float.Parse(str3);


                            initRotate_X = 0;
                            initRotate_Y = 0;
                            initRotate_Z = float.Parse(str3);

                            if (str4.Equals("1"))
                            {
                                iskeydown = 1;
                            }
                            else
                            {
                                iskeydown = 0;
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        ;
                    }

                }

            }
            catch (Exception ex)
            {
                /*
                Console.WriteLine(ex.Message);

                myClientSocket.Shutdown(SocketShutdown.Both);//禁止发送和上传
                myClientSocket.Close();//关闭Socket并释放资源
                break;*/
            }
            //Thread.Sleep(1);
        }

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 设置屏幕黑块位置
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        static private void SetBlockPosition(int X, int Y)
        {
            var form = _mainform;
            Point point = new Point(X, Y);

            form.Location = point;
        }

        static private void SetPosition(int X, int Y, Form form)
        {
            Point point = new Point(X, Y);

            form.Location = point;


        }

        static private void Set3Dpos(float X, float Y, float Z)
        {
            allSockets[0].Send(String.Concat(X) + "," + String.Concat(Y) + "," + String.Concat(Z) + ";");
        }

        private void setPos(int X, int Y)
        {

        }
        static List<IWebSocketConnection> allSockets = new List<IWebSocketConnection>();

        static SmoothValueHelper mousePosUpdater = new SmoothValueHelper(200, 2);
        static SmoothValueHelper headPosUpdater = new SmoothValueHelper(60, 3);
        static SmoothValueHelper rotateUpdater = new SmoothValueHelper(25, 4);
        private void Form1_Load(object sender, EventArgs e)
        {
            _mainform = this;
            SocketServie();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            allSockets = new List<IWebSocketConnection>();

            FleckLog.Level = LogLevel.Debug;

            //mousePosUpdater = new SmoothValueHelper(200, 2);
            mousePosUpdater.SmoothValueRefreshed += new EventHandler<float[]>(Handler_SmoothValueRefreshed);
            headPosUpdater.SmoothValueRefreshed += new EventHandler<float[]>(Handler_SmoothHeadPosRefreshed);
            rotateUpdater.SmoothValueRefreshed += new EventHandler<float[]>(Handler_SmoothRotateRefreshed);
        }

        private bool inScreenRange(float[] xy)
        {
            if (xy[0] <= 1920 && xy[0] >= 0 && xy[1] <= 1080 && xy[1] >= 0)
            {
                return true;
            }
            return false;
        }





        //下面代码在UI线线程
        private void Handler_SmoothValueRefreshed(object sender, float[] e)
        {

            try
            {

                //模拟鼠标移动
                if (inScreenRange(e))
                {
                    //Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    SetCursorPos((int)(e[0]), (int)(e[1]));
                }

                //Console.WriteLine(e[0].ToString()+","+ e[1].ToString());
            }
            catch (Exception ex)
            {
            }



        }

        //static float x = 0;
        private void Handler_SmoothRotateRefreshed(object sender, float[] e)
        {

            try
            {
                //调用旋转3D模型
                try
                {
                    //Constant.SendViewer3DOrientation(x+=0.01f, 0, 0);
                    Constant.SendViewer3DOrientation(e[0], e[1], e[2],e[3]);
                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {

            }



        }
        private void Handler_SmoothHeadPosRefreshed(object sender, float[] e)
        {

            try
            {
                //移动窗口

                try
                {


                    _mainform.Invoke((MethodInvoker)delegate
                    {
                        //当未识别到人就隐藏黑块

                        //if (_mainform.Visible == false)
                        //    _mainform.Visible = true;

                        _mainform.Width = (int)e[2];
                        _mainform.Height = (int)e[2];

                        _mainform.Visible = true;
                        SetBlockPosition((int)e[0], (int)e[1]);
                    });

                }
                catch (Exception ex)
                {

                }

            }
            catch (Exception ex)
            {
            }



        }

        private void Form1_Shown(object sender, EventArgs e)
        {


            _mainform = this;

            while (false)
            {
                for (int i = 0; i < 1000; i++)
                {
                    SetPosition(100 + i, 600, this);
                    System.Threading.Thread.Sleep(1 * 3);
                }
                for (int i = 0; i < 1000; i++)
                {
                    SetPosition(1100 - i, 600, this);
                    System.Threading.Thread.Sleep(1 * 3);
                }
            }



        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            running = false;
            try
            {
                socket.Close();
                socket.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //设定服务器IP地址  
            IPAddress ip = IPAddress.Parse("222.20.85.12");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 2000)); //配置服务器IP与端口  
                //MessageBox.Show("连接成功！");
                //Console.WriteLine("连接服务器成功");

                string sendMessage = "你好";//发送到服务端的内容
                clientSocket.Send(Encoding.UTF8.GetBytes(sendMessage));//向服务器发送数据，需要发送中文则需要使用Encoding.UTF8.GetBytes()，否则会乱码

            }
            catch
            {
                MessageBox.Show("连接失败！");
                //Console.WriteLine("连接服务器失败，请按回车键退出！");
                return;
            }
        }



    }
}

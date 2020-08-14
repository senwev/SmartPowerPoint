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
                    UdpReceiveMessage(buffer, num);
                }
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
        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private static void ReceiveMessage(object clientSocket)
        {
            Socket myClientSocket = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    //通过clientSocket接收数据  
                    int receiveNumber = myClientSocket.Receive(result);
                    if (receiveNumber == 0)
                        return;

                    //弹窗提示消息
                    String receiveStr1 = Encoding.UTF8.GetString(result, 0, receiveNumber);

                    String[] dataStrs = receiveStr1.Split(';');

                    foreach (var dataStr in dataStrs)
                    {
                        try
                        {
                            String str0 = dataStr.Split(',')[0];
                            String str1 = dataStr.Split(',')[1];
                            String str2 = dataStr.Split(',')[2];

                            if (str0.Equals("m"))
                            {

                                String str3 = "";

                                if (dataStr.Split(',').Length > 3)
                                    str3 = dataStr.Split(',')[3];

                                _mainform.Invoke((MethodInvoker)delegate
                                {
                                    // Running on the UI thread

                                    // SetPosition((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height + 290));

                                    if (str3 != "")
                                    {
                                        _mainform.Width = Int32.Parse(str3);
                                        _mainform.Height = Int32.Parse(str3);
                                    }

                                    try
                                    {
                                        //SetPosition((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height / 2f));
                                        SetCursorPos((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height / 2f));
                                    }
                                    catch (Exception ex)
                                    {
                                    }



                                });

                            }
                            else if (str0.Equals("b"))
                            {
                                String str3 = "";

                                if (dataStr.Split(',').Length > 3)
                                    str3 = dataStr.Split(',')[3];


                                _mainform.Invoke((MethodInvoker)delegate
                                {
                                    // Running on the UI thread


                                    // SetPosition((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height + 290));


                                    if (str3 != "")
                                    {
                                        _mainform.Width = Int32.Parse(str3);
                                        _mainform.Height = Int32.Parse(str3);
                                    }

                                    try
                                    {

                                        int thisX = Int32.Parse(str1);
                                        int thisY = Int32.Parse(str2);
                                        //thisX = (int)(thisX + (thisX - lastX) * 0.9f);
                                        //thisY = (int)(thisY + (thisY - lastY) * 0.9f);


                                        SetPosition((int)(thisX - _mainform.Width / 2f), (int)(thisY - _mainform.Height / 2f));
                                        // SetCursorPos((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height / 2f));
                                        lastX = thisX;
                                        lastY = thisY;
                                    }
                                    catch (Exception ex)
                                    {
                                    }



                                });
                            }
                            else if (str0.Equals("ld"))
                            {
                                uint X = (uint)Cursor.Position.X;
                                uint Y = (uint)Cursor.Position.Y;
                                mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 1, 1);
                            }
                            else if (str0.Equals("lu"))
                            {
                                uint X = (uint)Cursor.Position.X;
                                uint Y = (uint)Cursor.Position.Y;
                                mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 1, 1);
                            }
                            else if (str0.Equals("reset"))
                            {

                                String str3 = "";
                                String str4 = "";

                                str3 = dataStr.Split(',')[3];

                                str4 = dataStr.Split(',')[4];
                                initRotate_X = float.Parse(str1);
                                initRotate_Y = float.Parse(str2);
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
                            else if (str0.Equals("ol"))
                            {


                                if (iskeydown != lastiskeydown)
                                {
                                    uint X = (uint)Cursor.Position.X;
                                    uint Y = (uint)Cursor.Position.Y;
                                    if (iskeydown == 1)
                                        mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 1, 1);
                                    else
                                        mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 1, 1);


                                    lastiskeydown = iskeydown;
                                }




                                String str3 = "";
                                String str4 = "";

                                str3 = dataStr.Split(',')[3];

                                str4 = dataStr.Split(',')[4];

                                var thisRX = float.Parse(str1) - initRotate_X;
                                var thisRY = float.Parse(str2) - initRotate_Y;
                                var thisRZ = float.Parse(str3) - initRotate_Z;


                                var xx = (float)(thisRX);
                                var yy = (float)(thisRY);
                                var zz = (float)(thisRZ);

                                // Set3Dpos(xx, yy, zz);


                                if (str4.Equals("1"))
                                {
                                    iskeydown = 1;
                                }
                                else
                                {
                                    iskeydown = 0;
                                }

                                //2.14是怎么求的？
                                //thisRZ thisRX 是校准后的两轴朝向

                                //float mul = 1920f / 2.14f; //这是2.14是距离屏幕的距离

                                float act_screenBottomHeight = 0.874f;//投影幕布底部距离地面距离
                                float act_screenLeft = 0.686f;//投影幕布左侧距离坐标原点的水平距离


                                float posX = (float)Global.Position[0];
                                float posY = (float)Global.Position[1];
                                float posZ = (float)Global.Position[2];


                                float mul = 1920f / 1.12f; //这是2.14是距离屏幕的距离
                                float act_screen_width = 2.584f;
                                float act_screen_height = 1.632f;

                                float pix_screen_width = 1920f;
                                float pix_screen_height = 1080f;

                                float act_start_x = posY - act_screenLeft;
                                float act_start_y = posZ - act_screenBottomHeight;

                                float pix_start_x = act_start_x / act_screen_width * pix_screen_width;
                                float pix_start_y = act_start_y / act_screen_height * pix_screen_height;

                                int corsorX = (int)Math.Round(960f - mul * Math.Tan(thisRZ));
                                int corsorY = (int)Math.Round(540f - mul * Math.Tan(thisRX));



                                _mainform.Invoke((MethodInvoker)delegate
                                {
                                    // Running on the UI thread


                                    // SetPosition((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height + 290));




                                    try
                                    {
                                        //SetPosition((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height / 2f));


                                        SetCursorPos((int)(corsorX - _mainform.Width / 2f), (int)(corsorY - _mainform.Height / 2f));

                                        /*  uint X = (uint)(corsorX - _mainform.Width / 2f);
                                          uint Y = (uint)(corsorY - _mainform.Height / 2f);

                                          if (iskeydown == 1)
                                              mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 1, 1);
                                          else
                                              mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 1, 1);*/
                                    }
                                    catch (Exception ex)
                                    {
                                    }



                                });

                            }






                        }
                        catch (Exception ex)
                        {
                            ;
                        }



                    }


                    /*
                    String[] receiveStrarr = receiveStr1.Split('\n');
                    String receiveStr = receiveStrarr[receiveStrarr.Length - 2];

                    foreach (var thisstr in receiveStrarr)
                    {
                        if (thisstr != "")
                        {

                            _mainform.Invoke((MethodInvoker)delegate {
                                // Running on the UI thread
                                if (thisstr.Length < 3)
                                {
                                    long num = Int64.Parse(thisstr);
                                    // if (num < 100 && num > 0)
                                    var purenum = num - 23.5f;
                                        SetPosition((int)( (23.5+ purenum*(purenum>0?0.8:1.0))/47f*1920f-_mainform.Width/2.2f), 550);
                                }
                                else
                                {
                                    var a = receiveStr1;
                                }

                            });
                        }
                       

                    }
                    */




                    //SetPosition(1000, 600, _mainform);

                    // SetPosition(100+Int32.Parse(receiveStr)*10, 600,_mainform);

                    //下面是反向传送

                    //代码屏蔽
                    /*
                    Console.WriteLine("接收客户端{0} 的消息：{1}", myClientSocket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(result, 0, receiveNumber));
                    //给Client端返回信息
                    string sendStr = "已成功接到您发送的消息";
                    byte[] bs = Encoding.UTF8.GetBytes(sendStr);//Encoding.UTF8.GetBytes()不然中文会乱码
                    myClientSocket.Send(bs, bs.Length, 0);  //返回信息给客户端
                    myClientSocket.Close(); //发送完数据关闭Socket并释放资源
                    Console.ReadLine();*/
                }
                catch (Exception ex)
                {
                    /*
                    Console.WriteLine(ex.Message);

                    myClientSocket.Shutdown(SocketShutdown.Both);//禁止发送和上传
                    myClientSocket.Close();//关闭Socket并释放资源
                    break;*/
                }
            }
        }

        /// <summary>  
        /// 接收消息  
        /// </summary>  
        /// <param name="clientSocket"></param>  
        private static void UdpReceiveMessage(byte[] buffer, int length)
        {
            try
            {

                //弹窗提示消息
                string receiveStr1 = Encoding.UTF8.GetString(buffer, 0, length);


                string[] dataStrs = receiveStr1.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var dataStr in dataStrs)
                {

                    try
                    {
                        String str0 = dataStr.Split(',')[0];
                        String str1 = dataStr.Split(',')[1];
                        String str2 = dataStr.Split(',')[2];

                        if (str0.Equals("m"))
                        {


                            String str3 = "";

                            if (dataStr.Split(',').Length > 3)
                                str3 = dataStr.Split(',')[3];


                            //鼠标移动定位的代码应该就在这里
                            _mainform.Invoke((MethodInvoker)delegate
                            {
                                if (str3 != "")
                                {
                                    _mainform.Width = Int32.Parse(str3);
                                    _mainform.Height = Int32.Parse(str3);
                                }
                                try
                                {
                                    //SetPosition((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height / 2f));

                                    float mul = 1920f / 1.12f; //这是2.14是距离屏幕的距离


                                    SetCursorPos((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height / 2f));
                                }
                                catch (Exception ex)
                                {
                                }

                            });

                        }
                        else if (str0.Equals("b"))
                        {
                            
                            // EyeCare 接受坐标
                            String str3 = "";

                            if (dataStr.Split(',').Length > 3)
                                str3 = dataStr.Split(',')[3];


                            _mainform.Invoke((MethodInvoker)delegate
                            {
                                // Running on the UI thread

                                if (str3 != "")
                                {
                                    //配置窗口宽度
                                    float w = float.Parse(str3);
                                    float h = float.Parse(str3);

                                    _mainform.Width = (int)w;
                                    _mainform.Height = (int)h;
                                }

                                try
                                {

                                    float X = float.Parse(str1);
                                    float Y = float.Parse(str2)-100;


                                    int thisX = (int)X;
                                    int thisY = (int)Y;

                                    SetPosition((int)(thisX - _mainform.Width / 2f), (int)(thisY - _mainform.Height / 2f));
                                    // SetCursorPos((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height / 2f));
                                    lastX = thisX;
                                    lastY = thisY;
                                }
                                catch (Exception ex)
                                {

                                }

                            });
                        }
                        else if (str0.Equals("ld"))
                        {
                            uint X = (uint)Cursor.Position.X;
                            uint Y = (uint)Cursor.Position.Y;
                            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 1, 1);
                        }
                        else if (str0.Equals("lu"))
                        {
                            uint X = (uint)Cursor.Position.X;
                            uint Y = (uint)Cursor.Position.Y;
                            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 1, 1);
                        }
                        else if (str0.Equals("reset"))
                        {
                            //执行校准
                            String str3 = "";
                            String str4 = "";

                            str3 = dataStr.Split(',')[3];

                            str4 = dataStr.Split(',')[4];
                            initRotate_X = float.Parse(str1);
                            initRotate_Y = float.Parse(str2);
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
                        else if (str0.Equals("ol"))
                        {


                            if (iskeydown != lastiskeydown)
                            {
                                uint X = (uint)Cursor.Position.X;
                                uint Y = (uint)Cursor.Position.Y;
                                if (iskeydown == 1)
                                    mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 1, 1);
                                else
                                    mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 1, 1);


                                lastiskeydown = iskeydown;
                            }

                            String str3 = "";
                            String str4 = "";

                            str3 = dataStr.Split(',')[3];

                            str4 = dataStr.Split(',')[4];

                            var thisRX = float.Parse(str1) - initRotate_X;
                            var thisRY = float.Parse(str2) - initRotate_Y;
                            var thisRZ = float.Parse(str3) - initRotate_Z;


                            var xx = (float)(thisRX);
                            var yy = (float)(thisRY);
                            var zz = (float)(thisRZ);

                            // Set3Dpos(xx, yy, zz);


                            if (str4.Equals("1"))
                            {
                                iskeydown = 1;
                            }
                            else
                            {
                                iskeydown = 0;
                            }



                            //这里改代码

                            float act_screenBottomHeight = 0.874f;//投影幕布底部距离地面距离
                            float act_screenLeft = 0.686f;//投影幕布左侧距离坐标原点的水平距离


                            float posX = (float)Global.Position[0];
                            float posY = (float)Global.Position[1];
                            float posZ = (float)Global.Position[2];


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

                            Global.XMovingAverage.Push(corsorX);
                            Global.YMovingAverage.Push(corsorY);

                            _mainform.Invoke((MethodInvoker)delegate
                            {

                                try
                                {
                                    //SetPosition((int)(Int32.Parse(str1) - _mainform.Width / 2f), (int)(Int32.Parse(str2) - _mainform.Height / 2f));
                                    int realCursorX = (int)Global.XMovingAverage.Current;
                                    int realCursorY = (int)Global.YMovingAverage.Current;

                                    //SetCursorPos((int)(corsorX - _mainform.Width / 2f), (int)(corsorY - _mainform.Height / 2f));
                                    SetCursorPos((int)(realCursorX), (int)(realCursorY));
                                    /*  uint X = (uint)(corsorX - _mainform.Width / 2f);
                                      uint Y = (uint)(corsorY - _mainform.Height / 2f);

                                      if (iskeydown == 1)
                                          mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 1, 1);
                                      else
                                          mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 1, 1);*/
                                }
                                catch (Exception ex)
                                {
                                }

                            });

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
        static private void SetPosition(int X, int Y)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            _mainform = this;
            SocketServie();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            allSockets = new List<IWebSocketConnection>();

            FleckLog.Level = LogLevel.Debug;

            var server = new WebSocketServer("ws://0.0.0.0:5000");

            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");

                    socket.Send("success");

                    allSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("Close!");
                    allSockets.Remove(socket);
                };
                socket.OnMessage = message =>
                {
                    Console.WriteLine(message);
                    allSockets.ToList().ForEach(s => s.Send("Echo: " + message));
                };
            });


            //SendKeys.Send("{ENTER}");
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

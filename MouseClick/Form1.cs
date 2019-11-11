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

namespace MouseClick
{

    public partial class Form1 : Form
    {

        
        //创建套接字  
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] result = new byte[1024];
        static private Form _mainform;
        static DateTime lasttime = DateTime.Now;
        static bool inprocess = false;

        public static void SocketServie()
        {
            Console.WriteLine("服务端已启动");
            string host = "222.20.85.12";//IP地址
            int port = 2000;//端口
            socket.Bind(new IPEndPoint(IPAddress.Parse(host), port));
            socket.Listen(100);//设定最多100个排队连接请求   
            Thread myThread = new Thread(ListenClientConnect);//通过多线程监听客户端连接  
            myThread.Start();
            Console.ReadLine();
        }

        /// <summary>  
        /// 监听客户端连接  
        /// </summary>  
        private static void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = socket.Accept();
                //clientSocket.Send(Encoding.UTF8.GetBytes("服务器连接成功"));


               // MessageBox.Show("有客服端连接成功！");
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }




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

                            String str1 = dataStr.Split(',')[0];
                            String str2 = dataStr.Split(',')[1];



                            _mainform.Invoke((MethodInvoker)delegate
                            {
                                // Running on the UI thread


                                SetPosition((int)(Int32.Parse(str1)-_mainform.Width/2f), (int)(Int32.Parse(str2) - _mainform.Height+290 ));


                            });

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




        public Form1()
        {
            InitializeComponent();
        }

        static private void SetPosition(int X, int Y)
        {
                var form = _mainform;
                Point point = new Point(X, Y);

                form.Location = point;
            
            
        }

        static private void SetPosition(int X, int Y,Form form)
        {
            Point point = new Point(X, Y);

            form.Location = point;


        }


        private void setPos(int X, int Y)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _mainform = this;
            SocketServie();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            
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

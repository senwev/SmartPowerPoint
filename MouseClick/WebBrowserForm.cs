using Fleck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebKit;

namespace MouseClick
{
    public partial class WebBrowserForm : Form
    {
        public WebBrowserForm()
        {
          /* WebKit.WebKitBrowser browser = new WebKitBrowser();
           browser.Dock = DockStyle.Fill;
           this.Controls.Add(browser);
           browser.Navigate("http://localhost:8080/chuangma/apple/my_standard.html");*/

            InitializeComponent();
        }

        private void CallsetPosition(float rx,float ry,float rz)
        {
            Uri uri = new Uri("javascript:global_x = "+String.Concat(rx)+ ";global_y = " + String.Concat(ry) + ";global_z = " + String.Concat(rz) + ";");
            webBrowser1.Url = uri;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            

        }







        private void WebBrowserForm_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;

            FleckLog.Level = LogLevel.Debug;
            var allSockets = new List<IWebSocketConnection>();
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
            

        }

        private void buttontest_Click(object sender, EventArgs e)
        {
            CallsetPosition(10,10,10);
        }
    }
}

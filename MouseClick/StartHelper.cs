using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClick
{

    //辅助开关APP
    class StartHelper
    {

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void OpenGame()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"E:\\研究生电子设计大赛\\水果忍者old\\水果忍者.exe";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process shuiguorenzhe = Process.Start(info);
            SetForegroundWindow(shuiguorenzhe.MainWindowHandle);
            //pro.WaitForExit();
        }

        internal static void CloseGame(Form form)
        {
            //设置到剪贴板
            form.Invoke((MethodInvoker)delegate
            {

                SendKeys.Send("%{F4}");
            });
        }

        public static void KeyEnter(Form form)
        {
            //设置到剪贴板
            form.Invoke((MethodInvoker)delegate
            {

                SendKeys.Send("{ENTER}");
            });
        }

        public static void KeySave(Form form)
        {
            form.Invoke((MethodInvoker)delegate
            {
                SendKeys.Send("^s");
            });
        }

        public static void KeyToPaint(Form form)
        {
            form.Invoke((MethodInvoker)delegate
            {
                SendKeys.Send("^p");
            });
        }
        public static void KeyToLaser(Form form)
        {
            form.Invoke((MethodInvoker)delegate
            {
                SendKeys.Send("^l");
            });
        }
        public static void KeyPlayPPT(Form form)
        {
            //设置到剪贴板
            form.Invoke((MethodInvoker)delegate
            {
                SendKeys.Send("+{F5}");
            });
        }
        public static void KeyLeft(Form form)
        {
            //设置到剪贴板
            form.Invoke((MethodInvoker)delegate
            {
                SendKeys.Send("{LEFT}");
            });
        }
        public static void KeyRight(Form form)
        {
            //设置到剪贴板
            form.Invoke((MethodInvoker)delegate
            {
                SendKeys.Send("{RIGHT}");
            });
        }

        public static void OpenNote()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"C:\\Users\\Administrator\\Desktop\\演示记事本.txt";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process shuiguorenzhe = Process.Start(info);
            SetForegroundWindow(shuiguorenzhe.MainWindowHandle);
            //pro.WaitForExit();
        }

        public static void PlayVideo()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"C:\\Users\\Administrator\\Desktop\\智影互动宣传视频.mp4";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process shuiguorenzhe = Process.Start(info);
            //SetForegroundWindow(shuiguorenzhe.MainWindowHandle);
            //pro.WaitForExit();
        }
        public static void OpenOffice()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = @"C:\\Users\\Administrator\\Desktop\\演示PPT.pptx";
            info.Arguments = "";
            info.WindowStyle = ProcessWindowStyle.Normal;
            Process shuiguorenzhe = Process.Start(info);
            SetForegroundWindow(shuiguorenzhe.MainWindowHandle);
            //pro.WaitForExit();
        }


        static Viewer3D viewer3D;


        public static void Open3DView()
        {
            viewer3D = new Viewer3D();
            var directory = Environment.CurrentDirectory;
            var fileName = System.IO.Path.Combine(directory, "Resources/Coronavirus_obj/covid19.obj");
            viewer3D.Show();
            if (System.IO.File.Exists(fileName))
            {
                viewer3D.OpenFile(fileName);
            }
        }

        public static void Close3DView()
        {
            viewer3D?.Close();
            viewer3D?.Dispose();
        }
    }
}

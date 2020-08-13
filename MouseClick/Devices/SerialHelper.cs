using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Data;
using MouseClick.Solvers;
using System.Windows.Forms;

namespace MouseClick.Devices
{
    public class SerialHelper
    {
        public SerialPort ComPort
        {
            get; private set;
        }

        public IList<SerialDeviceProperty> Devices { get; private set; }

        private List<byte> buffer;

        public bool ComPortIsOpen { get; private set; }

        public bool recStaus { get; private set; }

        public bool IsHex { get; set; }

        public event EventHandler SerialLostEvent;

        public event EventHandler<string> SerialDataReceived;

        private StringBuilder recStringBuilder;

        private UWBPositionSolver3D solver3D;
        private UWBPositionSolver2D solver2D;

        private double refHeight = 1210;

        public double tolerance = 0.25;

        public SerialHelper()
        {
            this.Devices = new List<SerialDeviceProperty>();
            this.buffer = new List<byte>();


            //var anchor1 = new Tuple<double, double, double>(1, 0, 0);
            //var anchor0 = new Tuple<double, double, double>(1800, 0, 1);
            //var anchor2 = new Tuple<double, double, double>(1, 4200, 0);
            //var anchor3 = new Tuple<double, double, double>(1800, 4200, 0);
            //var coff_A = 1;
            //var coff_B = 0;
            //var list = new List<Tuple<double, double, double>>();
            //list.Add(anchor0);
            //list.Add(anchor1);
            //list.Add(anchor2);
            //list.Add(anchor3);

            //solver3D = new UWBPositionSolver3D(list, coff_A, coff_B);
            //x vertical
            var anchor0 = new Tuple<double, double>(1800, 0);
            var anchor1 = new Tuple<double, double>(0, 0);
            var anchor2 = new Tuple<double, double>(0, 4200);
            var anchor3 = new Tuple<double, double>(1800, 4200);
            //y vertical
            //var anchor0 = new Tuple<double, double>(0, 1800);
            //var anchor1 = new Tuple<double, double>(0, 0);
            //var anchor2 = new Tuple<double, double>(4200, 0);
            //var anchor3 = new Tuple<double, double>(4200, 1800);
            //var anchor0 = new Tuple<double, double>(2000, 200);
            //var anchor1 = new Tuple<double, double>(200, 200);
            //var anchor2 = new Tuple<double, double>(200, 4400);
            //var anchor3 = new Tuple<double, double>(2000, 4400);
            //var anchor0 = new Tuple<double, double>(1160, 0);
            //var anchor1 = new Tuple<double, double>(0, 0);
            //var anchor2 = new Tuple<double, double>(0, 1960);
            //var anchor3 = new Tuple<double, double>(1160, 1960);
            var coff_A = 1;
            var coff_B = 0;
            var list = new List<Tuple<double, double>>();
            list.Add(anchor0);
            list.Add(anchor1);
            list.Add(anchor2);
            list.Add(anchor3);

            solver2D = new UWBPositionSolver2D(list, coff_A, coff_B);
            Constant.DrawingHelper.Update(anchor0, anchor1, anchor2, anchor3);
        }

        private void OnComReceive(object sender, SerialDataReceivedEventArgs e)//接收数据 中断只标志有数据需要读取，读取操作在中断外进行
        {
            if (recStaus)
            {
                try
                {
                    var recBuffer = new byte[ComPort.BytesToRead];
                    ComPort.Read(recBuffer, 0, recBuffer.Length);
                    ComRec(recBuffer);
                }
                catch (Exception ex)
                {
                    if (ComPort.IsOpen == false)
                    {
                        SerialLostEvent?.Invoke(this, new EventArgs());
                    }
                }
            }
            else
            {
                ComPort.DiscardInBuffer();
            }
        }

        void ComRec(byte[] data)
        {
            int length = this.recStringBuilder.Length;
            int idx = 0;
            if (data == null) { return; }
            var datas = SerialProtocolParseHelper.Parse(data);
            Console.WriteLine(string.Join(",", datas) + "\r\n");

            var ds = solver2D.Update(datas.Select<long, double>(x => x).ToList());
            //var ds = solver3D.Update(datas.Select<long, double>(x => x).ToList());
            Console.WriteLine(string.Join(",", ds) + "\r\n");
            if (Math.Abs(Global.Position[0] - ds[0] / 1000) > tolerance)
            {
                Global.Position[0] = ds[0] / 1000;
                Constant.DrawingHelper.Update(ds.ToArray());
            }
            if (Math.Abs(Global.Position[1] - ds[1] / 1000) > tolerance)
            {
                Global.Position[1] = ds[1] / 1000;
                Constant.DrawingHelper.Update(ds.ToArray());
            }
            Global.Position[2] = refHeight / 1000;
  
            SerialDataReceived?.Invoke(this, string.Join(",", ds) + "\r\n");
        }



        public IList<SerialDeviceProperty> GetPorts()
        {
            this.Devices.Clear();
            var ports = SerialPort.GetPortNames();
            if (ports != null && ports.Length > 0)
            {
                for (int i = 0; i < ports.Length; i++)
                {
                    this.Devices.Add(new SerialDeviceProperty() { Com = ports[i] });
                }
            }
            return this.Devices;
        }

        public void Open(string com, int baudRate, int parity, int dataBits, double stopBits)
        {
            this.ComPort = new SerialPort();
            this.ComPort.PortName = com;//设置要打开的串口
            this.ComPort.BaudRate = baudRate;//设置当前波特率
            this.ComPort.Parity = (Parity)parity; //设置当前校验位
            this.ComPort.DataBits = dataBits;//设置当前数据位
            this.ComPort.StopBits = (StopBits)stopBits;//设置当前停止位                    
            this.ComPort.Open();//打开串口
            this.ComPortIsOpen = true;//串口打开状态字改为true
        }

        public void Close()
        {
            try
            {
                this.ComPort.DiscardOutBuffer();//清发送缓存
                this.ComPort.DiscardInBuffer();//清接收缓存
                this.ComPort.Close();
                this.ComPort.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                this.ComPortIsOpen = false;//串口打开状态字改为true
            }
        }

        public void StartReceiving()
        {
            this.recStringBuilder = new StringBuilder();
            this.ComPort.DataReceived += new SerialDataReceivedEventHandler(OnComReceive);
            this.recStaus = true;
        }

        public void StopReceiving()
        {
            try
            {
                this.recStaus = false;
                this.ComPort.DiscardInBuffer();
                this.ComPort.DiscardOutBuffer();
                this.ComPort.DataReceived -= new SerialDataReceivedEventHandler(OnComReceive);
            }
            catch (Exception ex)
            {

            }
        }

    }

    public class SerialDeviceProperty
    {
        public string Com { get; set; }//可用串口名
        public string BaudRate { get; set; }//波特率
        public string Parity { get; set; }//校验位
        public string ParityValue { get; set; }//校验位对应值
        public string Dbits { get; set; }//数据位
        public string Sbits { get; set; }//停止位
        public string SbitsValue { get; set; }//停止位
    }
}

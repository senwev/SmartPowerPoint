using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Threading;
using System.Data;

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

        public SerialHelper()
        {
            this.Devices = new List<SerialDeviceProperty>();
            this.buffer = new List<byte>();
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
            Console.WriteLine(string.Join(",", datas));

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
            this.recStaus = false;
            this.ComPort.DiscardInBuffer();
            this.ComPort.DiscardOutBuffer();
            this.ComPort.DataReceived -= new SerialDataReceivedEventHandler(OnComReceive);
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

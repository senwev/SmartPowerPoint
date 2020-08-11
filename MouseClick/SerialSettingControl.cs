using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MouseClick
{
    using Devices;
    using System.IO.Ports;

    public partial class SerialSettingControl : UserControl
    {
        public SerialSettingControl()
        {
            InitializeComponent();
            this.helper = Constant.SerialHelper;
            helper.SerialDataReceived += new EventHandler<string>(Handle_DataReceived);

            if (!helper.ComPortIsOpen)
            {
                this.button_OpenSerial.Enabled = true;
                this.button_CloseSerial.Enabled = false;
                this.button_Reset.Enabled = true;
                UpdateControl();
            }
            else
            {
                this.button_OpenSerial.Enabled = false;
                this.button_CloseSerial.Enabled = true;
                this.button_Reset.Enabled = false;
            }
        }

        public SerialHelper helper;

        private void UpdateControl()
        {
            var ports = helper.GetPorts();
            if (ports.Count > 0)//ports.Length > 0说明有串口可用
            {
                comboBox_AvailableCom.Items.Clear();
                comboBox_AvailableCom.DataSource = ports;
                comboBox_AvailableCom.DisplayMember = "Com";//显示路径
                comboBox_AvailableCom.ValueMember = "Com";//显示路径
                comboBox_AvailableCom.SelectedItem = ports[0];//默认选第1个串口
            }
            //↑↑↑↑↑↑↑↑↑可用串口下拉控件↑↑↑↑↑↑↑↑↑

            //↓↓↓↓↓↓↓↓↓波特率下拉控件↓↓↓↓↓↓↓↓↓
            IList<SerialDeviceProperty> rateList = new List<SerialDeviceProperty>();//可用波特率集合
            rateList.Add(new SerialDeviceProperty() { BaudRate = "1200" });
            rateList.Add(new SerialDeviceProperty() { BaudRate = "2400" });
            rateList.Add(new SerialDeviceProperty() { BaudRate = "4800" });
            rateList.Add(new SerialDeviceProperty() { BaudRate = "9600" });
            rateList.Add(new SerialDeviceProperty() { BaudRate = "14400" });
            rateList.Add(new SerialDeviceProperty() { BaudRate = "19200" });
            rateList.Add(new SerialDeviceProperty() { BaudRate = "28800" });
            rateList.Add(new SerialDeviceProperty() { BaudRate = "38400" });
            rateList.Add(new SerialDeviceProperty() { BaudRate = "57600" });
            rateList.Add(new SerialDeviceProperty() { BaudRate = "115200" });
            comboBox_Rate.DataSource = rateList;
            comboBox_Rate.DisplayMember = "BaudRate";
            comboBox_Rate.ValueMember = "BaudRate";
            comboBox_Rate.SelectedItem = rateList[0];
            //↑↑↑↑↑↑↑↑↑波特率下拉控件↑↑↑↑↑↑↑↑↑

            //↓↓↓↓↓↓↓↓↓校验位下拉控件↓↓↓↓↓↓↓↓↓
            IList<SerialDeviceProperty> comParity = new List<SerialDeviceProperty>();//可用校验位集合
            comParity.Add(new SerialDeviceProperty() { Parity = "None", ParityValue = "0" });
            comParity.Add(new SerialDeviceProperty() { Parity = "Odd", ParityValue = "1" });
            comParity.Add(new SerialDeviceProperty() { Parity = "Even", ParityValue = "2" });
            comParity.Add(new SerialDeviceProperty() { Parity = "Mark", ParityValue = "3" });
            comParity.Add(new SerialDeviceProperty() { Parity = "Space", ParityValue = "4" });
            comboBox_ParityCom.DataSource = comParity;
            comboBox_ParityCom.DisplayMember = "Parity";
            comboBox_ParityCom.ValueMember = "ParityValue";
            comboBox_ParityCom.SelectedItem = comParity[0];
            //↑↑↑↑↑↑↑↑↑校验位下拉控件↑↑↑↑↑↑↑↑↑

            //↓↓↓↓↓↓↓↓↓数据位下拉控件↓↓↓↓↓↓↓↓↓
            IList<SerialDeviceProperty> dataBits = new List<SerialDeviceProperty>();//数据位集合
            dataBits.Add(new SerialDeviceProperty() { Dbits = "8" });
            dataBits.Add(new SerialDeviceProperty() { Dbits = "7" });
            dataBits.Add(new SerialDeviceProperty() { Dbits = "6" });

            comboBox_DataBits.DataSource = dataBits.ToArray();
            comboBox_DataBits.DisplayMember = "Dbits";
            comboBox_DataBits.ValueMember = "Dbits";
            comboBox_DataBits.SelectedItem = dataBits[0];
            //↑↑↑↑↑↑↑↑↑数据位下拉控件↑↑↑↑↑↑↑↑↑

            //↓↓↓↓↓↓↓↓↓停止位下拉控件↓↓↓↓↓↓↓↓↓
            IList<SerialDeviceProperty> stopBits = new List<SerialDeviceProperty>();//停止位集合
            stopBits.Add(new SerialDeviceProperty() { Sbits = "1", SbitsValue = "1" });
            stopBits.Add(new SerialDeviceProperty() { Sbits = "1.5", SbitsValue = "3" });
            stopBits.Add(new SerialDeviceProperty() { Sbits = "2", SbitsValue = "2" });
            comboBox_StopBits.DataSource = stopBits.ToArray();
            comboBox_StopBits.DisplayMember = "Sbits";
            comboBox_StopBits.ValueMember = "SbitsValue";
            comboBox_StopBits.SelectedItem = stopBits[0];
            //↑↑↑↑↑↑↑↑↑停止位下拉控件↑↑↑↑↑↑↑↑↑

            //↓↓↓↓↓↓↓↓↓默认设置↓↓↓↓↓↓↓↓↓
            comboBox_Rate.SelectedValue = "9600";//波特率默认设置9600
            comboBox_ParityCom.SelectedValue = "0";//校验位默认设置值为0，对应NONE
            comboBox_DataBits.SelectedValue = "8";//数据位默认设置8位
            comboBox_StopBits.SelectedValue = "1";//停止位默认设置1

        }

        private void SetAfterClose()//成功关闭串口或串口丢失后的设置
        {
            button_Reset.Enabled = true;//打开串口后使能重置功能
            button_OpenSerial.Enabled = true;
            button_CloseSerial.Enabled = false;
            comboBox_AvailableCom.Enabled = true;//使能可用串口控件
            comboBox_Rate.Enabled = true;//使能可用波特率下拉控件
            comboBox_ParityCom.Enabled = true;//使能可用校验位下拉控件
            comboBox_DataBits.Enabled = true;//使能数据位下拉控件
            comboBox_StopBits.Enabled = true;//使能停止位下拉控件
        }

        private void SetComLose()//成功关闭串口或串口丢失后的设置
        {
            UpdateControl();
            SetAfterClose();//成功关闭串口或串口丢失后的设置
        }

        private void Handle_DataReceived(object sender, string Msg)
        {
            //SetMsgText(Msg);
            if (this.textBox_Rec.InvokeRequired)
            {
                var d = new SetMsgHandler(SetMsgText);
                this.Invoke(d, new object[] { Msg });
            }
            else
            {
                this.textBox_Rec.Text = Msg;
            }
        }
        private delegate void SetMsgHandler(string msg);
        private void SetMsgText(string msg)
        {
            this.textBox_Rec.Text += msg;
        }

        private void button_OpenSerial_Click(object sender, EventArgs e)
        {
            if (comboBox_AvailableCom.SelectedValue == null)//先判断是否有可用串口
            {
                MessageBox.Show("无可用串口，无法打开!", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;//没有串口，提示后直接返回
            }

            if (helper.ComPortIsOpen == false)
            {
                try//尝试打开串口
                {
                    var portName = comboBox_AvailableCom.SelectedValue.ToString();//设置要打开的串口
                    var baudRate = Convert.ToInt32(comboBox_Rate.SelectedValue);//设置当前波特率
                    var parity = Convert.ToInt32(comboBox_ParityCom.SelectedValue);//设置当前校验位
                    var dataBits = Convert.ToInt32(comboBox_DataBits.SelectedValue);//设置当前数据位
                    var stopBits = Convert.ToDouble(comboBox_StopBits.SelectedValue);//设置当前停止位                    
                    helper.Open(portName, baudRate, parity, dataBits, stopBits);

                }
                catch//如果串口被其他占用，则无法打开
                {
                    MessageBox.Show("无法打开串口,请检测此串口是否有效或被其他占用！", "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    helper.GetPorts();//刷新当前可用串口
                    return;//无法打开串口，提示后直接返回
                }

                //↓↓↓↓↓↓↓↓↓成功打开串口后的设置↓↓↓↓↓↓↓↓↓
                button_OpenSerial.Enabled = false;
                button_CloseSerial.Enabled = true;
                button_Reset.Enabled = false;//打开串口后失能重置功能
                comboBox_AvailableCom.Enabled = false;//失能可用串口控件
                comboBox_Rate.Enabled = false;//失能可用波特率控件
                comboBox_ParityCom.Enabled = false;//失能可用校验位控件
                comboBox_DataBits.Enabled = false;//失能可用数据位控件
                comboBox_StopBits.Enabled = false;//失能可用停止位控件
                //↑↑↑↑↑↑↑↑↑成功打开串口后的设置↑↑↑↑↑↑↑↑↑
            }

        }

        private void button_CloseSerial_Click(object sender, EventArgs e)
        {
            if (!helper.ComPortIsOpen) return;
            try//尝试关闭串口
            {
                helper.Close();

                SetAfterClose();//成功关闭串口或串口丢失后的设置
            }
            catch//如果在未关闭串口前，串口就已丢失，这时关闭串口会出现异常
            {
                if (helper.ComPort.IsOpen == false)//判断当前串口状态，如果ComPort.IsOpen==false，说明串口已丢失
                {
                    SetComLose();
                }
            }
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            comboBox_Rate.SelectedValue = "9600";//波特率默认设置9600
            comboBox_ParityCom.SelectedValue = "0";//校验位默认设置值为0，对应NONE
            comboBox_DataBits.SelectedValue = "8";//数据位默认设置8位
            comboBox_StopBits.SelectedValue = "1";//停止位默认设置1
        }

        private void comboBox_AvailableCom_Click(object sender, EventArgs e)
        {
            comboBox_AvailableCom.DataSource = null;
            var list = helper.GetPorts();
            comboBox_AvailableCom.DataSource = list;
            comboBox_AvailableCom.DisplayMember = "Com";//可用串口下拉控件显示路径
        }

        private void button_StartOrStopReceive_Click(object sender, EventArgs e)
        {
            if (helper.recStaus == true)//当前为开启接收状态
            {
                helper.StopReceiving();
                button_StartOrStopReceive.Text = "开启接收";//按钮显示为开启接收
            }
            else//当前状态为关闭接收状态
            {
                helper.StartReceiving();
                button_StartOrStopReceive.Text = "暂停接收";//按钮显示状态改为暂停接收
            }
        }

        private void checkBox_IsHex_CheckedChanged(object sender, EventArgs e)
        {
            helper.IsHex = checkBox_IsHex.Checked;
        }

    }
}

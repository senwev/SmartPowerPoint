namespace MouseClick
{
    partial class SerialSettingControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_AvailableCom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_IsHex = new System.Windows.Forms.CheckBox();
            this.comboBox_Rate = new System.Windows.Forms.ComboBox();
            this.comboBox_ParityCom = new System.Windows.Forms.ComboBox();
            this.comboBox_DataBits = new System.Windows.Forms.ComboBox();
            this.comboBox_StopBits = new System.Windows.Forms.ComboBox();
            this.button_OpenSerial = new System.Windows.Forms.Button();
            this.button_CloseSerial = new System.Windows.Forms.Button();
            this.button_Reset = new System.Windows.Forms.Button();
            this.button_StartOrStopReceive = new System.Windows.Forms.Button();
            this.textBox_Rec = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号：";
            // 
            // comboBox_AvailableCom
            // 
            this.comboBox_AvailableCom.FormattingEnabled = true;
            this.comboBox_AvailableCom.Location = new System.Drawing.Point(106, 30);
            this.comboBox_AvailableCom.Name = "comboBox_AvailableCom";
            this.comboBox_AvailableCom.Size = new System.Drawing.Size(200, 20);
            this.comboBox_AvailableCom.TabIndex = 1;
            this.comboBox_AvailableCom.Click += new System.EventHandler(this.comboBox_AvailableCom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "校验位：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "数据位：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "停止位：";
            // 
            // checkBox_IsHex
            // 
            this.checkBox_IsHex.AutoSize = true;
            this.checkBox_IsHex.Location = new System.Drawing.Point(49, 249);
            this.checkBox_IsHex.Name = "checkBox_IsHex";
            this.checkBox_IsHex.Size = new System.Drawing.Size(84, 16);
            this.checkBox_IsHex.TabIndex = 6;
            this.checkBox_IsHex.Text = "16进制接收";
            this.checkBox_IsHex.UseVisualStyleBackColor = true;
            this.checkBox_IsHex.CheckedChanged += new System.EventHandler(this.checkBox_IsHex_CheckedChanged);
            // 
            // comboBox_Rate
            // 
            this.comboBox_Rate.FormattingEnabled = true;
            this.comboBox_Rate.Location = new System.Drawing.Point(106, 73);
            this.comboBox_Rate.Name = "comboBox_Rate";
            this.comboBox_Rate.Size = new System.Drawing.Size(200, 20);
            this.comboBox_Rate.TabIndex = 7;
            // 
            // comboBox_ParityCom
            // 
            this.comboBox_ParityCom.FormattingEnabled = true;
            this.comboBox_ParityCom.Location = new System.Drawing.Point(106, 116);
            this.comboBox_ParityCom.Name = "comboBox_ParityCom";
            this.comboBox_ParityCom.Size = new System.Drawing.Size(200, 20);
            this.comboBox_ParityCom.TabIndex = 8;
            // 
            // comboBox_DataBits
            // 
            this.comboBox_DataBits.FormattingEnabled = true;
            this.comboBox_DataBits.Location = new System.Drawing.Point(106, 159);
            this.comboBox_DataBits.Name = "comboBox_DataBits";
            this.comboBox_DataBits.Size = new System.Drawing.Size(200, 20);
            this.comboBox_DataBits.TabIndex = 9;
            // 
            // comboBox_StopBits
            // 
            this.comboBox_StopBits.FormattingEnabled = true;
            this.comboBox_StopBits.Location = new System.Drawing.Point(106, 202);
            this.comboBox_StopBits.Name = "comboBox_StopBits";
            this.comboBox_StopBits.Size = new System.Drawing.Size(200, 20);
            this.comboBox_StopBits.TabIndex = 10;
            // 
            // button_OpenSerial
            // 
            this.button_OpenSerial.Location = new System.Drawing.Point(68, 289);
            this.button_OpenSerial.Name = "button_OpenSerial";
            this.button_OpenSerial.Size = new System.Drawing.Size(75, 23);
            this.button_OpenSerial.TabIndex = 11;
            this.button_OpenSerial.Text = "打开串口";
            this.button_OpenSerial.UseVisualStyleBackColor = true;
            this.button_OpenSerial.Click += new System.EventHandler(this.button_OpenSerial_Click);
            // 
            // button_CloseSerial
            // 
            this.button_CloseSerial.Location = new System.Drawing.Point(149, 289);
            this.button_CloseSerial.Name = "button_CloseSerial";
            this.button_CloseSerial.Size = new System.Drawing.Size(75, 23);
            this.button_CloseSerial.TabIndex = 12;
            this.button_CloseSerial.Text = "关闭串口";
            this.button_CloseSerial.UseVisualStyleBackColor = true;
            this.button_CloseSerial.Click += new System.EventHandler(this.button_CloseSerial_Click);
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(231, 246);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(75, 23);
            this.button_Reset.TabIndex = 13;
            this.button_Reset.Text = "重置";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // button_StartOrStopReceive
            // 
            this.button_StartOrStopReceive.Location = new System.Drawing.Point(231, 289);
            this.button_StartOrStopReceive.Name = "button_StartOrStopReceive";
            this.button_StartOrStopReceive.Size = new System.Drawing.Size(75, 23);
            this.button_StartOrStopReceive.TabIndex = 14;
            this.button_StartOrStopReceive.Text = "开启接收";
            this.button_StartOrStopReceive.UseVisualStyleBackColor = true;
            this.button_StartOrStopReceive.Click += new System.EventHandler(this.button_StartOrStopReceive_Click);
            // 
            // textBox_Rec
            // 
            this.textBox_Rec.AcceptsReturn = true;
            this.textBox_Rec.Location = new System.Drawing.Point(49, 346);
            this.textBox_Rec.Multiline = true;
            this.textBox_Rec.Name = "textBox_Rec";
            this.textBox_Rec.Size = new System.Drawing.Size(257, 111);
            this.textBox_Rec.TabIndex = 15;
            // 
            // SerialSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_Rec);
            this.Controls.Add(this.button_StartOrStopReceive);
            this.Controls.Add(this.button_Reset);
            this.Controls.Add(this.button_CloseSerial);
            this.Controls.Add(this.button_OpenSerial);
            this.Controls.Add(this.comboBox_StopBits);
            this.Controls.Add(this.comboBox_DataBits);
            this.Controls.Add(this.comboBox_ParityCom);
            this.Controls.Add(this.comboBox_Rate);
            this.Controls.Add(this.checkBox_IsHex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_AvailableCom);
            this.Controls.Add(this.label1);
            this.Name = "SerialSettingControl";
            this.Size = new System.Drawing.Size(365, 483);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_AvailableCom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_IsHex;
        private System.Windows.Forms.ComboBox comboBox_Rate;
        private System.Windows.Forms.ComboBox comboBox_ParityCom;
        private System.Windows.Forms.ComboBox comboBox_DataBits;
        private System.Windows.Forms.ComboBox comboBox_StopBits;
        private System.Windows.Forms.Button button_OpenSerial;
        private System.Windows.Forms.Button button_CloseSerial;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.Button button_StartOrStopReceive;
        private System.Windows.Forms.TextBox textBox_Rec;
    }
}

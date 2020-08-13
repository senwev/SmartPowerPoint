namespace MouseClick
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            } 
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.开启遮挡 = new System.Windows.Forms.Button();
            this.IptextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.serialSettingControl1 = new MouseClick.SerialSettingControl();
            this.uwbPositionSettingControl1 = new MouseClick.UWBPositionSettingControl();
            this.SuspendLayout();
            // 
            // 开启遮挡
            // 
            this.开启遮挡.Location = new System.Drawing.Point(410, 82);
            this.开启遮挡.Name = "开启遮挡";
            this.开启遮挡.Size = new System.Drawing.Size(75, 23);
            this.开启遮挡.TabIndex = 0;
            this.开启遮挡.Text = "开启遮挡";
            this.开启遮挡.UseVisualStyleBackColor = true;
            this.开启遮挡.Click += new System.EventHandler(this.开启遮挡_Click);
            // 
            // IptextBox
            // 
            this.IptextBox.Location = new System.Drawing.Point(410, 46);
            this.IptextBox.Name = "IptextBox";
            this.IptextBox.Size = new System.Drawing.Size(100, 21);
            this.IptextBox.TabIndex = 1;
            this.IptextBox.Text = "0.0.0.0";
            this.IptextBox.TextChanged += new System.EventHandler(this.IptextBox_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(410, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "模型查看器";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialSettingControl1
            // 
            this.serialSettingControl1.Location = new System.Drawing.Point(12, 12);
            this.serialSettingControl1.Name = "serialSettingControl1";
            this.serialSettingControl1.Size = new System.Drawing.Size(365, 483);
            this.serialSettingControl1.TabIndex = 3;
            this.serialSettingControl1.Load += new System.EventHandler(this.serialSettingControl1_Load);
            // 
            // uwbPositionSettingControl1
            // 
            this.uwbPositionSettingControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uwbPositionSettingControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uwbPositionSettingControl1.Location = new System.Drawing.Point(340, 187);
            this.uwbPositionSettingControl1.Name = "uwbPositionSettingControl1";
            this.uwbPositionSettingControl1.Size = new System.Drawing.Size(572, 291);
            this.uwbPositionSettingControl1.TabIndex = 4;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 505);
            this.Controls.Add(this.uwbPositionSettingControl1);
            this.Controls.Add(this.serialSettingControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IptextBox);
            this.Controls.Add(this.开启遮挡);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 开启遮挡;
        private System.Windows.Forms.TextBox IptextBox;
        private System.Windows.Forms.Button button1;
        private SerialSettingControl serialSettingControl1;
        private UWBPositionSettingControl uwbPositionSettingControl1;
    }
}
﻿using open3mod;

namespace MouseClick
{
    partial class Viewer3D
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
            this.viewer3DControl1 = new open3mod.MainViewer3DControl();
            this.SuspendLayout();
            // 
            // viewer3DControl1
            // 
            this.viewer3DControl1.AllowDrop = true;
            this.viewer3DControl1.BackColor = System.Drawing.SystemColors.Window;
            this.viewer3DControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer3DControl1.Location = new System.Drawing.Point(10, 10);
            this.viewer3DControl1.MinimumSize = new System.Drawing.Size(10, 10);
            this.viewer3DControl1.Name = "viewer3DControl1";
            this.viewer3DControl1.Size = new System.Drawing.Size(805, 486);
            this.viewer3DControl1.TabIndex = 2;
            // 
            // Viewer3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(825, 506);
            this.Controls.Add(this.viewer3DControl1);
            this.Name = "Viewer3D";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Viewer3D";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Viewer3D_FormClosing);
            this.Load += new System.EventHandler(this.Viewer3D_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MainViewer3DControl viewer3DControl1;
    }
}
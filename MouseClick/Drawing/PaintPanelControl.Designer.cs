namespace MouseClick.Drawing
{
    partial class PaintPanelControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaintPanelControl));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel_DrawArea = new System.Windows.Forms.Panel();
            this.toolStrip_DrawTools = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Arrow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Pencil = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Pen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Brush = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Eraser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButton_Thickness = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem_Bold_A = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Bold_B = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Bold_C = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Bold_D = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ColorPalette = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ReDraw = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.LeftToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip_DrawTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.White;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel_DrawArea);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(849, 1109);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.BackColor = System.Drawing.Color.White;
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add(this.toolStrip_DrawTools);
            this.toolStripContainer1.LeftToolStripPanel.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripContainer1.LeftToolStripPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1011, 1129);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // panel_DrawArea
            // 
            this.panel_DrawArea.BackColor = System.Drawing.Color.White;
            this.panel_DrawArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_DrawArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DrawArea.Location = new System.Drawing.Point(0, 0);
            this.panel_DrawArea.Margin = new System.Windows.Forms.Padding(10);
            this.panel_DrawArea.Name = "panel_DrawArea";
            this.panel_DrawArea.Padding = new System.Windows.Forms.Padding(10);
            this.panel_DrawArea.Size = new System.Drawing.Size(849, 1109);
            this.panel_DrawArea.TabIndex = 0;
            this.panel_DrawArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_DrawArea_MouseDown);
            this.panel_DrawArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_DrawArea_MouseMove);
            this.panel_DrawArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_DrawArea_MouseUp);
            // 
            // toolStrip_DrawTools
            // 
            this.toolStrip_DrawTools.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip_DrawTools.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_DrawTools.GripMargin = new System.Windows.Forms.Padding(4);
            this.toolStrip_DrawTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_DrawTools.ImageScalingSize = new System.Drawing.Size(100, 100);
            this.toolStrip_DrawTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Arrow,
            this.toolStripButton_Pencil,
            this.toolStripButton_Pen,
            this.toolStripButton_Brush,
            this.toolStripButton_Eraser,
            this.toolStripSeparator1,
            this.toolStripSplitButton_Thickness,
            this.toolStripSeparator2,
            this.toolStripButton_ColorPalette,
            this.toolStripSeparator3,
            this.toolStripButton_ReDraw,
            this.toolStripSeparator4,
            this.toolStripButton_Exit});
            this.toolStrip_DrawTools.Location = new System.Drawing.Point(0, 3);
            this.toolStrip_DrawTools.Name = "toolStrip_DrawTools";
            this.toolStrip_DrawTools.Padding = new System.Windows.Forms.Padding(10);
            this.toolStrip_DrawTools.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip_DrawTools.Size = new System.Drawing.Size(142, 938);
            this.toolStrip_DrawTools.TabIndex = 0;
            // 
            // toolStripButton_Arrow
            // 
            this.toolStripButton_Arrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Arrow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Arrow.Image")));
            this.toolStripButton_Arrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Arrow.Name = "toolStripButton_Arrow";
            this.toolStripButton_Arrow.Size = new System.Drawing.Size(121, 104);
            this.toolStripButton_Arrow.Text = "光标";
            this.toolStripButton_Arrow.Click += new System.EventHandler(this.toolStripButton_Arrow_Click);
            // 
            // toolStripButton_Pencil
            // 
            this.toolStripButton_Pencil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Pencil.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Pencil.Image")));
            this.toolStripButton_Pencil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Pencil.Name = "toolStripButton_Pencil";
            this.toolStripButton_Pencil.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButton_Pencil.Size = new System.Drawing.Size(121, 110);
            this.toolStripButton_Pencil.Text = "铅笔";
            this.toolStripButton_Pencil.Click += new System.EventHandler(this.toolStripButton_Pencil_Click);
            // 
            // toolStripButton_Pen
            // 
            this.toolStripButton_Pen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Pen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Pen.Image")));
            this.toolStripButton_Pen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Pen.Name = "toolStripButton_Pen";
            this.toolStripButton_Pen.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButton_Pen.Size = new System.Drawing.Size(121, 110);
            this.toolStripButton_Pen.Text = "钢笔";
            this.toolStripButton_Pen.Visible = false;
            this.toolStripButton_Pen.Click += new System.EventHandler(this.toolStripButton_Pen_Click);
            // 
            // toolStripButton_Brush
            // 
            this.toolStripButton_Brush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Brush.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Brush.Image")));
            this.toolStripButton_Brush.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Brush.Name = "toolStripButton_Brush";
            this.toolStripButton_Brush.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButton_Brush.Size = new System.Drawing.Size(121, 110);
            this.toolStripButton_Brush.Text = "毛笔";
            this.toolStripButton_Brush.Click += new System.EventHandler(this.toolStripButton_Brush_Click);
            // 
            // toolStripButton_Eraser
            // 
            this.toolStripButton_Eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Eraser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Eraser.Image")));
            this.toolStripButton_Eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Eraser.Name = "toolStripButton_Eraser";
            this.toolStripButton_Eraser.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButton_Eraser.Size = new System.Drawing.Size(121, 110);
            this.toolStripButton_Eraser.Text = "橡皮擦";
            this.toolStripButton_Eraser.Click += new System.EventHandler(this.toolStripButton_Eraser_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripSplitButton_Thickness
            // 
            this.toolStripSplitButton_Thickness.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton_Thickness.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Bold_A,
            this.toolStripMenuItem_Bold_B,
            this.toolStripMenuItem_Bold_C,
            this.toolStripMenuItem_Bold_D});
            this.toolStripSplitButton_Thickness.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_Thickness.Image")));
            this.toolStripSplitButton_Thickness.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_Thickness.Name = "toolStripSplitButton_Thickness";
            this.toolStripSplitButton_Thickness.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripSplitButton_Thickness.Size = new System.Drawing.Size(121, 104);
            this.toolStripSplitButton_Thickness.Text = "画笔粗细";
            // 
            // toolStripMenuItem_Bold_A
            // 
            this.toolStripMenuItem_Bold_A.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem_Bold_A.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripMenuItem_Bold_A.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.toolStripMenuItem_Bold_A.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_Bold_A.Image")));
            this.toolStripMenuItem_Bold_A.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem_Bold_A.Name = "toolStripMenuItem_Bold_A";
            this.toolStripMenuItem_Bold_A.Size = new System.Drawing.Size(264, 106);
            this.toolStripMenuItem_Bold_A.Text = "A";
            this.toolStripMenuItem_Bold_A.Click += new System.EventHandler(this.toolStripMenuItem_Bold_A_Click);
            // 
            // toolStripMenuItem_Bold_B
            // 
            this.toolStripMenuItem_Bold_B.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem_Bold_B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripMenuItem_Bold_B.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.toolStripMenuItem_Bold_B.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_Bold_B.Image")));
            this.toolStripMenuItem_Bold_B.Name = "toolStripMenuItem_Bold_B";
            this.toolStripMenuItem_Bold_B.Size = new System.Drawing.Size(264, 106);
            this.toolStripMenuItem_Bold_B.Text = "B";
            this.toolStripMenuItem_Bold_B.Click += new System.EventHandler(this.toolStripMenuItem_Bold_B_Click);
            // 
            // toolStripMenuItem_Bold_C
            // 
            this.toolStripMenuItem_Bold_C.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem_Bold_C.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripMenuItem_Bold_C.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.toolStripMenuItem_Bold_C.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_Bold_C.Image")));
            this.toolStripMenuItem_Bold_C.Name = "toolStripMenuItem_Bold_C";
            this.toolStripMenuItem_Bold_C.Size = new System.Drawing.Size(264, 106);
            this.toolStripMenuItem_Bold_C.Text = "C";
            this.toolStripMenuItem_Bold_C.Click += new System.EventHandler(this.toolStripMenuItem_Bold_C_Click);
            // 
            // toolStripMenuItem_Bold_D
            // 
            this.toolStripMenuItem_Bold_D.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem_Bold_D.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripMenuItem_Bold_D.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F);
            this.toolStripMenuItem_Bold_D.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_Bold_D.Image")));
            this.toolStripMenuItem_Bold_D.Name = "toolStripMenuItem_Bold_D";
            this.toolStripMenuItem_Bold_D.Size = new System.Drawing.Size(264, 106);
            this.toolStripMenuItem_Bold_D.Text = "D";
            this.toolStripMenuItem_Bold_D.Click += new System.EventHandler(this.toolStripMenuItem_Bold_D_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripButton_ColorPalette
            // 
            this.toolStripButton_ColorPalette.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ColorPalette.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ColorPalette.Image")));
            this.toolStripButton_ColorPalette.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ColorPalette.Name = "toolStripButton_ColorPalette";
            this.toolStripButton_ColorPalette.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButton_ColorPalette.Size = new System.Drawing.Size(121, 110);
            this.toolStripButton_ColorPalette.Text = "调色盘";
            this.toolStripButton_ColorPalette.Click += new System.EventHandler(this.toolStripButton_ColorPalette_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripButton_ReDraw
            // 
            this.toolStripButton_ReDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ReDraw.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ReDraw.Image")));
            this.toolStripButton_ReDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ReDraw.Name = "toolStripButton_ReDraw";
            this.toolStripButton_ReDraw.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButton_ReDraw.Size = new System.Drawing.Size(121, 110);
            this.toolStripButton_ReDraw.Text = "新建画布";
            this.toolStripButton_ReDraw.Click += new System.EventHandler(this.toolStripButton_ReDraw_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 113);
            // 
            // toolStripButton_Exit
            // 
            this.toolStripButton_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Exit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Exit.Image")));
            this.toolStripButton_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Exit.Name = "toolStripButton_Exit";
            this.toolStripButton_Exit.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButton_Exit.Size = new System.Drawing.Size(121, 110);
            this.toolStripButton_Exit.Text = "退出";
            this.toolStripButton_Exit.Click += new System.EventHandler(this.toolStripButton_Exit_Click);
            // 
            // PaintPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "PaintPanelControl";
            this.Size = new System.Drawing.Size(1011, 1129);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.LeftToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip_DrawTools.ResumeLayout(false);
            this.toolStrip_DrawTools.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Panel panel_DrawArea;
        private System.Windows.Forms.ToolStrip toolStrip_DrawTools;
        private System.Windows.Forms.ToolStripButton toolStripButton_Arrow;
        private System.Windows.Forms.ToolStripButton toolStripButton_Pencil;
        private System.Windows.Forms.ToolStripButton toolStripButton_Pen;
        private System.Windows.Forms.ToolStripButton toolStripButton_Brush;
        private System.Windows.Forms.ToolStripButton toolStripButton_Eraser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_Thickness;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Bold_A;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Bold_B;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Bold_C;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Bold_D;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_ColorPalette;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton_ReDraw;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton_Exit;
    }
}

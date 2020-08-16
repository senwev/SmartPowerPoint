using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MouseClick.Drawing
{

    public partial class PaintPanelControl : UserControl
    {
        public PaintPanelControl()
        {
            InitializeComponent();
            m_penType = 0;
            this.toolStripButton_Arrow.Checked = true;

            m_thicknessType = 1;
            this.toolStripMenuItem_Bold_A.Checked = true;

            this.SelectedColor = Color.Black;
            this.SelectedBrush = new SolidBrush(this.SelectedColor);
        }

        public event EventHandler OnCloseWindow;

        private int m_penType = 0;

        private int m_thicknessType = 0;

        private Pen SelectedPen;

        private Brush SelectedBrush;

        private Color SelectedColor;

        private bool isPainting;

        private int startPointX = 0;

        private int startPointY = 0;

        private void toolStripButton_Arrow_Click(object sender, EventArgs e)
        {
            DisableAllPenType();
            this.toolStripButton_Arrow.Checked = true;
            m_penType = 0;
        }

        private void toolStripButton_Pencil_Click(object sender, EventArgs e)
        {
            DisableAllPenType();
            this.toolStripButton_Pencil.Checked = true;
            m_penType = 1;
            //this.SelectedBrush = new HatchBrush(HatchStyle.Percent90, this.SelectedColor, ChangeColor(this.SelectedColor, -0.5f));
            this.SelectedBrush = new SolidBrush(this.SelectedColor);
            ResetPen();
        }

        private void toolStripButton_Pen_Click(object sender, EventArgs e)
        {
            DisableAllPenType();
            this.toolStripButton_Pen.Checked = true;
            m_penType = 2;
            this.SelectedBrush = new SolidBrush(this.SelectedColor);
            ResetPen();
        }

        private void toolStripButton_Brush_Click(object sender, EventArgs e)
        {
            DisableAllPenType();
            this.toolStripButton_Brush.Checked = true;
            m_penType = 3;
            this.SelectedBrush = new HatchBrush(HatchStyle.Percent20, this.SelectedColor, ChangeColor(this.SelectedColor, -0.8f));
            ResetPen();
        }

        private void toolStripButton_Eraser_Click(object sender, EventArgs e)
        {
            DisableAllPenType();
            this.toolStripButton_Eraser.Checked = true;
            m_penType = 4;
        }

        private void DisableAllPenType()
        {
            this.toolStripButton_Arrow.Checked = false;
            this.toolStripButton_Pen.Checked = false;
            this.toolStripButton_Pencil.Checked = false;
            this.toolStripButton_Brush.Checked = false;
            this.toolStripButton_Eraser.Checked = false;
        }

        private void toolStripMenuItem_Bold_A_Click(object sender, EventArgs e)
        {
            DisableAllThicknessType();
            this.toolStripMenuItem_Bold_A.Checked = true;
            m_thicknessType = 2;
            ResetPen();

        }

        private void toolStripMenuItem_Bold_B_Click(object sender, EventArgs e)
        {
            DisableAllThicknessType();
            this.toolStripMenuItem_Bold_B.Checked = true;
            m_thicknessType = 4;
            ResetPen();

        }

        private void toolStripMenuItem_Bold_C_Click(object sender, EventArgs e)
        {
            DisableAllThicknessType();
            this.toolStripMenuItem_Bold_C.Checked = true;
            m_thicknessType = 6;
            ResetPen();

        }

        private void toolStripMenuItem_Bold_D_Click(object sender, EventArgs e)
        {
            DisableAllThicknessType();
            this.toolStripMenuItem_Bold_D.Checked = true;
            m_thicknessType = 10;
            ResetPen();

        }

        private void DisableAllThicknessType()
        {
            this.toolStripMenuItem_Bold_A.Checked = false;
            this.toolStripMenuItem_Bold_B.Checked = false;
            this.toolStripMenuItem_Bold_C.Checked = false;
            this.toolStripMenuItem_Bold_D.Checked = false;
        }

        private void ResetPen()
        {
            this.SelectedPen = new Pen(this.SelectedBrush, this.m_thicknessType);
            this.SelectedPen.LineJoin = LineJoin.MiterClipped;
            this.SelectedPen.Alignment = PenAlignment.Center;
            this.SelectedPen.StartCap = LineCap.Round;
            this.SelectedPen.EndCap = LineCap.Round;
        }

        public static Color ChangeColor(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            if (red < 0) red = 0;

            if (red > 255) red = 255;

            if (green < 0) green = 0;

            if (green > 255) green = 255;

            if (blue < 0) blue = 0;

            if (blue > 255) blue = 255;

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        private void toolStripButton_ColorPalette_Click(object sender, EventArgs e)
        {
            var colorDialog = new System.Windows.Forms.ColorDialog();
            colorDialog.Color = this.SelectedColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.SelectedColor = colorDialog.Color;
            }
            switch (m_penType)
            {
                case 1:
                    this.SelectedBrush = new SolidBrush(this.SelectedColor);
                    //this.SelectedBrush = new HatchBrush(HatchStyle.Percent90, this.SelectedColor, ChangeColor(this.SelectedColor, -0.5f));
                    ResetPen();
                    break;
                case 2:
                    this.SelectedBrush = new SolidBrush(this.SelectedColor);
                    ResetPen();
                    break;
                case 3:
                    this.SelectedBrush = new HatchBrush(HatchStyle.Percent20, this.SelectedColor, ChangeColor(this.SelectedColor, -0.8f));
                    ResetPen();
                    break;
                default:
                    break;
            }
            //this.SelectedPen = new Pen(this.SelectedColor, this.m_thicknessType);
        }

        private void toolStripButton_ReDraw_Click(object sender, EventArgs e)
        {
            using (var g = this.panel_DrawArea.CreateGraphics())
            {
                g.Clear(Color.White);
            }
            this.panel_DrawArea.Update();
        }

        private void toolStripButton_Exit_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.OnCloseWindow?.Invoke(this, e);
        }

        private void panel_DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPainting = true;
                startPointX = e.X;
                startPointY = e.Y;
            }

        }

        private void panel_DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPainting)
            {
                if (m_penType > 0 && m_penType < 4)
                {
                    using (var g = this.panel_DrawArea.CreateGraphics())
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.NearestNeighbor;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        
                        g.DrawLine(SelectedPen, startPointX, startPointY, e.X, e.Y);
                        startPointX = e.X;
                        startPointY = e.Y;
                        this.panel_DrawArea.Update();
                    }
                }
                else if (m_penType == 4)
                {
                    using (var g = this.panel_DrawArea.CreateGraphics())
                    {
                        var p = new Pen(Color.White, this.m_thicknessType * 2);
                        g.DrawLine(p, startPointX, startPointY, e.X, e.Y);
                        startPointX = e.X;
                        startPointY = e.Y;
                        this.panel_DrawArea.Update();
                    }
                }
            }
        }

        private void panel_DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            isPainting = false;
        }

        private void PaintPanel_Load(object sender, EventArgs e)
        {

        }
    }
}

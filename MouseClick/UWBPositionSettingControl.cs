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
    public partial class UWBPositionSettingControl : UserControl
    {
        public UWBPositionSettingControl()
        {
            InitializeComponent();
            this.helper = Constant.DrawingHelper;
            this.helper.DrawingRefreshEvent += new EventHandler(OnDrawingRefresh);
        }

        private DrawingHelper helper;

        private void UWBPositionSettingControl_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void UWBPositionSettingControl_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);        
            helper.Draw(g, this.ClientRectangle);          
        }
        private void OnDrawingRefresh(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                var d = new RefreshDrawingHandler(RefreshDrawing);
                this.Invoke(d);
            }
            else
            {
                RefreshDrawing();
            }
        }
        private delegate void RefreshDrawingHandler();
        private void RefreshDrawing()
        {
            this.Refresh();
        }

        private void UWBPositionSettingControl_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}

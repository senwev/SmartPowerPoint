using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace open3mod
{
    public class ControlHelper
    {
        public static T FindParent<T>(Control control) where T : Control
        {
            if (control is T || control == null)
            {
                return (T)control;
            }
            else
            {
                return FindParent<T>(control.Parent);
            }
        }

    }
}

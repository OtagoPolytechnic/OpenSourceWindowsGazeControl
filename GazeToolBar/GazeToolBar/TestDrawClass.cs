using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public class TestDrawClass
    {

        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

       
        public TestDrawClass()
        {

        }

        public void DrawMouseLocation(int xPos, int yPos)
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                g.DrawEllipse(Pens.Black, xPos, yPos, 20, 20);
            }
        }

    }
}

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
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        IntPtr  desktopPtr = GetDC(IntPtr.Zero); 
        Graphics g;

        SolidBrush b; 
        

        
        //ReleaseDC(IntPtr.Zero, desktopPtr);

        public TestDrawClass()
        {
            g = Graphics.FromHdc(desktopPtr);
            b = new SolidBrush(Color.White);
           
        }

        public void DrawMouseLocation(int xPos, int yPos)
        {
            g.FillRectangle(b,xPos,yPos,5,5);

            g.Dispose();
        }

    }
}

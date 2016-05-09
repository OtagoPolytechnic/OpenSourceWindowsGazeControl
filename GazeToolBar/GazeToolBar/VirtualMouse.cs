using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput.Native;


namespace GazeToolBar
{
    public static class VirtualMouse
    {

        const int MIDDLEMOUSEBUTTON = 0x04;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);        

        //This simulates a left mouse click
        public static void LeftMouseClick(int xpos, int ypos)
        {
            WindowsInput.InputSimulator mouseSim = new WindowsInput.InputSimulator();
            SetCursorPos(xpos, ypos);
            mouseSim.Mouse.LeftButtonClick();
        }

        public static void LeftDoubleClick(int xpos, int ypos)
        {
            WindowsInput.InputSimulator mouseSim = new WindowsInput.InputSimulator();
            SetCursorPos(xpos, ypos);
            mouseSim.Mouse.LeftButtonDoubleClick();
        }

        public static void RightMouseClick(int xpos, int ypos)
        {

            WindowsInput.InputSimulator mouseSim = new WindowsInput.InputSimulator();
            SetCursorPos(xpos, ypos);
            mouseSim.Mouse.RightButtonClick();

        }

        public static void MiddleMouseButton(int xpos, int ypos)
        {
            WindowsInput.InputSimulator mouseSim = new WindowsInput.InputSimulator();
            SetCursorPos(xpos, ypos);
            mouseSim.Mouse.MiddleButtonClick();
        }
    }
}

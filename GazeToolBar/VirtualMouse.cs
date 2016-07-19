using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput.Native;

/*
 *  Class: VirtualMouse
 *  Name: Richard Horne
 *  Date: 10/05/2015
 *  Description: This is an abstract class which does not need to be instantiated, its methods can be call to simulate actions normally provided by a mouse.
 *  Purpose: The main purpose of this class to encapsulate mouse actions which can be passed into of called by other classes, e.g. when a fixation is detected the Virtual.Mouse.LeftMouseClick
 *  can be passed in as a type and used to click where the fixation event happened.
 */



namespace GazeToolBar
{
    public static class VirtualMouse
    {
        //Import user32.dll to expose win32api set SetCursorPos method.
        //https://msdn.microsoft.com/en-us/library/windows/desktop/ms648394%28v=vs.85%29.aspx
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);        

       
        //Simulate a single click the left mouse button at th XY position passed in.
        public static void LeftMouseClick(int xpos, int ypos)
        {
            //Instantiate mouse simulator object.
            WindowsInput.InputSimulator mouseSim = new WindowsInput.InputSimulator();
            //Move cursor to screen position pass in.
            SetCursorPos(xpos, ypos);
            //Call left button click function at the cursor's current location.
            mouseSim.Mouse.LeftButtonClick();
            mouseSim.Keyboard.KeyPress(VirtualKeyCode.CONTROL);
        }


        //Simulate a double left click at the XY position passed in.
        public static void LeftDoubleClick(int xpos, int ypos)
        {
            //Instantiate mouse simulator object.
            WindowsInput.InputSimulator mouseSim = new WindowsInput.InputSimulator();
            //Move cursor to screen position pass in.
            SetCursorPos(xpos, ypos);
            //Call left button double click function at the cursor's current location.
            mouseSim.Mouse.LeftButtonDoubleClick();
        }

        //Simulate a single right click at the XY position passed in.
        public static void RightMouseClick(int xpos, int ypos)
        {
            //Instantiate mouse simulator object.
            WindowsInput.InputSimulator mouseSim = new WindowsInput.InputSimulator();
            //Move cursor to screen position pass in.
            SetCursorPos(xpos, ypos);
            //Call right button click function at the cursor's current location.
            mouseSim.Mouse.RightButtonClick();

        }

        //Simulate a single middle button click at the XY position passed in.
        public static void MiddleMouseButton(int xpos, int ypos)
        {
            //Instantiate mouse simulator object.
            WindowsInput.InputSimulator mouseSim = new WindowsInput.InputSimulator();
            //Move cursor to screen position pass in.
            SetCursorPos(xpos, ypos);
            //Call middle button click function at the cursor's current location.
            mouseSim.Mouse.MiddleButtonClick();
        }

        //Simulate the left mouse button being pressed and held down.
        public static void LeftMouseButtonheldDown(int xpos, int ypos)
        {
            //Instantiate mouse simulator object.
            WindowsInput.InputSimulator mouseSim = new WindowsInput.InputSimulator();
            //Move cursor to screen position pass in.
            SetCursorPos(xpos, ypos);
            //Call left button down function at the cursor's current location.
            mouseSim.Mouse.LeftButtonDown();
        }


        //Simulate the left mouse button being released.
        public static void LeftMouseReleased(int xpos, int ypos)
        {
            //Instantiate mouse simulator object.
            WindowsInput.InputSimulator mouseSim = new WindowsInput.InputSimulator();
            //Move cursor to screen position pass in.
            SetCursorPos(xpos, ypos);
            //Call left button down function at the cursor's current location.
            mouseSim.Mouse.LeftButtonUp();

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Input;



/*
 *  Class: KeyboardHook
 *  Name: Richard Horne
 *  Date: 11/11/2016
 *  Description: A class to enable access globally keyboard events.
 *  Purpose : capture all keyboard input even when gazetoolbar is not the top level of windows or has focus, as default c# keyboard events to not work when the from is not top level or in focus. This will enable further
 *  functionality of the gaze control software where a user can set a key or physical switch to call a function from the gaze tool bar with out looking
 *  at the tool bar to select a function and enable further streamlined use.
 */


namespace GazeToolBar
{

    //sourced from http://www.dylansweb.com/2014/10/low-level-global-keyboard-hook-sink-in-c-net/
    //https://msdn.microsoft.com/en-us/library/windows/desktop/ms644990(v=vs.85).aspx
    //https://msdn.microsoft.com/en-us/library/windows/desktop/ms644960(v=vs.85).aspx#installing_releasing
    //https://msdn.microsoft.com/en-nz/library/windows/desktop/ms644985(v=vs.85).aspx
    //http://www.pinvoke.net/default.aspx/user32.setwindowshookex

    public class KeyboardHook
    {
        //Lowlevel keyboard hook, as cannot inject dlls in managed c#, 
        private const int WH_KEYBOARD_LL = 13;
        // user32.dll hook event types
        private const int WM_KEYDOWN = 0x0100; //normal key pressed eg abcdef 12345
        private const int WM_SYSKEYDOWN = 0x0104; // atl ctrl enter, f1 f2 etc...
        
        
        //hook this app into chain
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        //remove hook when app closes.
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);


        //pass something on to next keyboard hook in the chain, needed else can break chain and effect other apps that have hooks
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        //not sure what this does. something to do with getting a handle from process. 
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        //delegate require to pass into SetWindowsHook, kind of like an event in managed c#
        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        //C# event to subscribe to on this class. will be raised when keypress is detected by windows api.
        public event EventHandler<HookedKeyboardEventArgs> OnKeyPressed;

        //Delegate 
        private LowLevelKeyboardProc LowLevelKBhookDelegate;


        //InteropServices pointer, points to memory location of hook, i think.
        private IntPtr hookID = IntPtr.Zero;


        //Constructor
        public KeyboardHook()
        {
            //set delegate to point to call back method that will be run by windows/system32 api when a key it pressed.
            LowLevelKBhookDelegate = HookCallback;

        }
 
         //Start hook
        public void HookKeyboard()
        {//pass delegate that points at callback method into SetWindowsHookEx, and store pointer to in hookID
            hookID = SetHook(LowLevelKBhookDelegate);
        }
 
        //remove hook
        public void UnHookKeyboard()
        {
            UnhookWindowsHookEx(hookID);
        }
 
        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            //get the process of this application and passing it in with the hook.
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
 
        //call back function, will be run on key press events from windows.
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {

                //marshal/convert unmanaged code info to CLI code that can me used in .net cli app.
                int vkCode = Marshal.ReadInt32(lParam);
                
 
                if (OnKeyPressed != null) 
                {
                    OnKeyPressed(this, new HookedKeyboardEventArgs(KeyInterop.KeyFromVirtualKey(vkCode)));
                }
            }
            
            //pass onto next hook in the chain. if you dont do this other applications hooks wont work.
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }
    }

}

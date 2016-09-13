using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Input;

namespace GazeToolBar
{

    //sourced from http://www.dylansweb.com/2014/10/low-level-global-keyboard-hook-sink-in-c-net/
    public class Keyboardhook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        
        
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public event EventHandler<HookedKeyboardEventArgs> OnKeyPressed;


        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;



        public Keyboardhook()
        {
            _proc = HookCallback;

        }
 
        public void HookKeyboard()
        {
            _hookID = SetHook(_proc);
        }
 
        public void UnHookKeyboard()
        {
            UnhookWindowsHookEx(_hookID);
        }
 
        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
 
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                
 
                if (OnKeyPressed != null) 
                {
                    OnKeyPressed(this, new HookedKeyboardEventArgs(KeyInterop.KeyFromVirtualKey(vkCode)));
                }
            }
 
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }

}

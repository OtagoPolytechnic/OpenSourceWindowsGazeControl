using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeToolBar
{
    static class AutoStart
    {
        //When auto start is on then set to true
        //else false
        private static bool isOnStart;
        private static RegistryKey rkApp;

        static AutoStart()
        {
            isOnStart = false;
        }

        public static void OpenKey()
        {
            rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }

        public static void IsAutoStart(Settings settings, MenuItem menuItemStartOnOff)
        {
            if (rkApp.GetValue(ValueNeverChange.RES_NAME) == null)
            {
                // The value doesn't exist, the application is not set to run at startup
                isOnStart = false;
                if (settings != null)
                {
                    settings.BtnAutoStart.Text = ValueNeverChange.AUTO_START_OFF;
                }
                menuItemStartOnOff.Text = ValueNeverChange.AUTO_START_OFF;
            }
            else
            {
                // The value exists, the application is set to run at startup
                isOnStart = true;
                if (settings != null)
                {
                    settings.BtnAutoStart.Text = ValueNeverChange.AUTO_START_ON;
                }
                menuItemStartOnOff.Text = ValueNeverChange.AUTO_START_ON;
            }
        }

        /// <summary>
        /// If auto start is on then it will start
        /// when user turn on their computer
        /// Call OpenKey before call this method
        /// </summary>
        public static void setAutoStartOnOff(Settings settings, MenuItem menuItemStartOnOff)
        {
            if (!isOnStart)
            {
                try
                {
                    rkApp.SetValue(ValueNeverChange.RES_NAME, Application.ExecutablePath.ToString());
                    isOnStart = true;
                    if (settings != null)
                    {
                        settings.BtnAutoStart.Text = ValueNeverChange.AUTO_START_ON;
                    }
                    menuItemStartOnOff.Text = ValueNeverChange.AUTO_START_ON;
                }
                catch (UnauthorizedAccessException exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                rkApp.DeleteValue(ValueNeverChange.RES_NAME, false);
                isOnStart = false;
                if (settings != null)
                {
                    settings.BtnAutoStart.Text = ValueNeverChange.AUTO_START_OFF;
                }
                menuItemStartOnOff.Text = ValueNeverChange.AUTO_START_OFF;
            }
        }
    }
}

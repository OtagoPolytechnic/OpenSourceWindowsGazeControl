using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Permissions;

namespace GazeToolBar
{
    static class AutoStart
    {
        private static RegistryKey rkApp;

        static AutoStart()
        {
            rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }

        [RegistryPermissionAttribute(SecurityAction.Assert, ViewAndModify = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run")]
        public static bool SetOn()
        {
            RegistryPermission f = new RegistryPermission(RegistryPermissionAccess.AllAccess, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            try
            {
                f.Assert();
                rkApp.SetValue("GazeToolBar", Application.ExecutablePath.ToString());
                //MessageBox.Show("Sussess", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                //MessageBox.Show("Please run as adminstrator", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public static void SetOff()
        {
            rkApp.DeleteValue("GazeToolBar", false);
            //MessageBox.Show("Sussess", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool IsOn()
        {
            return !(rkApp.GetValue("GazeToolBar") == null);
        }
    }
}

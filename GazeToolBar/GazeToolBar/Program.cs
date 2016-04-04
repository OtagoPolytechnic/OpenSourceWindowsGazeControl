using EyeXFramework.Forms;
using System;
using System.Windows.Forms;

namespace GazeToolBar
{
    static class Program
    {
        private static FormsEyeXHost eyeXHost = new FormsEyeXHost();


        public static FormsEyeXHost EyeXHost
        {
            get { return eyeXHost; }
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            eyeXHost.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            eyeXHost.Dispose();
            
        }
    }
}

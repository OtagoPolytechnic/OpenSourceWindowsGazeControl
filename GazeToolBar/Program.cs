using EyeXFramework.Forms;
using System;
using System.Windows.Forms;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace GazeToolBar
{
    static class Program
    {
        private static FormsEyeXHost eyeXHost = new FormsEyeXHost();
        public static string path { get; set; }

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
            path = Application.StartupPath + "\\" + "Settings.json";
            if (!File.Exists(path))
            {
                SettingJSON defaultSetting = new SettingJSON();
                defaultSetting.language = "English(United States)";
                defaultSetting.position = "Right";
                defaultSetting.precision = 0;
                defaultSetting.selection = "Gaze";
                defaultSetting.size = "Small";
                defaultSetting.soundFeedback = false;
                defaultSetting.speed = 0;
                defaultSetting.typingSpeed = 0;
                defaultSetting.wordPercision = false;
                string JSONstr = JsonConvert.SerializeObject(defaultSetting);
                File.AppendAllText(path, JSONstr);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            eyeXHost.Dispose();
            
        }
    }
}

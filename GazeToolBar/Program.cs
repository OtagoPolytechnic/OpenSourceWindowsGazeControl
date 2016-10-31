using EyeXFramework.Forms;
using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;



namespace GazeToolBar
{
    static class Program
    {
       // private static FormsEyeXHost eyeXHost = new FormsEyeXHost();

        public static string path { get; set; }
        public static SettingJSON readSettings { get; set; }
        public static bool onStartUp { get; set; }

        //public static FormsEyeXHost EyeXHost
        //{
        //    get { return eyeXHost; }
        //}
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //eyeXHost.Start();
            path = Application.StartupPath + "\\" + "Settings.json";
            if (!File.Exists(path))
            {
                SettingJSON defaultSetting = new SettingJSON();
                //TODO: Need to be replaced

                //defaultSetting.language = "    English\r\n(United States)";
                //defaultSetting.position = "Right";
                //defaultSetting.precision = 0;
                //defaultSetting.selection = "GAZE";
                //defaultSetting.size = "SMALL";
                //defaultSetting.soundFeedback = false;
                //defaultSetting.speed = 0;
                //defaultSetting.typingSpeed = 0;
                //defaultSetting.wordPrediction = false;
                string JSONstr = JsonConvert.SerializeObject(defaultSetting);
                File.AppendAllText(path, JSONstr);
            }
            ReadWriteJson();
            onStartUp = AutoStart.IsOn();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //eyeXHost.Dispose();

        }

        public static void ReadWriteJson()
        {
            if (!File.Exists(path))
            {
                SettingJSON defaultSetting = new SettingJSON();
                //TODO: Need to be replaced

                //defaultSetting.language = "    English\r\n(United States)";
                //defaultSetting.position = "Right";
                //defaultSetting.precision = 0;
                //defaultSetting.selection = "GAZE";
                //defaultSetting.size = "SMALL";
                //defaultSetting.soundFeedback = false;
                //defaultSetting.speed = 0;
                //defaultSetting.typingSpeed = 0;
                //defaultSetting.wordPrediction = false;
                string JSONstr = JsonConvert.SerializeObject(defaultSetting);
                File.AppendAllText(path, JSONstr);
            }
            else
            {
                string s = File.ReadAllText(path);
                readSettings = JsonConvert.DeserializeObject<SettingJSON>(s);
            }
        }
    }
}

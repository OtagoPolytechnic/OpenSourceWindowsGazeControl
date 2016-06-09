using System.Drawing;
using System.Windows.Forms;

namespace GazeToolBar
{
    /*
        Date: 17/05/2016
        Name: Derek Dai
        Description: Put all the constant value or method in here
    */
    static class ValueNeverChange
    {
        public static readonly int DELAY_MILLISECONDS = 100;
        public static readonly double FORM_WEIGTH_PERCENTAGE = 0.1;
        public static readonly string RES_NAME = "GazeToolBar";
        public static readonly string AUTO_START_ON = "Auto Start Is On";
        public static readonly string AUTO_START_OFF = "Auto Start Is OFF";
        public static readonly int FIXED_HEIGHT = 800;
        public static readonly int FIXED_WIDTH = 600;
        public static readonly Size SCREEN_SIZE = Screen.PrimaryScreen.WorkingArea.Size;
        public static readonly Rectangle PRIMARY_SCREEN = Screen.PrimaryScreen.Bounds;
        public static readonly Color SelectedColor = Color.FromArgb(78, 0, 82);
        public static readonly Color SettingButtonColor = Color.FromArgb(170, 170, 170);

        /// <summary>
        /// By calling this method all the buttons that passed in will be reset its color
        /// </summary>
        /// <param name="button">Buttons that will be reset on</param>
        public static void ResetBtnBackcolor(params Button[] button)
        {
            foreach (Button b in button)
            {
                b.BackColor = Color.FromArgb(173, 83, 201);
            }
        }
    }
}

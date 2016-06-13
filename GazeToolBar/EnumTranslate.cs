using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeToolBar
{
    public static class EnumTranslate
    {
        public static void GazeOrSwitchTranslate(Button gaze, Button Switch, Settings.GazeOrSwitch gazeOrSwitch)
        {
            switch (gazeOrSwitch)
            {
                case Settings.GazeOrSwitch.GAZE:
                    gaze.BackColor = ValueNeverChange.SettingButtonColor;
                    Switch.BackColor = ValueNeverChange.SelectedColor;
                    break;
                case Settings.GazeOrSwitch.SWITCH:
                    gaze.BackColor = ValueNeverChange.SelectedColor;
                    Switch.BackColor = ValueNeverChange.SettingButtonColor;
                    break;
            }
        }

        public static void SisesTranslate(Button small, Button large, Settings.Sizes sizes)
        {
            switch (sizes)
            {
                case Settings.Sizes.SMALL:
                    small.BackColor = ValueNeverChange.SettingButtonColor;
                    large.BackColor = ValueNeverChange.SelectedColor;
                    break;
                case Settings.Sizes.LARGE:
                    small.BackColor = ValueNeverChange.SelectedColor;
                    large.BackColor = ValueNeverChange.SettingButtonColor;
                    break;
            }
        }
    }
}

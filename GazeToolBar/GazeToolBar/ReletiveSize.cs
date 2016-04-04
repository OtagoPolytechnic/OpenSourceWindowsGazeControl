using System;
using System.Drawing;
using System.Windows.Forms;

namespace GazeToolBar
{
    static class ReletiveSize
    {
        public static readonly Size formSize = new Size(Convert.ToInt32(ValueNeverChange.SCREEN_SIZE.Width * ValueNeverChange.FORM_WEIGTH_PERCENTAGE), ValueNeverChange.SCREEN_SIZE.Height);
        public static readonly Size btnSize = new Size(Convert.ToInt32(formSize.Width * 0.5), Convert.ToInt32(formSize.Height * 0.08));
        public static readonly int gap = btnSize.Height * 2;
        public static readonly Size panelSize = new Size(formSize.Width, btnSize.Height * 4 + gap * 3);
        public static readonly int btnPositionX = formSize.Width / 2 - btnSize.Width / 2;
        public static readonly int panelPositionY = formSize.Height / 2 - panelSize.Height / 2;

        public static int btnPostionY(int num)
        {
            if(num == 1)
            {
                return (num - 1) * btnSize.Height;
            }
            else
            {
                return (num - 1) * btnSize.Height + gap * (num - 1);
            }
        }
    }
}

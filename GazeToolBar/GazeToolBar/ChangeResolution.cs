using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    /*
        Date: 17/05/2016
        Name: Derek Dai
        Description: Change resolution of the screen
    */
    static class ChangeResolution
    {
        private static int width = ValueNeverChange.PRIMARY_SCREEN.Width;
        private static int height = ValueNeverChange.PRIMARY_SCREEN.Height;

        public static void ChangeScreenResolution()
        {
            CResolution cr = new CResolution(ValueNeverChange.FIXED_HEIGHT, ValueNeverChange.FIXED_WIDTH);
        }

        public static void ChangeResolutionBack()
        {
            CResolution cr = new CResolution(width, height);
        }
    }
}

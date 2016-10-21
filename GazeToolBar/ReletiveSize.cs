using System;
using System.Drawing;
using System.Windows.Forms;

namespace GazeToolBar
{
    /*
        Date: 17/05/2016
        Name: Derek Dai
        Description: All the reletive size and position will be in this class
    */
    static class ReletiveSize
    {
        //public static readonly Size formSize = new Size(Convert.ToInt32(ValueNeverChange.SCREEN_SIZE.Width * ValueNeverChange.FORM_WEIGTH_PERCENTAGE), ValueNeverChange.SCREEN_SIZE.Height);
        //public static readonly Size btnSize = new Size(Convert.ToInt32(formSize.Width * 0.5), Convert.ToInt32(formSize.Height * 0.07));
        //public static readonly Size btnPanelSize = new Size(btnSize.Width + 6, btnSize.Height + 6);
        //public static readonly int gap = btnSize.Height;
        //public static readonly Size panelSize = new Size(200,1000);
        //public static readonly int btnPositionX = 3;
        //public static readonly int panelPositionY = 0;
        //public static readonly int pnlPositionX = 0;

        //public static readonly int btnPostionY = 3;

        

        //public static int pnlPostionY(int num)
        //{
        //    if(num == 1)
        //    {
        //        return ((num - 1) * btnSize.Height) + 3;
        //    }
        //    else
        //    {
        //        return ((num - 1) * btnSize.Height + gap * (num - 1) + 3);
        //    }
        //}


        public static Point panelSaveAndCancel(int width, int height)
        {
            int i = (ValueNeverChange.SCREEN_SIZE.Width - width) / 2;
            return new Point(i, ValueNeverChange.SCREEN_SIZE.Height - height);
        }

        public static Size panelGeneralSize()
        {
            int w = (int)(ValueNeverChange.SCREEN_SIZE.Width * 0.98);
            int h = (int)(ValueNeverChange.SCREEN_SIZE.Height * 0.85);
            return new Size(w, h);
        }

        public static Point distribute(Panel parent, int thisElementXorY, int position, int totalElement, String flag, double per)
        {
            double percent = (100 / totalElement) / 100.0;
            double widthPercent = per;
            if (flag == "h")
            {
                int parentHeight = parent.Size.Height;
                int thisElementLocationY = (int)(percent * parentHeight * (position - 1));
                return new Point(thisElementXorY, thisElementLocationY);
            }
            else if (flag == "w")
            {
                int parentWidth = parent.Size.Width;
                int thisElementLocationX = (int)(widthPercent * parentWidth);
                return new Point(thisElementLocationX, thisElementXorY);
            }
            else
            {
                return new Point();
            }
        }

        public static Size controlLength(Panel parent, int thisElementHeight, double percent)
        {
            int parentLength = parent.Size.Width;
            int length = (int)(parentLength * percent);
            return new Size(length, thisElementHeight);
        }

        public static Size controlLength(Control first, Control second, int thisElementHeight)
        {
            int length = (second.Location.X + second.Size.Width + second.Parent.Location.X) - (first.Location.X + first.Parent.Location.X);
            return new Size(length, thisElementHeight);
        }

        public static Point labelPosition(Panel parent, Label label)
        {
            int parentWidth = parent.Size.Width;
            int labelX = (int)(parentWidth * 0.02);
            return new Point(labelX, label.Location.Y);
        }

        public static Point reletiveLocation(Control relativeTo, int thisControlXorY, int space, char hov)
        {
            Point p = new Point();
            switch (hov)
            {
                case 'h':
                    p.X = thisControlXorY;
                    p.Y = relativeTo.Location.Y + space + relativeTo.Size.Height;
                    break;
                case 'v':
                    p.X = relativeTo.Location.X + space + relativeTo.Size.Width;
                    p.Y = thisControlXorY;
                    break;
            }
            return p;
        }

        public static void evenlyDistrubute(Panel parentPanel)
        {
            float percent = 0.0f;
            foreach (Control c in parentPanel.Controls)
            {
                percent += 0.1f;
                //c.Location.Y
            }
        }

        public static Size TabControlSize = new Size(ValueNeverChange.SCREEN_SIZE.Width, ValueNeverChange.SCREEN_SIZE.Height - 56 * 2);  
    }
}

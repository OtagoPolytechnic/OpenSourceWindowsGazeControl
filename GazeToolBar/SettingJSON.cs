using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public class SettingJSON
    {
        public float fixationTimeLength { get; set; }
        public float fixationTimeOut { get; set; }
        public int leftClick { get; set; }
        public int rightClick { get; set; }
        public int scoll { get; set; }
    }
}

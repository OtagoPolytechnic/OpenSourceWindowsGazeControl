using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public class SettingJSON
    {
        public int fixationTimeLength { get; set; }
        public int fixationTimeOut { get; set; }
        public string leftClick { get; set; }
        public string doubleClick { get; set; }
        public string rightClick { get; set; }
        public string scoll { get; set; }
    }
}

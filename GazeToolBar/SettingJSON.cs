using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public class SettingJSON
    {
        public string selection { get; set; }
        public int precision { get; set; }
        public int speed { get; set; } 
        public string position { get; set; }
        public string language { get; set; }
        public bool wordPercision { get; set; }
        public string size { get; set; }
        public bool soundFeedback { get; set; }
        public int typingSpeed { get; set; }
    }
}

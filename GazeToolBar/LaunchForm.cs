using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeToolBar
{
    public class LaunchForm : Form
    {
        StateManager statemanager;
        public LaunchForm()
        {
           // statemanager = new StateManager();
            statemanager.Run();
        }
    }
}

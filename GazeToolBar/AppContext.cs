using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeToolBar
{
    public class AppContext : ApplicationContext
    {
        private StateManager statemanager;

        public AppContext()
        {
            statemanager = new StateManager();
            statemanager.Run();
        }
    }
}

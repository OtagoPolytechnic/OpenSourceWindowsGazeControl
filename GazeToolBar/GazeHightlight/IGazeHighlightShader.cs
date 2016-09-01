using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public interface IGazeHighlightShader
    {
        SolidBrush GenerateBrush(int scalarValue, int transValue);
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Interface
 *  Name: Richard Horne
 *  Date: 11/11/2016
 *  Description: Interface to specify required methods to implement a shader.
 */

namespace GazeToolBar
{
    public interface IGazeHighlightShader
    {
        SolidBrush GenerateBrush(int scalarValue, int transValue);
    }
}

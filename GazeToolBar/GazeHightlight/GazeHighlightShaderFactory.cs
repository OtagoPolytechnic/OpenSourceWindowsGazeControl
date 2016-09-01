using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public enum EHighlightShaderType{ RedToGreen }
    class GazeHighlightShaderFactory
    {
        public GazeHighlightShaderFactory()
        {

        }

        public IGazeHighlightShader CreateShader(EHighlightShaderType shaderType)
        {
            IGazeHighlightShader returnShader = null;

            switch(shaderType)
            {
                case EHighlightShaderType.RedToGreen:
                    //Shadertogohere
                    break;
            }

            return returnShader;
    
        }
    
    }
}

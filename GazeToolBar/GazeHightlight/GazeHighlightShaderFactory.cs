using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 *  Class: GazeHighlightShaderfactory
 *  Name: Richard Horne
 *  Date: 11/11/2016
 *  Description: Factory class to decouple shader creation from GazeHighlight class.
 */

namespace GazeToolBar
{
    public enum EHighlightShaderType{ RedToGreen }
    class GazeHighlightShaderFactory
    {
        public GazeHighlightShaderFactory()
        {
            //empty
        }


        //create and return shader.
        public IGazeHighlightShader CreateShader(EHighlightShaderType shaderType)
        {
            IGazeHighlightShader returnShader = null;

            switch(shaderType)
            {
                case EHighlightShaderType.RedToGreen:
                    returnShader = new RedToGreenShader();
                    break;
            }

            return returnShader;
        }
    
    }
}

using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ZoomLens_TranslateToDesktop()
        {
            GazeToolBar.ZoomLens zoomer = new GazeToolBar.ZoomLens();

            int GazeCoordinate = 100;

            Point expectedP = new Point();
            

            Point actualP = new Point();
            actualP.X = zoomer.TranslateToDesktop(GazeCoordinate, GazeCoordinate).X;
            actualP.Y = zoomer.TranslateToDesktop(GazeCoordinate, GazeCoordinate).Y;



            //Assert.AreEqual();
        }
    }
}

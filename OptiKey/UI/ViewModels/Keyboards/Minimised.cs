using System;
using OptiKey.UI.ViewModels.Keyboards.Base;

namespace OptiKey.UI.ViewModels.Keyboards
{
    public class Minimised : BackActionKeyboard
    {
        public Minimised(Action backAction) : base(backAction)
        {
        }
    }
}

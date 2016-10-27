using System;
using OptiKey.UI.ViewModels.Keyboards.Base;

namespace OptiKey.UI.ViewModels.Keyboards
{
    public class Mouse : BackActionKeyboard
    {
        public Mouse(Action backAction) : base(backAction)
        {
        }
    }
}

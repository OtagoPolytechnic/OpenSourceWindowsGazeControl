using System;
using OptiKey.UI.ViewModels.Keyboards.Base;

namespace OptiKey.UI.ViewModels.Keyboards
{
    public class Menu : BackActionKeyboard
    {
        public Menu(Action backAction) : base(backAction)
        {
        }
    }
}

using System;
using OptiKey.UI.ViewModels.Keyboards.Base;

namespace OptiKey.UI.ViewModels.Keyboards
{
    public class Language : BackActionKeyboard
    {
        public Language(Action backAction) : base(backAction)
        {
        }
    }
}

using System;
using OptiKey.UI.ViewModels.Keyboards.Base;

namespace OptiKey.UI.ViewModels.Keyboards
{
    public class ConversationNumericAndSymbols : BackActionKeyboard, IConversationKeyboard
    {
        public ConversationNumericAndSymbols(Action backAction) : base(backAction, simulateKeyStrokes: false)
        {
        }
    }
}

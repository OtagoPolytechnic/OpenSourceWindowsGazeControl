using System;
using System.ComponentModel;

namespace OptiKey.Models
{
    public interface ILastMouseActionStateManager : INotifyPropertyChanged
    {
        Action LastMouseAction { get; set; }
        bool LastMouseActionExists { get; }
    }
}

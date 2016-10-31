using System;
using System.ComponentModel;
using OptiKey.Enums;
using OptiKey.Models;

namespace OptiKey.Services
{
    public interface IKeyStateService : INotifyPropertyChanged
    {
        bool SimulateKeyStrokes { get; set; }
        NotifyingConcurrentDictionary<KeyValue, double> KeySelectionProgress { get; }
        NotifyingConcurrentDictionary<KeyValue, KeyDownStates> KeyDownStates { get; }
        KeyEnabledStates KeyEnabledStates { get; }

        void ProgressKeyDownState(KeyValue keyValue);
    }
}

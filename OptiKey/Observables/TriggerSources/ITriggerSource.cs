using System;
using OptiKey.Enums;
using OptiKey.Models;

namespace OptiKey.Observables.TriggerSources
{
    public interface ITriggerSource
    {
        RunningStates State { get; set; }
        IObservable<TriggerSignal> Sequence { get; }
    }
}

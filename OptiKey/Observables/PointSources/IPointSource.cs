using System;
using System.Collections.Generic;
using System.Reactive;
using System.Windows;
using OptiKey.Enums;
using OptiKey.Models;

namespace OptiKey.Observables.PointSources
{
    public interface IPointSource
    {
        RunningStates State { get; set; }
        Dictionary<Rect, KeyValue> PointToKeyValueMap { set; }
        IObservable<Timestamped<PointAndKeyValue?>> Sequence { get; }
    }
}

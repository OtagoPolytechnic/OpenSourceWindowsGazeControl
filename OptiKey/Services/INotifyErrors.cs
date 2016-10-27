using System;

namespace OptiKey.Services
{
    public interface INotifyErrors
    {
        event EventHandler<Exception> Error;
    }
}

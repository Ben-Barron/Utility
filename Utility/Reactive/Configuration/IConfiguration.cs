using System;
using System.Reactive;

namespace Utility.Reactive.Configuration
{
    public interface IConfiguration
    {
        IObservable<Unit> SaveRequested { get; }
    }
}

using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Utility.Reactive.Extensions
{
    public static class IObservableExtensions
    {
        public static IObservable<T> AsBehavior<T>(this IObservable<T> observable, IDisposablesHandler disposablesHandler, T defaultValue = default(T))
        {
            var connectable = AsBehavior(observable, defaultValue);
            connectable.Connect().DisposeWith(disposablesHandler);

            return connectable;
        }

        public static IConnectableObservable<T> AsBehavior<T>(this IObservable<T> observable, T defaultValue = default(T))
        {
            return observable.Multicast(new BehaviorSubject<T>(defaultValue));
        }

        public static IObservable<bool> WhenTrue(this IObservable<bool> observable)
        {
            return observable.Where(value => value);
        }
    }
}

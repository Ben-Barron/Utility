using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Utility.Reactive.Extensions
{
    public static class IObservableExtensions
    {
        public static IObservable<T> AsBehavior<T>(this IObservable<T> observable, IDisposablesHandler disposablesHandler)
        {
            return AsBehavior(observable, disposablesHandler, default(T));
        }

        public static IObservable<T> AsBehavior<T>(this IObservable<T> observable, IDisposablesHandler disposablesHandler, T defaultValue)
        {
            var connectable = AsBehavior(observable, defaultValue);
            connectable.Connect().DisposeWith(disposablesHandler);

            return connectable;
        }

        public static IConnectableObservable<T> AsBehavior<T>(this IObservable<T> observable)
        {
            return AsBehavior(observable, default(T));
        }

        public static IConnectableObservable<T> AsBehavior<T>(this IObservable<T> observable, T defaultValue)
        {
            return observable.Multicast(new BehaviorSubject<T>(defaultValue));
        }

        public static T Value<T>(this IObservable<T> observable)
        {
            return observable.FirstAsync().Wait();
        }

        public static IObservable<bool> WhenTrue(this IObservable<bool> observable)
        {
            return observable.Where(value => value);
        }
    }
}

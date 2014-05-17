using System;
using System.Reactive.Disposables;

namespace Utility.Reactive.Extensions
{
    public static class IDisposableExtensions
    {
        public static void DisposeWith(this IDisposable disposable, IDisposablesHandler disposablesHandler)
        {
            disposablesHandler.AddDisposable(disposable);
        }

        public static void DisposeWith(this IDisposable disposable, CompositeDisposable compositeDisposable)
        {
            compositeDisposable.Add(disposable);
        }
    }
}

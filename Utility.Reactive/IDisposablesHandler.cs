using System;

namespace Utility.Reactive
{
    public interface IDisposablesHandler
    {
        IDisposableGroup Disposables { get; }
    }

    // Extensions are here as they are actually part of the required implementation.
    public static class IDisposablesHandlerExtensions
    {
        public static void AddDisposable(this IDisposablesHandler disposablesHandler, IDisposable disposable)
        {
            disposablesHandler.Disposables.Add(disposable);
        }

        public static void DisposeNow(this IDisposablesHandler disposablesHandler, IDisposable disposable)
        {
            disposablesHandler.Disposables.Remove(disposable);
            disposable.Dispose();
        }
    }
}

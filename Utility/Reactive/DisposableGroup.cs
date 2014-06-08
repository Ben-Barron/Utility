using System;
using System.Reactive.Disposables;

namespace Utility.Reactive
{
    public sealed class DisposableGroup : IDisposable, IDisposableGroup
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        public void Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }

        public void Remove(IDisposable disposable)
        {
            _disposables.Remove(disposable);
        }

        // Don't need full pattern as its a sealed class and can safely call dispose on a 
        // CompositeDisposable from any thread mulitple times and it will only dispose once.
        // There is a unit test to cover this behaviour to protect against changes to RX.
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}

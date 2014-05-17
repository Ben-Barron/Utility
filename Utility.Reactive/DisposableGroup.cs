using System;
using System.Reactive.Disposables;

namespace Utility.Reactive
{
    public class DisposableGroup : IDisposable, IDisposableGroup
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

        #region "IDisposable implementation"

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

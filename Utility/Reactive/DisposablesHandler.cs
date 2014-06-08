using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Reactive
{
    public abstract class DisposablesHandler : IDisposable, IDisposablesHandler
    {
        private readonly DisposableGroup _disposables = new DisposableGroup();

        public IDisposableGroup Disposables { get { return _disposables; } }

        #region "IDisposable implementation"

        private volatile bool _isDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                if (disposing)
                {
                    _disposables.Dispose();
                }

                _isDisposed = true;
            }
        }

        #endregion
    }
}

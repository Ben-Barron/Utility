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

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

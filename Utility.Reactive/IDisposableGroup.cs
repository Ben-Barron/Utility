using System;

namespace Utility.Reactive
{
    public interface IDisposableGroup
    {
        void Add(IDisposable disposable);
        void Remove(IDisposable disposable);
    }
}

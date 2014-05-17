using System;

namespace Utility.Extensions
{
    public static class IDisposableExtensions
    {
        public static void SafeDispose(this IDisposable disposable)
        {
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}

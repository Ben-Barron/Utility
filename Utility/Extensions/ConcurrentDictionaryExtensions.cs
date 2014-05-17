using System.Collections.Concurrent;

namespace Utility.Extensions
{
    public static class ConcurrentDictionaryExtensions
    {
        public static bool TryRemove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            return dictionary.TryRemove(key, out value);
        }
    }
}

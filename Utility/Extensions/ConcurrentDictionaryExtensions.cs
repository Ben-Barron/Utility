using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Utility.Extensions
{
    public static class ConcurrentDictionaryExtensions
    {
        public static bool TryRemove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            return dictionary.TryRemove(key, out value);
        }

        /// <remarks>
        /// HACK: is atomic at time of writing! Unlikely to change but a unit test exists to test it as best it can.
        /// </remarks>
        public static bool TryRemove<TKey, TValue>(this ICollection<KeyValuePair<TKey, TValue>> collection, TKey key, TValue value)
        {
            return collection.Remove(new KeyValuePair<TKey, TValue>(key, value));
        }
    }
}

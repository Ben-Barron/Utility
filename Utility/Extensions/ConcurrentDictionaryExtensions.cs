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
        /// This is a hack but is atomic at time of writing! Unlikely to change but a unit test exists to test it as best it can (not 100%!)
        /// </remarks>
        public static bool TryRemove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            ICollection<KeyValuePair<TKey, TValue>> collection = dictionary;
            return collection.Remove(new KeyValuePair<TKey, TValue>(key, value));
        }
    }
}

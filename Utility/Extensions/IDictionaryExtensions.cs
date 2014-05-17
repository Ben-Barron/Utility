using System.Collections.Generic;

namespace Utility.Extensions
{
    public static class IDictionaryExtensions
    {
        public static bool ContainsKeyValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            TValue valueOut;

            if (dictionary.TryGetValue(key, out valueOut))
            {
                return false;
            }

            return value.Equals(valueOut);
        }
    }
}

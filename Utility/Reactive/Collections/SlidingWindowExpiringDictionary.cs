using System;
using System.Collections.Concurrent;

namespace Utility.Reactive.Collections
{
    public class SlidingWindowExpiringDictionary<TKey, TValue>
    {
        private readonly ConcurrentDictionary<TKey, Tuple<TValue, IDisposable, TimeSpan>> _dictionary = new ConcurrentDictionary<TKey, Tuple<TValue, IDisposable, TimeSpan>>();
        private readonly TimeSpan _defaultWindow;

        public SlidingWindowExpiringDictionary()
            : this(TimeSpan.FromHours(6))
        {
        }

        public SlidingWindowExpiringDictionary(TimeSpan defaultWindow)
        {
            _defaultWindow = defaultWindow;
        }

        TValue this[TKey key]
        {
            get
            {
                TValue value;
                TryGetValue(key, out value);

                return value;
            }
            set { AddOrUpdate(key, value, (k, v) => value); }
        }

        public void AddOrUpdate(TKey key, TValue value, Func<TKey, TValue, TValue> updateFunction)
        {
            AddOrUpdate(key, value, _defaultWindow, updateFunction);
        }

        public void AddOrUpdate(TKey key, TValue value, TimeSpan window, Func<TKey, TValue, TValue> updateFunction)
        {

        }

        public void TryAdd(TKey key, TValue value)
        {
            TryAdd(key, value, _defaultWindow);
        }

        public void TryAdd(TKey key, TValue value, TimeSpan window)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            return true;
        }

        public bool TryRemove(TKey key)
        {
            TValue value;
            return TryRemove(key, out value);
        }

        public bool TryRemove(TKey key, out TValue value)
        {
            Tuple<TValue, IDisposable, TimeSpan> tuple;
            var result = _dictionary.TryRemove(key, out tuple);

            if (result)
            {
                value = tuple.Item1;
                tuple.Item2.Dispose();
            }
            else
            {
                value = default(TValue);
            }

            return result;
        }
    }
}

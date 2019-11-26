using System;
using System.Collections.Concurrent;

namespace NcsCore.Pool
{
    public class NcsObjectPool<T>
    {
        private ConcurrentBag<T> _objects;
        protected Func<T> _objectGenerator;

        public NcsObjectPool(Func<T> objectGenerator)
        {
            _objects = new ConcurrentBag<T>();

            if (objectGenerator != null)
            {
                _objectGenerator = objectGenerator;
            }
            else
            {
                _objectGenerator = (Activator.CreateInstance<T>);
            }
        }

        public T GetObject()
        {
            T item;
            if (_objects.TryTake(out item)) return item;
            return _objectGenerator();
        }

        public void PutObject(T item)
        {
            _objects.Add(item);
        }
    }
}

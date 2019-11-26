using System;
using System.Collections.Concurrent;

namespace NcsCore.Pool
{
    public class NcsArrayPool<T>
    {
        private ConcurrentBag<T[]> _objects;
        private Func<T[]> _objectGenerator;

        private int _poolSize;

        public NcsArrayPool(int poolSize, Func<T[]> objectGenerator)
        {
            _objects = new ConcurrentBag<T[]>();
            _poolSize = poolSize;
            if (objectGenerator != null)
            {
                _objectGenerator = objectGenerator;
            }
            else
            {
                _objectGenerator = (()=> new T[_poolSize]);
            }
        }

        public T[] GetObject()
        {
            T[] item;
            if (_objects.TryTake(out item)) return item;
            return _objectGenerator();
        }

        public void PutObject(T[] item)
        {
            _objects.Add(item);
        }
    }
}
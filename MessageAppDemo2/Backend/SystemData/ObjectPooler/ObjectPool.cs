using System;
using System.Collections.Concurrent;

namespace MessageAppDemo.Backend.SystemData.ObjectPooler
{
    public class ObjectPool<T> : IObjectPooler<T>
    {
        private readonly ConcurrentBag<T> _objects;
        private readonly Func<T> _objectGenerator;
        public ObjectPool(Func<T> objectGenerator)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentException(nameof(objectGenerator));
            _objects = new ConcurrentBag<T>();
        }

        public T Get() => _objects.TryTake(out T item) ? item : _objectGenerator();
        public void Return(T item) => _objects.Add(item);
    }
    public interface IObjectPooler<T>
    {
        T Get();
        void Return(T item);
    }

}

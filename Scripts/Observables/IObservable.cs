using System;

namespace Common.Observables
{
    public interface IObservable<T>
    {
        T Value { get; set; }

        void Listen(Action<T> watcher);
        void Listen(Action<T> watcher, Func<T, bool> where);
        void Watch(Action<T> watcher);
        void Watch(Action<T> watcher, Func<T, bool> where);
        void Unwatch(Action<T> watcher);
        void Clear();
    }
}
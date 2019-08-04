using UnityEngine;
using System;
using System.Collections.Generic;

namespace Observables
{
    public class Observable<T> : IObservable<T> where T : struct, IEquatable<T>
    {
        private T value;
        public T Value
        {
            get => value;

            set
            {
                if (this.value.Equals(value))
                    return;

                this.value = value;
                NotifyValueChanged();
            }
        }

        private static Func<T, bool> trueFilter = (t) => true;

        private List<Action<T>> watchers = new List<Action<T>>(8);
        private List<Func<T, bool>> filters = new List<Func<T, bool>>(8);

        public Observable() : this(default)
        { }

        public Observable(T value)
        {
            this.value = value;
        }

        public void Listen(Action<T> watcher)
        {
            Listen(watcher, trueFilter);
        }

        public void Listen(Action<T> watcher, Func<T, bool> where)
        {
            watchers.Add(watcher);
            filters.Add(where);
        }

        public void Watch(Action<T> watcher)
        {
            Watch(watcher, trueFilter);
        }

        public void Watch(Action<T> watcher, Func<T, bool> where)
        {
            Listen(watcher, where);
            if (where(value))
                watcher(value);
        }

        public void Unwatch(Action<T> watcher)
        {
            int index = watchers.LastIndexOf(watcher);
            watchers.RemoveAt(index);
            filters.RemoveAt(index);
        }

        public void Clear()
        {
            watchers.Clear();
            filters.Clear();
        }

        private void NotifyValueChanged()
        {
            int count = watchers.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                if (filters[i].Invoke(value))
                    watchers[i].Invoke(value);
            }
        }

        public static implicit operator T(Observable<T> observable) => observable.value;
        public static implicit operator Observable<T>(T value) => new Observable<T>(value);
    }
}
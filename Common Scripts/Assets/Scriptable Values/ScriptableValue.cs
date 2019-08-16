using Common.Observables;
using System;
using UnityEngine;


namespace Common
{
    public partial class ScriptableValue<T> : ScriptableObject, Observables.IObservable<T> where T : struct, IEquatable<T>
    {
        [SerializeField]
        protected T value;

        private Observable<T> observable;


        public void Listen(Action<T> watcher)
        {
            observable.Listen(watcher);
        }

        public void Listen(Action<T> watcher, Func<T, bool> where)
        {
            observable.Listen(watcher, where);
        }

        public void Watch(Action<T> watcher)
        {
            observable.Watch(watcher);
        }

        public void Watch(Action<T> watcher, Func<T, bool> where)
        {
            observable.Watch(watcher, where);
        }

        public void Unwatch(Action<T> watcher)
        {
            observable.Unwatch(watcher);
        }

        public void Clear()
        {
            observable.Clear();
        }

        public static implicit operator T(ScriptableValue<T> value) => value.Value;

        private void Awake()
        {
            observable = Value;
        }

        private void OnValidate()
        {
            if (observable != null)
                observable.Value = Value;
        }
    }

#if !UNITY_EDITOR

partial class ScriptableValue<T>
{
    public T Value
    {
        get => value;
        set
        {
            if (this.value.Equals(value))
                return;

            this.value = value;
            observable.Value = Value;
        }
    }

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}

#else

    public partial class ScriptableValue<T>
    {
        public T Value
        {
            get => keepPlaymodeChanges ? value : savedValue;
            set
            {
                if (Value.Equals(value))
                    return;

                if (keepPlaymodeChanges)
                    this.value = value;
                else
                    savedValue = value;

                observable.Value = Value;
            }
        }

        [SerializeField]
        private bool keepPlaymodeChanges;

        [SerializeField, HideInInspector]
        protected T savedValue;

        private void OnEnable()
        {
            hideFlags = HideFlags.DontUnloadUnusedAsset;
            savedValue = value;
        }
    }

#endif
}
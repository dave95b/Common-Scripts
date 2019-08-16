using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Common.Collections.Specialized
{
    [Serializable]
    public readonly struct ListFragment<T> : IEquatable<ListFragment<T>>
    {
        private readonly List<T> list;
        private readonly int start;
        public readonly int Count;

        public T this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => list[start + i];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => list[start + i] = value;
        }

        public ListFragment(List<T> list) : this(list, 0, list.Count) { }
        public ListFragment(List<T> list, int count) : this(list, 0, count) { }

        public ListFragment(List<T> list, int start, int count)
        {
            ThrowHelper.ThrowIfWrongArguments(list, start, count);

            this.list = list;
            this.start = start;
            Count = count;
        }

        public bool Equals(ListFragment<T> other)
        {
            return list == other.list &&
                   start == other.start &&
                   Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            if (obj is ListFragment<T> other)
                return Equals(other);
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = -1501397390;
            hashCode = hashCode * -1521134295 + list.GetHashCode();
            hashCode = hashCode * -1521134295 + start;
            hashCode = hashCode * -1521134295 + Count;
            return hashCode;
        }

        public static bool operator ==(ListFragment<T> fragment1, ListFragment<T> fragment2) => fragment1.Equals(fragment2);
        public static bool operator !=(ListFragment<T> fragment1, ListFragment<T> fragment2) => !fragment1.Equals(fragment2);


        public ListEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(list, start, Count);
        }
    }
}
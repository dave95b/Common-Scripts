using System;
using System.Collections;
using System.Collections.Generic;

namespace Common.Collections.Generic
{
    public readonly struct ReadOnlyFragment<T> : IReadOnlyList<T>, IEquatable<ReadOnlyFragment<T>>
    {
        private readonly IReadOnlyList<T> list;
        private readonly int start;

        public T this[int i] => list[start + i];
        public int Count { get; }


        public ReadOnlyFragment(IReadOnlyList<T> list) : this(list, 0, list.Count) { }
        public ReadOnlyFragment(IReadOnlyList<T> list, int count) : this(list, 0, count) { }
        public ReadOnlyFragment(IReadOnlyList<T> list, int start, int count)
        {
            ThrowHelper.ThrowIfWrongArguments(list, start, count);

            this.list = list;
            this.start = start;
            Count = count;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = start; i < Count; i++)
                yield return list[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            return obj is ReadOnlyFragment<T> fragment && Equals(fragment);
        }

        public bool Equals(ReadOnlyFragment<T> other)
        {
            return EqualityComparer<IReadOnlyList<T>>.Default.Equals(list, other.list) &&
                   start == other.start &&
                   Count == other.Count;
        }

        public override int GetHashCode()
        {
            var hashCode = 1514803644;
            hashCode = hashCode * -1521134295 + EqualityComparer<IReadOnlyList<T>>.Default.GetHashCode(list);
            hashCode = hashCode * -1521134295 + start;
            hashCode = hashCode * -1521134295 + Count;
            return hashCode;
        }

        public static bool operator ==(ReadOnlyFragment<T> left, ReadOnlyFragment<T> right) => left.Equals(right);
        public static bool operator !=(ReadOnlyFragment<T> left, ReadOnlyFragment<T> right) => !(left == right);
    }
}
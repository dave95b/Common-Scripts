using System;
using System.Collections;
using System.Collections.Generic;

namespace Common.Collections.Generic
{
    public readonly struct CollectionFragment<T> : IReadOnlyList<T>, IEquatable<CollectionFragment<T>>
    {
        private readonly IList<T> list;
        private readonly int start;

        public T this[int i]
        {
            get => list[start + i];
            set => list[start + i] = value;
        }
        public int Count { get; }


        public CollectionFragment(IList<T> list) : this(list, 0, list.Count) { }
        public CollectionFragment(IList<T> list, int count) : this(list, 0, count) { }
        public CollectionFragment(IList<T> list, int start, int count)
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
            return obj is CollectionFragment<T> fragment && Equals(fragment);
        }

        public bool Equals(CollectionFragment<T> other)
        {
            return EqualityComparer<IList<T>>.Default.Equals(list, other.list) &&
                   start == other.start &&
                   Count == other.Count;
        }

        public override int GetHashCode()
        {
            var hashCode = 1514803644;
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<T>>.Default.GetHashCode(list);
            hashCode = hashCode * -1521134295 + start;
            hashCode = hashCode * -1521134295 + Count;
            return hashCode;
        }

        public static bool operator ==(CollectionFragment<T> left, CollectionFragment<T> right) => left.Equals(right);
        public static bool operator !=(CollectionFragment<T> left, CollectionFragment<T> right) => !(left == right);
    }
}
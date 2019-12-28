using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Common.Collections.Generic
{
    public class IndexedMultiSet<T> : IList<T>, IReadOnlyList<T>
    {
        private List<T> list;
        private MultiDictionary indices;

        public IndexedMultiSet() : this(8, EqualityComparer<T>.Default) { }

        public IndexedMultiSet(int capacity) : this(capacity, EqualityComparer<T>.Default) { }

        public IndexedMultiSet(int capacity, IEqualityComparer<T> comparer)
        {
            list = new List<T>(capacity);
            indices = new MultiDictionary(capacity, comparer);
        }

        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => list[index];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                T current = list[index];
                indices.Assign(value, index, current);
                list[index] = value;
            }
        }

        private int count = 0;
        public int Count
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => count;
        }

        public bool IsReadOnly => false;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T item)
        {
            list.Add(item);
            indices.Add(item, count);
            count++;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear()
        {
            list.Clear();
            indices.Clear();
            count = 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(T item)
        {
            return indices.Contains(item);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CountOf(T item)
        {
            return indices.CountOf(item);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int IndexOf(T item)
        {
            return indices.IndexOf(item);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int LastIndexOf(T item)
        {
            return indices.LastIndexOf(item);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Insert(int index, T item)
        {
            T current = list[index];
            Add(current);
            this[index] = item;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
                return false;

            RemoveAt(index);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveAt(int index)
        {
            T removed = list[index];
            if (index != count - 1)
            {
                list.RemoveAtSwapback(index);
                T current = list[index];
                indices.Assign(current, index, removed);
                indices.Remove(removed, count - 1);
            }
            else
            {
                list.RemoveAt(index);
                indices.Remove(removed, index);
            }
            count--;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int BinarySearch(T item)
        {
            return list.BinarySearch(item);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return list.BinarySearch(item, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            return list.BinarySearch(index, count, item, comparer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public List<T>.Enumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }


        private readonly struct MultiDictionary
        {
            private readonly Dictionary<T, List<int>> dictionary;

            public MultiDictionary(int capacity, IEqualityComparer<T> comparer) : this()
            {
                dictionary = new Dictionary<T, List<int>>(capacity, comparer);
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Add(T item, int index)
            {
                if (dictionary.TryGetValue(item, out List<int> indices))
                {
                    int indexPosition = indices.BinarySearch(index);
                    if (indexPosition < 0)
                        indices.Insert(~indexPosition, index);
                }
                else
                {
                    indices = new List<int> { index };
                    dictionary[item] = indices;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Clear()
            {
                dictionary.Clear();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Contains(T item)
            {
                if (dictionary.TryGetValue(item, out var indices))
                    return indices.Count > 0;

                return false;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int CountOf(T item)
            {
                if (dictionary.TryGetValue(item, out var itemIndices))
                    return itemIndices.Count;

                return 0;
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int IndexOf(T item)
            {
                if (dictionary.TryGetValue(item, out var itemIndices))
                    return itemIndices.Count > 0 ? itemIndices[0] : -1;

                return -1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public int LastIndexOf(T item)
            {
                if (dictionary.TryGetValue(item, out var itemIndices))
                    return itemIndices.Count > 0 ? itemIndices[itemIndices.Count - 1] : -1;

                return -1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Assign(T item, int index, T oldItem)
            {
                Remove(oldItem, index);
                Add(item, index);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Remove(T item, int index)
            {
                var indices = dictionary[item];
                indices.Remove(index);
            }
        }
    }
}
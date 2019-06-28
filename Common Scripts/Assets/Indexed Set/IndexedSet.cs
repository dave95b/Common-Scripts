using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class IndexedSet<T> : IList<T> where T : IEquatable<T>
{
    private List<T> list;
    private Dictionary<T, int> indices;

    public IndexedSet() : this(8, EqualityComparer<T>.Default) { }

    public IndexedSet(int capacity) : this(capacity, EqualityComparer<T>.Default) { }

    public IndexedSet(int capacity, IEqualityComparer<T> comparer)
    {
        list = new List<T>(capacity);
        indices = new Dictionary<T, int>(capacity, comparer);
    }


    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => list[index];
        set
        {
            T current = list[index];
            if (current.Equals(value))
                return;

            int valueIndex = IndexOf(value);
            if (valueIndex == -1)
                indices.Remove(current);
            else
            {
                // Swap
                list[valueIndex] = current;
                indices[current] = valueIndex;
            }

            list[index] = value;
            indices[value] = index;
        }
    }

    public int Count
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => list.Count;
    }

    public bool IsReadOnly => false;


    public bool Add(T item)
    {
        if (Contains(item))
            return false;

        indices[item] = Count;
        list.Add(item);

        return true;
    }

    void ICollection<T>.Add(T item)
    {
        Add(item);
    }

    public void Clear()
    {
        list.Clear();
        indices.Clear();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(T item)
    {
        return indices.ContainsKey(item);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void CopyTo(T[] array, int arrayIndex)
    {
        list.CopyTo(array, arrayIndex);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int IndexOf(T item)
    {
        if (indices.TryGetValue(item, out int index))
            return index;

        return -1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Insert(int index, T item)
    {
        if (Contains(item))
            return false;

        list.Insert(index, item);
        UpdateIndicesFrom(index);

        return true;
    }

    void IList<T>.Insert(int index, T item)
    {
        Insert(index, item);
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
        indices.Remove(removed);

        list.RemoveAt(index);
        UpdateIndicesFrom(index);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Sort()
    {
        Sort(0, Count, null);
    }

    public void Sort(Comparison<T> comparison)
    {
        if (comparison is null)
            throw new ArgumentNullException("comparison");

        IComparer<T> comparer = new FunctorComparer(comparison);
        Sort(0, Count, comparer);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Sort(IComparer<T> comparer)
    {
        Sort(0, Count, comparer);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Sort(int index, int count, IComparer<T> comparer)
    {
        list.Sort(index, count, comparer);
        UpdateIndicesFrom(0);
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


    private void UpdateIndicesFrom(int index)
    {
        int count = Count;
        for (int i = index; i < count; i++)
        {
            T elem = list[i];
            indices[elem] = i;
        }
    }

    private class FunctorComparer : IComparer<T>
    {
        private readonly Comparison<T> comparison;

        public FunctorComparer(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public int Compare(T x, T y)
        {
            return comparison(x, y);
        }
    }
}

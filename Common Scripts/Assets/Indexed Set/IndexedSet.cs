using System;
using System.Collections;
using System.Collections.Generic;

public class IndexedSet<T> : IList<T>
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

    public int Count => list.Count;
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

    public bool Contains(T item)
    {
        return indices.ContainsKey(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        list.CopyTo(array, arrayIndex);
    }

    public int IndexOf(T item)
    {
        if (indices.TryGetValue(item, out int index))
            return index;

        return -1;
    }

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

    public bool Remove(T item)
    {
        int index = IndexOf(item);

        if (index == -1)
            return false;

        RemoveAt(index);
        return true;
    }

    public void RemoveAt(int index)
    {
        T removed = list[index];
        indices.Remove(removed);

        list.RemoveAt(index);
        UpdateIndicesFrom(index);
    }

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

    public void Sort(IComparer<T> comparer)
    {
        Sort(0, Count, comparer);
    }

    public void Sort(int index, int count, IComparer<T> comparer)
    {
        list.Sort(index, count, comparer);
        UpdateIndicesFrom(0);
    }

    public int BinarySearch(T item)
    {
        return list.BinarySearch(item);
    }

    public int BinarySearch(T item, IComparer<T> comparer)
    {
        return list.BinarySearch(item, comparer);
    }

    public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
    {
        return list.BinarySearch(index, count, item, comparer);
    }

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
        for (int i = index; i < Count; i++)
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

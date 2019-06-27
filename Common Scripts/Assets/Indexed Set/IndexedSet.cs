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
            //T oldValue = list[index];
            //indices.Remove(oldValue);

            //list[index] = value;
            //indices[value] = index;
        }
    }

    public int Count { get; }
    public bool IsReadOnly { get; }


    public bool Add(T item)
    {
        throw new NotImplementedException();
    }

    void ICollection<T>.Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public bool Insert(int index, T item)
    {
        throw new NotImplementedException();
    }
    void IList<T>.Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    //TODO: all Sort methods should invoke the last one
    public void Sort()
    {
        //list.Sort();
    }

    public void Sort(Comparison<T> comparison)
    {
        //IComparer<T> comparer = new FunctorComparer(comparison);
        //list.Sort(comparison);
    }

    public void Sort(IComparer<T> comparer)
    {
        //list.Sort(comparer);
    }

    public void Sort(int index, int count, IComparer<T> comparer)
    {
        //list.Sort(index, count, comparer);
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

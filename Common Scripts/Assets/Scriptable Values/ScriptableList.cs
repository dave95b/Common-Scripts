using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableList<T> : ScriptableObject, IList<T>, IEnumerable<T>
{
    public List<T> List;

    public T this[int i]
    {
        get => List[i];
        set => List[i] = value;
    }

    public int Count => List.Count;
    public bool IsReadOnly => false;


    public void Add(T item)
    {
        List.Add(item);
    }

    public void Clear()
    {
        List.Clear();
    }

    public bool Contains(T item)
    {
        return List.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        List.CopyTo(array, arrayIndex);
    }

    public int IndexOf(T item)
    {
        return List.IndexOf(item);
    }

    public void Insert(int index, T item)
    {
        List.Insert(index, item);
    }

    public bool Remove(T item)
    {
        int index = List.IndexOf(item);

        if (index >= 0)
        {
            List.RemoveAt(index);
            return true;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        List.RemoveAt(index);
    }

    public ListEnumerator<T> GetEnumerator()
    {
        return new ListEnumerator<T>(List);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new ListEnumerator<T>(List);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new ListEnumerator<T>(List);
    }

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}

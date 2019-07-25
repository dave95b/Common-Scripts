using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableArray<T> : ScriptableObject, IReadOnlyList<T>, IEnumerable<T>
{
    public T[] Array;
    public ref T this[int i] => ref Array[i];
    T IReadOnlyList<T>.this[int i] => Array[i];

    public int Length => Array.Length;
    int IReadOnlyCollection<T>.Count => Array.Length;


    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }


    public ArrayEnumerator<T> GetEnumerator()
    {
        return new ArrayEnumerator<T>(Array);
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return new ArrayEnumerator<T>(Array);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new ArrayEnumerator<T>(Array);
    }
}

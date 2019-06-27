using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableArray<T> : ScriptableObject, IEnumerable<T>
{
    public T[] Array;
    public ref T this[int i] => ref Array[i];
    public int Length => Array.Length;

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

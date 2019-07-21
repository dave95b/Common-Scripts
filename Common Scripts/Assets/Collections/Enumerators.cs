using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


public struct ArrayEnumerator<T> : IEnumerator<T>
{
    private readonly T[] array;
    private readonly int start, end;
    private int index;

    public ref T Current => ref array[index];
    T IEnumerator<T>.Current => array[index];
    object IEnumerator.Current => array[index];


    public ArrayEnumerator(T[] array) : this(array, start: 0, array.Length) { }
    public ArrayEnumerator(T[] array, int length) : this(array, start: 0, length) { }

    public ArrayEnumerator(T[] array, int start, int length)
    {
        this.array = array;
        this.start = start;
        end = start + length;
        index = start - 1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        int i = index + 1;
        if (i < end)
        {
            index = i;
            return true;
        }

        return false;
    }

    public void Dispose()
    {
    }

    public void Reset()
    {
        index = start - 1;
    }
}

public struct ListEnumerator<T> : IEnumerator<T>
{
    private readonly List<T> list;
    private readonly int start, end;
    private int index;

    public T Current => list[index];
    object IEnumerator.Current => list[index];


    public ListEnumerator(List<T> list) : this(list, start: 0, list.Count) { }
    public ListEnumerator(List<T> list, int count) : this(list, start: 0, count) { }

    public ListEnumerator(List<T> list, int start, int count)
    {
        this.list = list;
        this.start = start;
        end = start + count;
        index = start - 1;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool MoveNext()
    {
        int i = index + 1;
        if (i < end)
        {
            index = i;
            return true;
        }

        return false;
    }

    public void Dispose()
    {
    }

    public void Reset()
    {
        index = start - 1;
    }
}

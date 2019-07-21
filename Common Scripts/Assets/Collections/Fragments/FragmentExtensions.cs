using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FragmentExtensions
{
    public static ListFragment<T> Slice<T>(this List<T> list, int index, int count)
    {
        return new ListFragment<T>(list, index, count);
    }

    public static ArrayFragment<T> Slice<T>(this T[] array, int index, int length)
    {
        return new ArrayFragment<T>(array, index, length);
    }
}

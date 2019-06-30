﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CollectionExtensions
{
    #region IList

    public static void Shuffle<T>(this IList<T> list)
    {
        int count = list.Count;
        var last = count - 1;

        for (int i = 0; i < last; ++i)
        {
            int randomIndex = Random.Range(i, count);
            T tmp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = tmp;
        }
    }

    public static T GetRandom<T>(this IList<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static void Swap<T>(this IList<T> list, int sourceIndex, int destinationIndex)
    {
        if (sourceIndex == destinationIndex)
            return;

        T temp = list[sourceIndex];
        list[sourceIndex] = list[destinationIndex];
        list[destinationIndex] = temp;
    }

    public static void RemoveAtSwapback<T>(this IList<T> list, int index)
    {
        int lastIndex = list.Count - 1;
        list[index] = list[lastIndex];
        list.RemoveAt(lastIndex);
    }

    public static ListFragment<T> Slice<T>(this List<T> list, int start, int count)
    {
        return new ListFragment<T>(list, start, count);
    }

    #endregion IList

    #region Arrays

    public static void Shuffle<T>(this T[] array)
    {
        int count = array.Length;
        var last = count - 1;

        for (int i = 0; i < last; ++i)
        {
            int randomIndex = Random.Range(i, count);
            T tmp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = tmp;
        }
    }

    public static T GetRandom<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }


    public static void Swap<T>(this T[] array, int sourceIndex, int destinationIndex)
    {
        if (sourceIndex == destinationIndex)
            return;

        T temp = array[sourceIndex];
        array[sourceIndex] = array[destinationIndex];
        array[destinationIndex] = temp;
    }

    public static ArrayFragment<T> Slice<T>(this T[] array, int startIndex, int length)
    {
        return new ArrayFragment<T>(array, startIndex, length);
    }

    #endregion Arrays
}
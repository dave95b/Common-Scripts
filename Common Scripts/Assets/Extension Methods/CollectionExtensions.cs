using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public static class CollectionExtensions
{
    #region IList

    public static void Shuffle<T>(this IList<T> list)
    {
        Shuffle(list, 0, list.Count);
    }

    public static void Shuffle<T>(this IList<T> list, int count)
    {
        Shuffle(list, 0, count);
    }

    public static void Shuffle<T>(this IList<T> list, int start, int count)
    {
        Assert.IsTrue(start >= 0);
        Assert.IsTrue(start + count <= list.Count);

        int last = start + count - 1;

        for (int i = start; i < last; ++i)
        {
            int randomIndex = Random.Range(i, last + 1);
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

    #endregion IList

    #region Array

    public static void Shuffle<T>(this T[] array)
    {
        Shuffle(array, 0, array.Length);
    }

    public static void Shuffle<T>(this T[] array, int length)
    {
        Shuffle(array, 0, length);
    }

    public static void Shuffle<T>(this T[] array, int start, int length)
    {
        Assert.IsTrue(start >= 0);
        Assert.IsTrue(start + length <= array.Length);

        int last = start + length - 1;

        for (int i = start; i < last; ++i)
        {
            int randomIndex = Random.Range(i, last + 1);
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

    #endregion Array
}

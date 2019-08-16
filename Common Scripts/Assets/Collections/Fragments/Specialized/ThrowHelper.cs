using System;
using System.Collections.Generic;

namespace Common.Collections.Specialized
{
    internal enum CollectionType
    {
        array, list
    }

    internal static class ThrowHelper
    {

        internal static void ThrowIfWrongArguments<T>(T[] array, int start, int length)
        {
            if (array is null)
                ThrowCollectionNull(CollectionType.array);
            if (start < 0 || start > array.Length)
                ThrowOutOfBounds(start, array.Length);
            if (start + length > array.Length)
                ThrowOutOfBounds(start, length, array.Length);
            if (length <= 0)
                ThrowWrongLength(length);
        }

        internal static void ThrowIfWrongArguments<T>(List<T> list, int start, int length)
        {
            if (list is null)
                ThrowCollectionNull(CollectionType.list);
            if (start < 0 || start > list.Count)
                ThrowOutOfBounds(start, list.Count);
            if (start + length > list.Count)
                ThrowOutOfBounds(start, length, list.Count);
            if (length <= 0)
                ThrowWrongLength(length);
        }

        internal static void ThrowCollectionNull(CollectionType collectionType)
        {
            string collectionName = collectionType == CollectionType.array ? "Array" : "List";
            throw new ArgumentException($"{collectionName} can not be null");
        }

        internal static void ThrowOutOfBounds(int start, int collectionSize)
        {
            throw new ArgumentException($"'start' ({start})  parameter is out of bounds ({collectionSize})");
        }

        internal static void ThrowOutOfBounds(int start, int length, int collectionSize)
        {
            throw new ArgumentException($"'start' + 'length' ({start + length}) exceeds array's bounds ({collectionSize})");
        }

        internal static void ThrowWrongLength(int length)
        {
            throw new ArgumentException($"'length' ({length}) can not be zero or negative");
        }
    }
}
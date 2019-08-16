using System;
using System.Collections.Generic;

namespace Common.Collections.Generic
{
    internal static class ThrowHelper
    {
        internal static void ThrowIfWrongArguments<T>(IList<T> list, int start, int count)
        {
            if (list is null)
                ThrowCollectionNull();
            if (start < 0 || start > list.Count)
                ThrowOutOfBounds(start, list.Count);
            if (start + count > list.Count)
                ThrowOutOfBounds(start, count, list.Count);
            if (count <= 0)
                ThrowWrongLength(count);
        }

        internal static void ThrowIfWrongArguments<T>(IReadOnlyList<T> list, int start, int count)
        {
            if (list is null)
                ThrowCollectionNull();
            if (start < 0 || start > list.Count)
                ThrowOutOfBounds(start, list.Count);
            if (start + count > list.Count)
                ThrowOutOfBounds(start, count, list.Count);
            if (count <= 0)
                ThrowWrongLength(count);
        }

        internal static void ThrowCollectionNull()
        {
            throw new ArgumentException($"List can not be null");
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
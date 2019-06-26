using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;

[Serializable]
public readonly struct ArrayFragment<T> : IEquatable<ArrayFragment<T>>
{
    private readonly T[] array;
    private readonly int start;
    public readonly int Length;

    public ref T this[int i]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref array[start + i];
    }

    public ArrayFragment(T[] array) : this(array, 0, array.Length) { }
    public ArrayFragment(T[] array, int length) : this(array, 0, length) { }

    public ArrayFragment(T[] array, int start, int length)
    {
        if (array is null)
            throw new ArgumentException("Array can not be null");
        if (start < 0 || start > array.Length)
            throw new ArgumentException($"'start' ({start})  parameter is out of array's bounds ({array.Length})");
        if (start + length > array.Length)
            throw new ArgumentException($"'start' + 'length' ({start + length}) exceeds array's bounds ({array.Length})");
        if (length <= 0)
            throw new ArgumentException($"'length' ({length}) can not be zero or negative");

        this.array = array;
        this.start = start;
        Length = length;
    }


    public bool Equals(ArrayFragment<T> other)
    {
        return array == other.array && 
               start == other.start &&
               Length == other.Length;
    }

    public override bool Equals(object obj)
    {
        if (obj is ArrayFragment<T> other)
            return Equals(other);
        return false;
    }

    public override int GetHashCode()
    {
        var hashCode = -1501397390;
        hashCode = hashCode * -1521134295 + array.GetHashCode();
        hashCode = hashCode * -1521134295 + start;
        hashCode = hashCode * -1521134295 + Length;
        return hashCode;
    }

    public static bool operator ==(ArrayFragment<T> fragment1, ArrayFragment<T> fragment2) => fragment1.Equals(fragment2);
    public static bool operator !=(ArrayFragment<T> fragment1, ArrayFragment<T> fragment2) => !fragment1.Equals(fragment2);


    public ArrayEnumerator<T> GetEnumerator()
    {
        return new ArrayEnumerator<T>(array, start, Length);
    }
}

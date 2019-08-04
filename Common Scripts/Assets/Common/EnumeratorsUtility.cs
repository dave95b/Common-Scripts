using System.Runtime.CompilerServices;

public static class EnumeratorsUtility
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool MoveNext(ref int index, int count)
    {
        int i = index + 1;
        if (i < count)
        {
            index = i;
            return true;
        }

        return false;
    }
}


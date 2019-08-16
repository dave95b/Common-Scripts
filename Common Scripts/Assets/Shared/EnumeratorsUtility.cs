using System.Runtime.CompilerServices;

namespace Common.Collections
{
    internal static class EnumeratorsUtility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool MoveNext(ref int index, int count)
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

}
using System.Collections.Generic;


namespace Common.Collections.Specialized
{
    public static class FragmentExtensions
    {
        public static ListFragment<T> Slice<T>(this List<T> list, int count)
        {
            return new ListFragment<T>(list, count);
        }

        public static ListFragment<T> Slice<T>(this List<T> list, int index, int count)
        {
            return new ListFragment<T>(list, index, count);
        }

        public static ListFragment<T> GetRandom<T>(this List<T> list, int count)
        {
            list.Shuffle(count);
            return new ListFragment<T>(list, count);
        }


        public static ArrayFragment<T> Slice<T>(this T[] array, int length)
        {
            return new ArrayFragment<T>(array, length);
        }

        public static ArrayFragment<T> Slice<T>(this T[] array, int index, int length)
        {
            return new ArrayFragment<T>(array, index, length);
        }

        public static ArrayFragment<T> GetRandom<T>(this T[] array, int count)
        {
            array.Shuffle(count);
            return new ArrayFragment<T>(array, count);
        }
    }
}
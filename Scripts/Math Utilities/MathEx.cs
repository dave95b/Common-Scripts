using System;
using UnityEngine;

namespace Common.MathUtilities
{
    public static class MathEx
    {
        private const int intSize7 = sizeof(int) * 7;

        private static bool IsPowerOfTwo(this int i) => i > 0 && (i & -i) == i;

        private static int Abs(this int i)
        {
            int mask = i >> intSize7;
            return (i ^ mask) - mask;
        }

        private static bool IsOdd(this int i) => (i & 1) == 1;

        private static bool IsEven(this int i) => (i & 1) == 0;

        private static float DistanceTo(this in Vector3 v1, in Vector3 v2) => (float)Math.Sqrt(v1.SqrDistanceTo(v2));

        private static float SqrDistanceTo(this in Vector3 v1, in Vector3 v2)
        {
            float x = v1.x - v2.x;
            float y = v1.y - v2.y;
            float z = v1.z - v2.z;

            return x * x + y * y + z * z;
        }
    }
}
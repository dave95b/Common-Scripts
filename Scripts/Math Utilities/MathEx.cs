using UnityEngine;
using System;

namespace Common.MathUtilities
{
    public static class MathEx
    {
        private const int intSize7 = sizeof(int) * 7;

        static bool IsPowerOfTwo(int i) => i > 0 && (i & -i) == i;

        static int Abs(int i)
        {
            int mask = i >> intSize7;
            return (i ^ mask) - mask;
        }

        static bool IsOdd(int i) => (i & 1) == 1;
        static bool IsEven(int i) => (i & 1) == 0;

        static float Distance(in Vector3 v1, in Vector3 v2) => (float)Math.Sqrt(SqrDistance(v1, v2));

        static float SqrDistance(in Vector3 v1, in Vector3 v2)
        {
            float x = v1.x - v2.x;
            float y = v1.y - v2.y;
            float z = v1.z - v2.z;

            return x * x + y * y + z * z;
        }
    }
}
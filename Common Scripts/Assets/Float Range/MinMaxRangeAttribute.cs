using UnityEngine;
using System.Collections.Generic;
using System;

namespace Common
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class MinMaxRangeAttribute : PropertyAttribute
    {
        public float Min { get; private set; }
        public float Max { get; private set; }

        public MinMaxRangeAttribute(float min, float max)
        {
            Min = Mathf.Min(min, max);
            Max = Mathf.Max(min, max);
        }
    }
}
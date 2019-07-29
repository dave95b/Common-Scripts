using UnityEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.UI;

namespace Benchmarks
{
    public static class PerformanceMeasure
    {
        public static void Display(Action action, int repeats, string name, Text text)
        {
            text.text = $"{name} time: {Average(action, repeats)} ms";
        }

        public static double Average(Action action, int repeats)
        {
            var s = new Stopwatch();

            double totalTime = 0f;

            for (int i = 0; i < repeats; i++)
            {
                s.Start();
                action();
                s.Stop();

                totalTime += s.Elapsed.TotalMilliseconds;
            }

            return totalTime / repeats;
        }
    }
}
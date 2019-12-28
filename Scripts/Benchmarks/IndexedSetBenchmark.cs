using Common.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Benchmarks
{
    internal class IndexedSetBenchmark : MonoBehaviour
    {
        [SerializeField]
        private int count, repeats;

        [SerializeField]
        private Text listText, setText, indexedSetText, multiSetText;

        private List<int> list;
        private HashSet<int> set;
        private IndexedSet<int> indexedSet;
        private IndexedMultiSet<int> multiSet;

        private int[] data;

        private void Start()
        {
            list = new List<int>(count);
            set = new HashSet<int>(new IntComparer());
            var comparer = new IntComparer();
            indexedSet = new IndexedSet<int>(count, comparer);
            multiSet = new IndexedMultiSet<int>(count, comparer);
            data = new int[count];
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                AddBenchmark();
            else if (Input.GetKeyDown(KeyCode.W))
                AddExistingBenchmark();
            else if (Input.GetKeyDown(KeyCode.E))
                RemoveBenchmark();
            else if (Input.GetKeyDown(KeyCode.R))
                ContainsBenchmark();
            else if (Input.GetKeyDown(KeyCode.T))
                RemoveAtBenchmark();
            else if (Input.GetKeyDown(KeyCode.Y))
                RemoveAtFirstBenchmark();
            else if (Input.GetKeyDown(KeyCode.A))
                IndexOfBenchmark();
            else if (Input.GetKeyDown(KeyCode.S))
                IndexerGetterBenchmark();
            else if (Input.GetKeyDown(KeyCode.D))
                IndexerSetterBenchmark();
            else if (Input.GetKeyDown(KeyCode.F))
                IndexerSetterExistingBenchmark();
        }

        private void AddBenchmark()
        {
            Benchmark(ListAdd, "List Add", listText, refill: false);
            Benchmark(SetAdd, "Set Add", setText, refill: false);
            Benchmark(IndexedSetAdd, "Indexed Set Add", indexedSetText, refill: false);
            Benchmark(MultiSetAdd, "Multi Set Add", multiSetText, refill: false);
        }

        private void AddExistingBenchmark()
        {
            Benchmark(SetAdd, "Set Add Existing", setText);
            Benchmark(IndexedSetAdd, "Indexed Set Add Existing", indexedSetText);
            Benchmark(MultiSetAdd, "Multi Set Add Existing", multiSetText);
        }


        private void ListAdd()
        {
            for (int i = 0; i < count; i++)
                list.Add(i);
        }

        private void SetAdd()
        {
            for (int i = 0; i < count; i++)
                set.Add(i);
        }

        private void IndexedSetAdd()
        {
            for (int i = 0; i < count; i++)
                indexedSet.Add(i);
        }

        private void MultiSetAdd()
        {
            for (int i = 0; i < count; i++)
                multiSet.Add(i);
        }


        private void RemoveBenchmark()
        {
            Benchmark(ListRemove, "List Remove", listText);
            Benchmark(SetRemove, "Set Remove", setText);
            Benchmark(IndexedSetRemove, "Indexed Set Remove", indexedSetText);
            Benchmark(MultiSetRemove, "Multi Set Remove", multiSetText);
        }

        private void ListRemove()
        {
            for (int i = 0; i < count; i++)
                list.Remove(data[i]);
        }

        private void SetRemove()
        {
            for (int i = 0; i < count; i++)
                set.Remove(data[i]);
        }

        private void IndexedSetRemove()
        {
            for (int i = 0; i < count; i++)
                indexedSet.Remove(data[i]);
        }

        private void MultiSetRemove()
        {
            for (int i = 0; i < count; i++)
                multiSet.Remove(data[i]);
        }



        private void ContainsBenchmark()
        {
            Benchmark(ListContains, "List Contains", listText);
            Benchmark(SetContains, "Set Contains", setText);
            Benchmark(IndexedSetContains, "Indexed Set Contains", indexedSetText);
            Benchmark(MultiSetContains, "Multi Set Contains", multiSetText);
        }

        private void ListContains()
        {
            bool c;
            for (int i = 0; i < count; i++)
                c = list.Contains(data[i]);
        }

        private void SetContains()
        {
            bool c;
            for (int i = 0; i < count; i++)
                c = set.Contains(data[i]);
        }

        private void IndexedSetContains()
        {
            bool c;
            for (int i = 0; i < count; i++)
                c = indexedSet.Contains(data[i]);
        }

        private void MultiSetContains()
        {
            bool c;
            for (int i = 0; i < count; i++)
                c = multiSet.Contains(data[i]);
        }


        private void RemoveAtBenchmark()
        {
            Benchmark(ListRemoveAt, "List Remove At (last)", listText);
            Benchmark(IndexedSetRemoveAt, "Indexed Set Remove At (last)", indexedSetText);
            Benchmark(MultiSetRemoveAt, "Multi Set Remove At (last)", multiSetText);
        }

        private void ListRemoveAt()
        {
            for (int i = 0; i < count; i++)
                list.RemoveAt(list.Count - 1);
        }

        private void IndexedSetRemoveAt()
        {
            for (int i = 0; i < count; i++)
                indexedSet.RemoveAt(indexedSet.Count - 1);
        }
        private void MultiSetRemoveAt()
        {
            for (int i = 0; i < count; i++)
                multiSet.RemoveAt(multiSet.Count - 1);
        }


        private void RemoveAtFirstBenchmark()
        {
            Benchmark(ListRemoveAtFirst, "List Remove At (first)", listText);
            Benchmark(IndexedSetRemoveAtFirst, "Indexed Set Remove At (first)", indexedSetText);
            Benchmark(MultiSetRemoveAtFirst, "Multi Set Remove At (first)", multiSetText);
        }

        private void ListRemoveAtFirst()
        {
            for (int i = 0; i < count; i++)
                list.RemoveAt(0);
        }

        private void IndexedSetRemoveAtFirst()
        {
            for (int i = 0; i < count; i++)
                indexedSet.RemoveAt(0);
        }

        private void MultiSetRemoveAtFirst()
        {
            for (int i = 0; i < count; i++)
                multiSet.RemoveAt(0);
        }


        private void IndexOfBenchmark()
        {
            Benchmark(ListIndexOf, "List Index Of", listText);
            Benchmark(IndexedSetIndexOf, "Indexed Set Index Of", indexedSetText);
            Benchmark(MultiSetIndexOf, "Multi Set Index Of", multiSetText);
        }

        private void ListIndexOf()
        {
            int index;
            for (int i = 0; i < count; i++)
                index = list.IndexOf(data[i]);
        }

        private void IndexedSetIndexOf()
        {
            int index;
            for (int i = 0; i < count; i++)
                index = indexedSet.IndexOf(data[i]);
        }

        private void MultiSetIndexOf()
        {
            int index;
            for (int i = 0; i < count; i++)
                index = multiSet.IndexOf(data[i]);
        }


        private void IndexerGetterBenchmark()
        {
            Benchmark(ListIndexerGetter, "List Indexer Getter", listText);
            Benchmark(IndexedSetIndexerGetter, "Indexed Set Indexer Getter", indexedSetText);
            Benchmark(MultiSetIndexerGetter, "Multi Set Indexer Getter", multiSetText);
        }

        private void ListIndexerGetter()
        {
            int value;
            for (int i = 0; i < count; i++)
                value = list[i];
        }

        private void IndexedSetIndexerGetter()
        {
            int value;
            for (int i = 0; i < count; i++)
                value = indexedSet[i];
        }

        private void MultiSetIndexerGetter()
        {
            int value;
            for (int i = 0; i < count; i++)
                value = multiSet[i];
        }


        private void IndexerSetterBenchmark()
        {
            Benchmark(ListIndexerSetter, "List Indexer Setter", listText);
            Benchmark(IndexedSetIndexerSetter, "Indexed Set Indexer Setter", indexedSetText);
            Benchmark(MultiSetIndexerSetter, "Multi Set Indexer Setter", multiSetText);
        }

        private void ListIndexerSetter()
        {
            for (int i = 0; i < count; i++)
                list[i] = -data[i];
        }

        private void IndexedSetIndexerSetter()
        {
            for (int i = 0; i < count; i++)
                indexedSet[i] = -data[i];
        }

        private void MultiSetIndexerSetter()
        {
            for (int i = 0; i < count; i++)
                multiSet[i] = -data[i];
        }


        private void IndexerSetterExistingBenchmark()
        {
            Benchmark(ListIndexerSetterExisting, "List Indexer Setter Existing", listText);
            Benchmark(IndexedSetIndexerSetterExisting, "Indexed Set Indexer Setter Existing", indexedSetText);
            Benchmark(MultiSetIndexerSetterExisting, "Multi Set Indexer Setter Existing", multiSetText);
        }

        private void ListIndexerSetterExisting()
        {
            for (int i = 0; i < count; i++)
                list[i] = data[i];
        }

        private void IndexedSetIndexerSetterExisting()
        {
            for (int i = 0; i < count; i++)
                indexedSet[i] = data[i];
        }

        private void MultiSetIndexerSetterExisting()
        {
            for (int i = 0; i < count; i++)
                multiSet[i] = data[i];
        }


        private void Benchmark(Action action, string name, Text text, bool refill = true)
        {
            var stopwatch = new Stopwatch();

            for (int i = 0; i < repeats; i++)
            {
                if (refill)
                    Refill();
                else
                    Clear();

                stopwatch.Start();
                action();
                stopwatch.Stop();
            }

            double averageTime = stopwatch.Elapsed.TotalMilliseconds / repeats;

            text.text = $"{name} time: {averageTime} ms";
        }

        private void Clear()
        {
            list.Clear();
            set.Clear();
            indexedSet.Clear();
            multiSet.Clear();
        }

        private void Refill()
        {
            Clear();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
                set.Add(i);
                indexedSet.Add(i);
                multiSet.Add(i);
                data[i] = i;
            }

            data.Shuffle();
        }
    }

    internal class IntComparer : IEqualityComparer<int>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(int x, int y)
        {
            return x == y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(int obj)
        {
            return obj;
        }
    }
}
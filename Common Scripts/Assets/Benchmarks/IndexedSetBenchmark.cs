using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class IndexedSetBenchmark : MonoBehaviour
{
    [SerializeField]
    private int count, repeats;

    [SerializeField]
    private Text listText, setText, indexedSetText;

    private List<int> list;
    private HashSet<int> set;
    private IndexedSet<int> indexedSet;

    private int[] data;

    private void Start()
    {
        list = new List<int>(count);
        set = new HashSet<int>(new IntComparer());
        indexedSet = new IndexedSet<int>(count, new IntComparer());
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
    }

    private void AddExistingBenchmark()
    {
        Benchmark(SetAdd, "Set Add Existing", setText);
        Benchmark(IndexedSetAdd, "Indexed Set Add Existing", indexedSetText);
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


    private void RemoveBenchmark()
    {
        Benchmark(ListRemove, "List Remove", listText);
        Benchmark(SetRemove, "Set Remove", setText);
        Benchmark(IndexedSetRemove, "Indexed Set Remove", indexedSetText);
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



    private void ContainsBenchmark()
    {
        Benchmark(ListContains, "List Contains", listText);
        Benchmark(SetContains, "Set Contains", setText);
        Benchmark(IndexedSetContains, "Indexed Set Contains", indexedSetText);
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


    private void RemoveAtBenchmark()
    {
        Benchmark(ListRemoveAt, "List Remove At", listText);
        Benchmark(IndexedSetRemoveAt, "Indexed Set Remove At", indexedSetText);
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


    private void IndexOfBenchmark()
    {
        Benchmark(ListIndexOf, "List Index Of", listText);
        Benchmark(IndexedSetIndexOf, "Indexed Set Index Of", indexedSetText);
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


    private void IndexerGetterBenchmark()
    {
        Benchmark(ListIndexerGetter, "List Indexer Getter", listText);
        Benchmark(IndexedSetIndexerGetter, "Indexed Set Indexer Getter", indexedSetText);
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


    private void IndexerSetterBenchmark()
    {
        Benchmark(ListIndexerSetter, "List Indexer Setter", listText);
        Benchmark(IndexedSetIndexerSetter, "Indexed Set Indexer Setter", indexedSetText);
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


    private void IndexerSetterExistingBenchmark()
    {
        Benchmark(ListIndexerSetterExisting, "List Indexer Setter Existing", listText);
        Benchmark(IndexedSetIndexerSetterExisting, "Indexed Set Indexer Setter Existing", indexedSetText);
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
    }

    private void Refill()
    {
        Clear();
        for (int i = 0; i < count; i++)
        {
            list.Add(i);
            set.Add(i);
            indexedSet.Add(i);
            data[i] = i;
        }

        data.Shuffle();
    }
}

class IntComparer : IEqualityComparer<int>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(int x, int y) => x == y;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetHashCode(int obj) => obj;
}

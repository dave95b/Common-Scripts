using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    //TODO: refactor
    [TestFixture]
    public class IndexedSetTests
    {
        private IndexedSet<int> set = new IndexedSet<int>();


        [SetUp]
        public void SetUp()
        {
            set.Clear();

            set.Add(10);
            set.Add(20);
            set.Add(30);
        }

        [Test]
        public void AddDistinct()
        {
            set.Clear();

            Assert.IsTrue(set.Add(0));
            Assert.IsTrue(set.Add(1));
            Assert.IsTrue(set.Add(2));

            Assert.AreEqual(3, set.Count);
            AssertItemsOrder();
        }

        [Test]
        public void AddNotDistinct()
        {
            set.Clear();

            Assert.IsTrue(set.Add(0));
            Assert.IsFalse(set.Add(0));
            Assert.IsTrue(set.Add(1));
            Assert.IsFalse(set.Add(1));

            Assert.AreEqual(2, set.Count);
            AssertItemsOrder();
        }

        [Test]
        public void IndexerGetter()
        {
            Assert.AreEqual(10, set[0]);
            Assert.AreEqual(20, set[1]);
            Assert.AreEqual(30, set[2]);
        }

        [Test]
        public void IndexerSetter()
        {
            set[0] = 40;
            Assert.AreEqual(40, set[0]);
            AssertItemsOrder();

            set[0] = 30;
            Assert.AreEqual(30, set[0]);
            Assert.AreEqual(40, set[2]);
            AssertItemsOrder();

            set[0] = 30;
            Assert.AreEqual(30, set[0]);
            Assert.AreEqual(40, set[2]);
            AssertItemsOrder();
        }

        [Test]
        public void Clear()
        {
            Assert.AreEqual(3, set.Count);
            set.Clear();
            Assert.AreEqual(0, set.Count);
            AssertItemsOrder();

            set.Add(10);
            set.Add(20);
            set.Add(30);
            Assert.AreEqual(3, set.Count);
            AssertItemsOrder();
        }

        [Test]
        public void Contains()
        {
            Assert.IsTrue(set.Contains(10));
            Assert.IsTrue(set.Contains(20));
            Assert.IsTrue(set.Contains(30));
            Assert.IsFalse(set.Contains(40));

            set.Add(10);
            Assert.IsTrue(set.Contains(10));
            Assert.IsTrue(set.Contains(20));
            Assert.IsTrue(set.Contains(30));
            Assert.IsFalse(set.Contains(40));
            AssertItemsOrder();

            set.Remove(10);
            Assert.IsFalse(set.Contains(10));
            Assert.IsTrue(set.Contains(20));
            Assert.IsTrue(set.Contains(30));
            Assert.IsFalse(set.Contains(40));
            AssertItemsOrder();

            set[0] = 40;
            Assert.IsFalse(set.Contains(10));
            Assert.IsFalse(set.Contains(20));
            Assert.IsTrue(set.Contains(30));
            Assert.IsTrue(set.Contains(40));
            AssertItemsOrder();

            set.Add(10);
            set[0] = 10;
            Assert.IsTrue(set.Contains(10));
            Assert.IsTrue(set.Contains(20));
            Assert.IsTrue(set.Contains(40));
            AssertItemsOrder();
        }

        [Test]
        public void CopyToExceptions()
        {
            int[] array = null;
            Assert.That(() => set.CopyTo(array, 0),
            Throws.Exception.TypeOf<ArgumentNullException>());

            array = new int[3];
            Assert.That(() => set.CopyTo(array, -1),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => set.CopyTo(array, 3),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());


            Assert.That(() => set.CopyTo(array, 1),
            Throws.Exception.TypeOf<ArgumentException>());

            Assert.That(() => set.CopyTo(array, 2),
            Throws.Exception.TypeOf<ArgumentException>());

            array = new int[2];

            Assert.That(() => set.CopyTo(array, 0),
            Throws.Exception.TypeOf<ArgumentException>());

            Assert.That(() => set.CopyTo(array, 1),
            Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void CopyTo()
        {
            int[] array = new int[3];
            set.CopyTo(array, 0);

            for (int i = 0; i < set.Count; i++)
                Assert.AreEqual(set[i], array[i]);


            array = new int[10];
            set.CopyTo(array, 0);

            for (int i = 0; i < set.Count; i++)
                Assert.AreEqual(set[i], array[i]);

            set.CopyTo(array, 5);
            for (int i = 5; i < set.Count; i++)
                Assert.AreEqual(set[i], array[i]);
        }

        [Test]
        public void IndexOf()
        {
            int index = set.IndexOf(10);
            Assert.AreEqual(0, index);
            index = set.IndexOf(20);
            Assert.AreEqual(1, index);
            index = set.IndexOf(30);
            Assert.AreEqual(2, index);

            index = set.IndexOf(40);
            Assert.AreEqual(-1, index);
        }

        [Test]
        public void Insert()
        {
            bool inserted = set.Insert(100, 0);
            Assert.IsTrue(inserted);
            Assert.AreEqual(4, set.Count);
            AssertItemsOrder();

            inserted = set.Insert(101, 3);
            Assert.IsTrue(inserted);
            Assert.AreEqual(5, set.Count);
            AssertItemsOrder();

            inserted = set.Insert(101, 0);
            Assert.IsFalse(inserted);
            Assert.AreEqual(5, set.Count);
            AssertItemsOrder();


            Assert.That(() => set.Insert(100, -1),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => set.Insert(100, 5),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            AssertItemsOrder();
        }

        [Test]
        public void Remove()
        {
            bool removed = set.Remove(10);
            Assert.IsTrue(removed);
            Assert.AreEqual(2, set.Count);
            AssertItemsOrder();

            removed = set.Remove(10);
            Assert.IsFalse(removed);
            Assert.AreEqual(2, set.Count);
            AssertItemsOrder();

            removed = set.Remove(100);
            Assert.IsFalse(removed);
            Assert.AreEqual(2, set.Count);
            AssertItemsOrder();
        }

        [Test]
        public void RemoveAt()
        {
            set.RemoveAt(0);
            Assert.AreEqual(2, set.Count);
            AssertItemsOrder();

            set.Add(10);
            set.RemoveAt(2);
            Assert.AreEqual(2, set.Count);
            AssertItemsOrder();


            Assert.That(() => set.RemoveAt(-1),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => set.RemoveAt(2),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            AssertItemsOrder();
        }

        [Test]
        public void Sort()
        {
            set.Sort();
            AssertItemsOrder();

            Comparison<int> comparison = null; 
            Assert.That(() => set.Sort(comparison),
            Throws.Exception.TypeOf<ArgumentNullException>());

            IComparer<int> comparer = null;
            set.Sort(comparer);
            AssertItemsOrder();

            comparer = Comparer<int>.Default;
            set.Sort(comparer);
            AssertItemsOrder();

            set.Sort(0, set.Count, comparer);
            AssertItemsOrder();

            set.Sort(1, 2, comparer);
            AssertItemsOrder();

            set.Sort(0, 0, comparer);
            AssertItemsOrder();

            set.Sort(set.Count, 0, comparer);
            AssertItemsOrder();


            Assert.That(() => set.Sort(-1, 3, comparer),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => set.Sort(0, -1, comparer),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());


            Assert.That(() => set.Sort(0, 4, comparer),
            Throws.Exception.TypeOf<ArgumentException>());

            Assert.That(() => set.Sort(set.Count, 1, comparer),
            Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void BinarySearch()
        {
            int index = set.BinarySearch(10);
            Assert.AreEqual(0, index);

            index = set.BinarySearch(20);
            Assert.AreEqual(1, index);

            index = set.BinarySearch(30);
            Assert.AreEqual(2, index);

            index = set.BinarySearch(40);
            Assert.AreEqual(~set.Count, index);

            index = set.BinarySearch(0);
            Assert.AreEqual(~0, index);

            IComparer<int> comparer = Comparer<int>.Default;

            Assert.That(() => set.BinarySearch(-1, 3, 0, comparer),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => set.BinarySearch(0, -1, 0, comparer),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());


            Assert.That(() => set.BinarySearch(0, 4, 0, comparer),
            Throws.Exception.TypeOf<ArgumentException>());

            Assert.That(() => set.BinarySearch(set.Count, 1, 0, comparer),
            Throws.Exception.TypeOf<ArgumentException>());
        }


        private void AssertItemsOrder()
        {
            for (int i = 0; i < set.Count; i++)
            {
                int item = set[i];
                int index = set.IndexOf(item);
                Assert.AreEqual(i, index);
            }
        }
    }
}

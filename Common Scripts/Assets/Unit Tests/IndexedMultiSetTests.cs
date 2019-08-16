using Common.Collections.Generic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class IndexedMultiSetTests
    {
        private IndexedMultiSet<int> set = new IndexedMultiSet<int>();

        [SetUp]
        public void SetUp()
        {
            set.Clear();

            set.Add(10);
            set.Add(20);
            set.Add(20);
            set.Add(30);
            set.Add(30);
            set.Add(30);
            set.Add(100);
        }

        [Test]
        public void Count()
        {
            Assert.AreEqual(7, set.Count);
            set.Add(0);
            Assert.AreEqual(8, set.Count);

            set.Clear();
            Assert.AreEqual(0, set.Count);
        }


        [Test]
        public void Add()
        {
            set.Add(0);
            set.Add(1);
            set.Add(2);
            set.Add(2);
            set.Add(2);

            Assert.AreEqual(12, set.Count);
            Assert.AreEqual(1, set.CountOf(0));
            Assert.AreEqual(1, set.CountOf(1));
            Assert.AreEqual(3, set.CountOf(2));
            AssertItemsOrder();

            set.Clear();

            set.Add(0);
            set.Add(1);
            set.Add(2);
            set.Add(2);
            set.Add(2);

            Assert.AreEqual(5, set.Count);
            Assert.AreEqual(1, set.CountOf(0));
            Assert.AreEqual(1, set.CountOf(1));
            Assert.AreEqual(3, set.CountOf(2));

            AssertItemsOrder();
        }

        [Test, Sequential]
        public void IndexerGetter(
            [Values(10, 20, 30)] int value,
            [Values(0, 1, 3)]  int index)
        {
            Assert.AreEqual(value, set[index]);
        }

        [Test]
        public void IndexerSetter()
        {
            set[0] = 40;
            Assert.AreEqual(40, set[0]);
            Assert.IsFalse(set.Contains(10));
            Assert.AreEqual(1, set.CountOf(40));
            AssertItemsOrder();

            set[0] = 30;
            Assert.AreEqual(30, set[0]);
            Assert.IsFalse(set.Contains(40));
            Assert.AreEqual(4, set.CountOf(30));
            AssertItemsOrder();

            set[1] = 30;
            Assert.AreEqual(30, set[1]);
            Assert.AreEqual(5, set.CountOf(30));
            AssertItemsOrder();
        }

        [Test, Sequential]
        public void IndexerExceptions([Values(-1, 7)] int index)
        {
            Assert.That(() => set[index] = 0,
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Clear()
        {
            Assert.AreEqual(7, set.Count);
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
            Assert.IsTrue(set.Contains(100));
            Assert.IsFalse(set.Contains(40));

            set.Add(10);
            Assert.IsTrue(set.Contains(10));
            Assert.IsTrue(set.Contains(20));
            Assert.IsTrue(set.Contains(30));
            Assert.IsTrue(set.Contains(100));
            Assert.IsFalse(set.Contains(40));
            AssertItemsOrder();

            set.Remove(10);
            Assert.IsTrue(set.Contains(30));
            Assert.IsTrue(set.Contains(20));
            Assert.IsTrue(set.Contains(100));
            Assert.IsTrue(set.Contains(10));
            Assert.IsFalse(set.Contains(40));
            AssertItemsOrder();

            set[0] = 40;
            Assert.IsTrue(set.Contains(40));
            Assert.IsTrue(set.Contains(20));
            Assert.IsTrue(set.Contains(100));
            Assert.IsFalse(set.Contains(10));
            Assert.IsTrue(set.Contains(30));
            AssertItemsOrder();

            set.Add(10);
            set[0] = 10;
            Assert.IsTrue(set.Contains(10));
            Assert.IsTrue(set.Contains(20));
            Assert.IsTrue(set.Contains(100));
            Assert.IsTrue(set.Contains(30));
            Assert.IsFalse(set.Contains(40));
            AssertItemsOrder();
        }

        [Test]
        public void CopyToExceptions()
        {
            int[] array = null;
            Assert.That(() => set.CopyTo(array, 0),
            Throws.Exception.TypeOf<ArgumentNullException>());

            array = new int[7];
            Assert.That(() => set.CopyTo(array, -1),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());


            Assert.That(() => set.CopyTo(array, 1),
            Throws.Exception.TypeOf<ArgumentException>());

            Assert.That(() => set.CopyTo(array, 2),
            Throws.Exception.TypeOf<ArgumentException>());

            Assert.That(() => set.CopyTo(array, set.Count),
            Throws.Exception.TypeOf<ArgumentException>());

            array = new int[6];

            Assert.That(() => set.CopyTo(array, 0),
            Throws.Exception.TypeOf<ArgumentException>());

            Assert.That(() => set.CopyTo(array, 1),
            Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void CopyTo()
        {
            int[] array = new int[7];
            set.CopyTo(array, 0);

            CollectionAssert.AreEqual(set, array);

            array = new int[20];
            set.CopyTo(array, 0);

            for (int i = 0; i < set.Count; i++)
                Assert.AreEqual(set[i], array[i]);

            set.CopyTo(array, 10);
            for (int i = 5; i < set.Count; i++)
                Assert.AreEqual(set[i], array[i]);
        }

        [Test, Sequential]
        public void CountOf(
            [Values(0, 10, 20, 30, 100)] int value,
            [Values(0, 1, 2, 3, 1)] int expectedCount
            )
        {
            int count = set.CountOf(value);
            Assert.AreEqual(expectedCount, count);
        }

        [Test, Sequential]
        public void IndexOf(
            [Values(10, 20, 30, 100, 40)] int value,
            [Values(0, 1, 3, 6, -1)] int expectedIndex)
        {
            int index = set.IndexOf(value);
            Assert.AreEqual(expectedIndex, index);
        }

        [Test, Sequential]
        public void LastIndexOf(
           [Values(20, 30)] int value,
           [Values(2, 5)] int expectedIndex)
        {
            int index = set.LastIndexOf(value);
            Assert.AreEqual(expectedIndex, index);
        }

        [Test]
        public void LastIndexOf2()
        {
            int index = set.LastIndexOf(30);
        }

        [Test]
        public void Insert()
        {
            int current = set[0];
            set.Insert(0, 100);
            Assert.AreEqual(8, set.Count);
            Assert.AreEqual(100, set[0]);
            Assert.AreEqual(current, set[set.Count - 1]);
            AssertItemsOrder();

            current = set[3];
            set.Insert(3, 101);
            Assert.AreEqual(9, set.Count);
            Assert.AreEqual(101, set[3]);
            Assert.AreEqual(current, set[set.Count - 1]);
            AssertItemsOrder();

            current = set[0];
            set.Insert(0, 101);
            Assert.AreEqual(10, set.Count);
            Assert.AreEqual(101, set[0]);
            Assert.AreEqual(current, set[set.Count - 1]);
            AssertItemsOrder();


            Assert.That(() => set.Insert(100, -1),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => set.Insert(100, set.Count),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            AssertItemsOrder();
        }

        [Test]
        public void Remove()
        {
            bool removed = set.Remove(10);
            Assert.IsTrue(removed);
            Assert.AreEqual(6, set.Count);
            AssertItemsOrder();

            removed = set.Remove(10);
            Assert.IsFalse(removed);
            Assert.AreEqual(6, set.Count);
            AssertItemsOrder();

            removed = set.Remove(100);
            Assert.IsTrue(removed);
            Assert.AreEqual(5, set.Count);
            AssertItemsOrder();

            removed = set.Remove(30);
            Assert.IsTrue(removed);
            Assert.AreEqual(4, set.Count);
            AssertItemsOrder();
        }

        [Test]
        public void RemoveAt()
        {
            set.RemoveAt(0);
            Assert.AreEqual(6, set.Count);
            AssertItemsOrder();

            set.Add(10);
            set.RemoveAt(2);
            Assert.AreEqual(6, set.Count);
            AssertItemsOrder();

            set.Insert(0, -1);
            set.Add(-1);
            set.RemoveAt(0);
            Assert.AreEqual(7, set.Count);
            Assert.IsTrue(set.Contains(-1));
            AssertItemsOrder();

            set.RemoveAt(0);
            Assert.AreEqual(6, set.Count);
            Assert.IsFalse(set.Contains(-1));
            AssertItemsOrder();
        }

        [Test]
        public void RemoveAtAll()
        {
            for (int i = set.Count - 1; i >= 0; i--)
            {
                set.RemoveAt(0);
                Assert.AreEqual(i, set.Count);
                AssertItemsOrder();
            }
        }

        [Test]
        public void RemoveAtExceptions()
        {
            Assert.That(() => set.RemoveAt(-1),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => set.RemoveAt(set.Count),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            AssertItemsOrder();
        }

        [Test]
        public void BinarySearch()
        {
            int value = 10;
            int index = set.BinarySearch(value);
            Assert.AreEqual(0, index);

            {
                value = 20;
                index = set.BinarySearch(value);
                int[] indices = { 1, 2 };
                Assert.IsTrue(indices.Any(i => i == index));
            }

            {
                value = 30;
                index = set.BinarySearch(value);
                int[] indices = { 3, 4, 5 };
                Assert.IsTrue(indices.Any(i => i == index));
            }

            value = 100;
            index = set.BinarySearch(value);
            Assert.AreEqual(6, index);

            value = 101;
            index = set.BinarySearch(value);
            Assert.AreEqual(~7, index);
        }

        [Test]
        public void BinarySearchExceptions()
        {
            IComparer<int> comparer = Comparer<int>.Default;

            Assert.That(() => set.BinarySearch(-1, set.Count, 0, comparer),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(() => set.BinarySearch(0, -1, 0, comparer),
            Throws.Exception.TypeOf<ArgumentOutOfRangeException>());


            Assert.That(() => set.BinarySearch(0, set.Count + 1, 0, comparer),
            Throws.Exception.TypeOf<ArgumentException>());

            Assert.That(() => set.BinarySearch(set.Count, 1, 0, comparer),
            Throws.Exception.TypeOf<ArgumentException>());
        }

        private void AssertItemsOrder()
        {
            int i = 0;
            foreach (int n in set)
            {
                Assert.AreEqual(n, set[i]);
                i++;
            }
        }
    }
}
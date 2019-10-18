using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _8_2_ex.Tests
{
    [TestClass]
    public class SetTest
    {
        private GenericSet<int> set;

        [TestInitialize]
        public void Initialize()
        {
            set = new GenericSet<int>(new ComparerInt());

            int[] testData = { 1, 4, 6, -1, 10, 0, 4, -2 };

            foreach (int element in testData)
            {
                set.Add(element);
            }
        }

        [TestMethod]
        public void IsEmptySet()
        {
            Assert.IsFalse(set.IsEmpty);
        }

        [TestMethod]
        public void CopyToAndCountTest()
        {
            int[] testAnswer = { -2, -1, 0, 1, 4, 6, 10 };

            int i = 0;
            foreach (int element in set)
            {
                Assert.AreEqual(testAnswer[i], element);
                ++i;
            }
        }

        [TestMethod]
        public void ContainsTest()
        {
            int[] testCheckData = { -2, -1, 0, 1, 4, 6, 10, 11, -3, 5 };
            bool[] testAnswer = { true, true, true, true, true, true, true, false, false, false };

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], set.Contains(testCheckData[i]));
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            int[] testRemoveData = { -1, 1, 6, 10 };
            int[] testAnswer = { -2, 0, 4 };

            foreach (int element in testRemoveData)
            {
                set.Remove(element);
            }

            int i = 0;
            foreach (int element in set)
            {
                Assert.AreEqual(testAnswer[i], element);
                ++i;
            }
        }

        [TestMethod]
        public void ClearTest()
        {
            set.Clear();

            Assert.IsTrue(set.IsEmpty);
        }

        // ????????
        [TestMethod]
        public void EnumeratorTest()
        {
            var setElements = new int[set.Count];

            set.CopyTo(setElements, 0);

            int i = 0;
            foreach (int element in set)
            {
                Assert.AreEqual(setElements[i], element);
                ++i;
            }
        }

        [TestMethod]
        public void UnionWithTest()
        {
            int[] unionSet = { 0, -1, 5, 3, 2 };
            int[] testAnswer = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 10 };

            set.UnionWith(unionSet);

            int i = 0;
            foreach (int element in set)
            {
                Assert.AreEqual(testAnswer[i], element);
                ++i;
            }
        }

        [TestMethod]
        public void IntersectWithTest()
        {
            int[] intersectSet = { 0, -1, 5, 3, 2, 10 };
            int[] testAnswer = { -1, 0, 10 };

            set.IntersectWith(intersectSet);

            int i = 0;
            foreach (int element in set)
            {
                Assert.AreEqual(testAnswer[i], element);
                ++i;
            }
        }

        [TestMethod]
        public void ExceptWithTest()
        {
            int[] exceptSet = { 0, -1, 5, 3, 2, 10 };
            int[] testAnswer = { -2, 1, 4, 6 };

            set.ExceptWith(exceptSet);

            int i = 0;
            foreach (int element in set)
            {
                Assert.AreEqual(testAnswer[i], element);
                ++i;
            }
        }

        [TestMethod]
        public void SymmetricExceptWithTest()
        {
            int[] symmetricExceptSet = { 0, -1, 5, 3, 2, 10 };
            int[] testAnswer = { -2, 1, 2, 3, 4, 5, 6 };

            set.SymmetricExceptWith(symmetricExceptSet);

            int i = 0;
            foreach (int element in set)
            {
                Assert.AreEqual(testAnswer[i], element);
                ++i;
            }
        }

        [TestMethod]
        public void IsSubsetOfTest()
        {
            int[] set1 = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] set2 = { -2, -1, 1, 2, 4, 6, 7, 10 };

            Assert.IsTrue(set.IsSubsetOf(set1));
            Assert.IsFalse(set.IsSubsetOf(set2));
        }

        [TestMethod]
        public void IsSupersetOf()
        {
            int[] set1 = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] set2 = { -2, -1, 1, 10 };
            
            Assert.IsFalse(set.IsSupersetOf(set1));
            Assert.IsTrue(set.IsSupersetOf(set2));
        }

        [TestMethod]
        public void IsProperSupersetOfTests()
        {
            int[] set1 = { -2, -1, 1, 10 };
            int[] set2 = { -2, -1, 0, 1, 4, 6, 10 };

            Assert.IsTrue(set.IsProperSupersetOf(set1));
            Assert.IsFalse(set.IsProperSupersetOf(set2));
        }

        [TestMethod]
        public void IsProperSubsetOfTest()
        {
            int[] set1 = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] set2 = { -2, -1, 0, 1, 4, 6, 10 };

            Assert.IsTrue(set.IsProperSubsetOf(set1));
            Assert.IsFalse(set.IsProperSubsetOf(set2));
        }

        [TestMethod]
        public void OverlapsTest()
        {
            int[] set1 = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] set2 = { 2, 3, 5, 7, 8, 9, 11, -3 };

            Assert.IsTrue(set.Overlaps(set1));
            Assert.IsFalse(set.Overlaps(set2));
        }

        [TestMethod]
        public void SetEquals()
        {
            int[] set1 = { -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] set2 = { -2, -1, 0, 1, 4, 6, 10 };
            int[] set3 = { 2, 3, 5, 7, 8, 9, 11, -3 };
            int[] set4 = { -2, -1, 0, 1, 4, 6 };

            Assert.IsFalse(set.SetEquals(set1));
            Assert.IsTrue(set.SetEquals(set2));
            Assert.IsFalse(set.SetEquals(set3));
            Assert.IsFalse(set.SetEquals(set4));
        }

        [TestMethod]
        public void ExceptionsTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => set.CopyTo(null, 0));
            Assert.ThrowsException<NotEnoughLengthOfOutputArrayException>(() => set.CopyTo(new int[set.Count], 1));
            Assert.ThrowsException<NotEnoughLengthOfOutputArrayException>(() => set.CopyTo(new int[set.Count -1], 0));

            Assert.ThrowsException<ArgumentNullException>(() => set.UnionWith(null));
            Assert.ThrowsException<ArgumentNullException>(() => set.IntersectWith(null));
            Assert.ThrowsException<ArgumentNullException>(() => set.ExceptWith(null));
            Assert.ThrowsException<ArgumentNullException>(() => set.SymmetricExceptWith(null));
            Assert.ThrowsException<ArgumentNullException>(() => set.IsSubsetOf(null));
            Assert.ThrowsException<ArgumentNullException>(() => set.IsSupersetOf(null));
            Assert.ThrowsException<ArgumentNullException>(() => set.IsProperSupersetOf(null));
            Assert.ThrowsException<ArgumentNullException>(() => set.IsProperSubsetOf(null));
            Assert.ThrowsException<ArgumentNullException>(() => set.Overlaps(null));
            Assert.ThrowsException<ArgumentNullException>(() => set.SetEquals(null));
        }
    }
}

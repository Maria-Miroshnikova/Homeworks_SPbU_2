using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test_2_2.Tests
{
    [TestClass]
    public class SortTest
    {
        private bool CompareDecrease(int firstElement, int secondElement)
        {
            return firstElement <= secondElement;
        }

        private bool CompareIncrease(int firstElement, int secondElement)
        {
            return firstElement >= secondElement;
        }

        private bool CompareIdentity(int firstElement, int secondElement)
        {
            return false;
        }

        private bool CompareAlphabet(string firstElement, string secondElement)
        {
            return String.Compare(firstElement, secondElement) >= 0;
        }

        private bool CompareLength(string firstElement, string secondElement)
        {
            return firstElement.Length >= secondElement.Length;
        }

        [TestMethod]

        public void SortIntIncreaseTest()
        {
            var list = new List<int> { 1, 5, 3, 2, 2, -1, 4 };
            var sortedList = new List<int> { -1, 1, 2, 2, 3, 4, 5 };

            var sorting = new BubbleSort<int>();

            sorting.list = list;
            sorting.comparer = CompareIncrease;

            sorting.MySort();

            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(sortedList[i], sorting.list[i]);
            }           

        }

        [TestMethod]

        public void SortIntDecreaseTest()
        {
            var list = new List<int> { 1, 5, 3, 2, 2, -1, 4 };
            var sortedList = new List<int> { 5, 4, 3, 2, 2, 1, -1 };

            var sorting = new BubbleSort<int>();

            sorting.list = list;
            sorting.comparer = CompareDecrease;

            sorting.MySort();

            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(sortedList[i], sorting.list[i]);
            }

        }

        [TestMethod]
        public void SortIntIdentityTest()
        {
            var list = new List<int> { 1, 5, 3, 2, 2, -1, 4 };
            var sortedList = new List<int> { 1, 5, 3, 2, 2, -1, 4 };

            var sorting = new BubbleSort<int>();

            sorting.list = list;
            sorting.comparer = CompareIdentity;

            sorting.MySort();

            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(sortedList[i], sorting.list[i]);
            }
        }

        [TestMethod]
        public void SortStringAlphabetTest()
        {
            var list = new List<string> { "l", "o", "a", "z", "c" };
            var sortedList = new List<string> { "a", "c", "l", "o", "z" };

            var sorting = new BubbleSort<string>();

            sorting.list = list;
            sorting.comparer = CompareAlphabet;

            sorting.MySort();

            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(sortedList[i], sorting.list[i]);
            }

        }

        [TestMethod]
        public void SortStringLengthTest()
        {
            var list = new List<string> { "aaa", "a", "aaaa", "aa", "a" };
            var sortedList = new List<string> { "a", "a", "aa", "aaa", "aaaa" };

            var sorting = new BubbleSort<string>();

            sorting.list = list;
            sorting.comparer = CompareLength;

            sorting.MySort();

            for (int i = 0; i < list.Count; ++i)
            {
                Assert.AreEqual(sortedList[i], sorting.list[i]);
            }
        }
    }
}

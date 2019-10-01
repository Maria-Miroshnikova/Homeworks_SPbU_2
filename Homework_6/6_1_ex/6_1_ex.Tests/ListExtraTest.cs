using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _6_1_ex.Tests
{
    [TestClass]
    public class ListExtraTest
    {
        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>();
            int[] listArray = { 1, 2, 3, 4, 5 };
            foreach(int number in listArray)
            {
                list.Add(number);
            }
        }

        List<int> list;

        [TestMethod]
        public void MapTest()
        {
            int[] testAnswer1 = { 0, 1, 2, 3, 4};
            int[] testAnswer2 = { 2, 6, 12, 20, 30};

            var listResult1 = ListExtra.Map(list, x => x - 1);
            for (int i = 0; i < listResult1.Count; ++i)
            {
                Assert.AreEqual(testAnswer1[i], listResult1[i]);
            }

            var listResult2 = ListExtra.Map(list, x => x * (x + 1));
            for (int i = 0; i < listResult2.Count; ++i)
            {
                Assert.AreEqual(testAnswer2[i], listResult2[i]);
            }
        }

        [TestMethod]
        public void FilterTest()
        {
            int[] testAnswer1 = { 2, 4 };

            var listResult1 = ListExtra.Filter(list, x => (x % 2) == 0);
            for (int i = 0; i < listResult1.Count; ++i)
            {
                Assert.AreEqual(testAnswer1[i], listResult1[i]);
            }

            var listResult2 = ListExtra.Filter(list, x => false);
            Assert.IsTrue(listResult2.Count == 0);
        }

        [TestMethod]
        public void FoldTest()
        {
            int accumulator1 = 1;
            int accumulator2 = 0;

            int testAnswer1 = 120;
            int testAnswer2 = 15;

            Assert.AreEqual(testAnswer1, ListExtra.Fold(list, accumulator1, x => x.element * x.accumulator));
            Assert.AreEqual(testAnswer2, ListExtra.Fold(list, accumulator2, x => x.element + x.accumulator));
        }

        [TestMethod]
        public void ExceptionTests()
        {
            Assert.ThrowsException<MyVeryOwnNullArgumentException>(() => ListExtra.Map(null, x => x + 2));
            Assert.ThrowsException<MyVeryOwnNullArgumentException>(() => ListExtra.Map(list, null));

            Assert.ThrowsException<MyVeryOwnNullArgumentException>(() => ListExtra.Filter(null, x => x == 2));
            Assert.ThrowsException<MyVeryOwnNullArgumentException>(() => ListExtra.Filter(list, null));

            Assert.ThrowsException<MyVeryOwnNullArgumentException>(() => ListExtra.Fold(null, 0, x => x.element + x.accumulator));
            Assert.ThrowsException<MyVeryOwnNullArgumentException>(() => ListExtra.Fold(list, 0, null));
        }
    }
}

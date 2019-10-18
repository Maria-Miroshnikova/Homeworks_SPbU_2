using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListNameSpace.Tests
{
    [TestClass]
    public class GenericListTest
    {
        [TestInitialize]
        public void Initialize()
        {
            testListInt = new GenericList<int>();
            testListStr = new GenericList<string>();

            foreach (int element in testDataInt)
            {
                testListInt.Add(element);
            }
            foreach (string element in testDataStr)
            {
                testListStr.Add(element);
            }
        }

        private GenericList<int> testListInt;
        private GenericList<string> testListStr;

        private int[] testDataInt = { 1, 2, 5, 4, 3 };
        private string[] testDataStr = { "a", "b", "", "c" };
        private int[] notExcistingElementsInt = { 10, 0, -1, -5 };
        private string[] notExcistingElementsStr = { "A", "a ", "d", "Aa", "\0" };

        public void CountAndIsNotEmptyTest()
        {
            Assert.IsFalse(testListInt.IsEmpty);
            Assert.IsFalse(testListStr.IsEmpty);

            Assert.AreEqual(testDataInt.Length, testListInt.Count);
            Assert.AreEqual(testDataStr.Length, testListStr.Count);
        }

        [TestMethod]
        public void AddAndAccessTest()
        {
            for (int i = 0; i < testListInt.Count; ++i)
            {
                Assert.AreEqual(testDataInt[i], testListInt[i]);
            }
            for (int i = 0; i < testListStr.Count; ++i)
            {
                Assert.AreEqual(testDataStr[i], testListStr[i]);
            }
        }

        [TestMethod]
        public void AccessTest()
        {
            int[] newTestDataInt = { 1, 2, 3, 4, 5 };
            string[] newTestDataStr = { "c", "", "a", "b" };

            for (int i = 0; i < newTestDataInt.Length; ++i)
            {
                testListInt[i] = newTestDataInt[i];
            }
            for (int i = 0; i < newTestDataStr.Length; ++i)
            {
                testListStr[i] = newTestDataStr[i];
            }

            for (int i = 0; i < testListInt.Count; ++i)
            {
                Assert.AreEqual(newTestDataInt[i], testListInt[i]);
            }
            for (int i = 0; i < testListStr.Count; ++i)
            {
                Assert.AreEqual(newTestDataStr[i], testListStr[i]);
            }
        }

        [TestMethod]
        public void IndexOfExcistingElementTest()
        {
            for (int i = 0; i < testListInt.Count; ++i)
            {
                Assert.AreEqual(i, testListInt.IndexOf(testListInt[i]));
            }
            for (int i = 0; i < testListStr.Count; ++i)
            {
                Assert.AreEqual(i, testListStr.IndexOf(testListStr[i]));
            }
        }

        [TestMethod]
        public void IndexOfNotExcistingElementTest()
        {
            for (int i = 0; i < notExcistingElementsInt.Length; ++i)
            {
                Assert.AreEqual(-1, testListInt.IndexOf(notExcistingElementsInt[i]));
            }
            for (int i = 0; i < notExcistingElementsStr.Length; ++i)
            {
                Assert.AreEqual(-1, testListStr.IndexOf(notExcistingElementsStr[i]));
            }
        }

        [TestMethod]
        public void ContainsExcistingElementTest()
        {
            for (int i = 0; i < testListInt.Count; ++i)
            {
                Assert.IsTrue(testListInt.Contains(testListInt[i]));
            }
            for (int i = 0; i < testListStr.Count; ++i)
            {
                Assert.IsTrue(testListStr.Contains(testListStr[i]));
            }
        }

        [TestMethod]
        public void ContainsNotExcistingElementTest()
        {
            for (int i = 0; i < notExcistingElementsInt.Length; ++i)
            {
                Assert.IsFalse(testListInt.Contains(notExcistingElementsInt[i]));
            }
            for (int i = 0; i < notExcistingElementsStr.Length; ++i)
            {
                Assert.IsFalse(testListStr.Contains(notExcistingElementsStr[i]));
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            int[] testAnswerInt = { 0, 1, 2, 3, 5, 4, 3, 3 };
            string[] testAnswerStr = { "Aa", "a", "b", " ", "", "c", "c" };

            int[] indexForInsertionInt = { 0, 3, 6 };
            int[] indexForInsertionStr = { 0, 3, 5 };

            int[] insertionsInt = { 0, 3, 3 };
            string[] insertionsStr = { "Aa", " ", "c"};
            
            for (int i = 0; i < insertionsInt.Length; ++i)
            {
                testListInt.Insert(indexForInsertionInt[i], insertionsInt[i]);
            }
            for (int i = 0; i < insertionsStr.Length; ++i)
            {
                testListStr.Insert(indexForInsertionStr[i], insertionsStr[i]);
            }

            for (int i = 0; i < testAnswerInt.Length; ++i)
            {
                Assert.AreEqual(testAnswerInt[i], testListInt[i]);
            }
            for (int i = 0; i < testAnswerStr.Length; ++i)
            {
                Assert.AreEqual(testAnswerStr[i], testListStr[i]);
            }
        }

        [TestMethod]
        public void CopyToTest()
        {
            int indexCopy = 2;

            var outputListInt = new int[testListInt.Count + indexCopy];
            var outputListStr = new string[testListStr.Count + indexCopy];

            testListInt.CopyTo(outputListInt, indexCopy);
            testListStr.CopyTo(outputListStr, indexCopy);

            int i = indexCopy;
            foreach (int element in testListInt)
            {
                Assert.AreEqual(element, outputListInt[i]);
                ++i;
            }
            i = indexCopy;
            foreach (string element in testListStr)
            {
                Assert.AreEqual(element, outputListStr[i]);
                ++i;
            }
        }

        [TestMethod]
        public void RemoveTest()
        {
            int[] removeElementsInt = { 1, 2, 3, 3, 1, -1, 10 };
            string[] removeElementsStr = { "a", "", "c", "c", "A", "cC" };

            int[] testResultListInt = { 5, 4 };
            string[] testResultListStr = { "b" };

            bool[] testAnswerInt = { true, true, true, false, false, false, false };
            bool[] testAnswerStr = { true, true, true, false, false, false };

            for (int i = 0; i < removeElementsInt.Length; ++i)
            {
                Assert.AreEqual(testAnswerInt[i], testListInt.Remove(removeElementsInt[i]));
            }
            for (int i = 0; i < removeElementsStr.Length; ++i)
            {
                Assert.AreEqual(testAnswerStr[i], testListStr.Remove(removeElementsStr[i]));
            }

            for (int i = 0; i < testListInt.Count; ++i)
            {
                Assert.AreEqual(testResultListInt[i], testListInt[i]);
            }
            for (int i = 0; i < testListStr.Count; ++i)
            {
                Assert.AreEqual(testResultListStr[i], testListStr[i]);
            }
        }
    
        [TestMethod]
        public void RemoveAtTest()
        {
            int[] indexRemoveInt = { 0, 0, 1, 1, 0 };
            int[] indexRemoveStr = { 0, 2, 1, 0 };
            
            for (int i = 0; i < indexRemoveInt.Length; ++i)
            {
                testListInt.RemoveAt(indexRemoveInt[i]);
            }
            for (int i = 0; i < indexRemoveStr.Length; ++i)
            {
                testListStr.RemoveAt(indexRemoveStr[i]);
            }

            Assert.IsTrue(testListInt.IsEmpty);

            Assert.IsTrue(testListStr.IsEmpty);
        }

        [TestMethod]
        public void ClearTest()
        {
            Assert.IsFalse(testListInt.IsEmpty);
            Assert.IsFalse(testListStr.IsEmpty);

            testListInt.Clear();
            testListStr.Clear();

            Assert.IsTrue(testListInt.IsEmpty);
            Assert.IsTrue(testListStr.IsEmpty);
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            var outputListInt = new int[testListInt.Count];
            var outputListStr = new string[testListStr.Count];

            testListInt.CopyTo(outputListInt, 0);
            testListStr.CopyTo(outputListStr, 0);

            int index = 0;
            foreach (int element in testListInt)
            {
                Assert.AreEqual(outputListInt[index], element);
                ++index;
            }
            index = 0;
            foreach (string element in testListStr)
            {
                Assert.AreEqual(outputListStr[index], element);
                ++index;
            }
        }

        [TestMethod]
        public void ExceptionsTest()
        {
            Assert.ThrowsException<IndexOutOfListException>(() => testListInt[-1]);
            Assert.ThrowsException<IndexOutOfListException>(() => testListStr[-1]);
            Assert.ThrowsException<IndexOutOfListException>(() => testListInt[testListInt.Count]);
            Assert.ThrowsException<IndexOutOfListException>(() => testListStr[testListStr.Count]);

            Assert.ThrowsException<IndexOutOfListException>(() => testListInt.Insert(-1, 0));
            Assert.ThrowsException<IndexOutOfListException>(() => testListStr.Insert(-1, ""));
            Assert.ThrowsException<IndexOutOfListException>(() => testListInt.Insert(testListInt.Count, 1));
            Assert.ThrowsException<IndexOutOfListException>(() => testListStr.Insert(testListStr.Count, ""));

            Assert.ThrowsException<IndexOutOfListException>(() => testListInt.RemoveAt(-1));
            Assert.ThrowsException<IndexOutOfListException>(() => testListStr.RemoveAt(-1));
            Assert.ThrowsException<IndexOutOfListException>(() => testListInt.RemoveAt(testListInt.Count));
            Assert.ThrowsException<IndexOutOfListException>(() => testListStr.RemoveAt(testListStr.Count));

            Assert.ThrowsException<ArgumentNullException>(() => testListInt.CopyTo(null, -1));
            Assert.ThrowsException<ArgumentNullException>(() => testListStr.CopyTo(null, -1));
            Assert.ThrowsException<NotEnoughLengthOfOutputArrayException>(() => testListInt.CopyTo(new int[testListInt.Count - 1], 0));
            Assert.ThrowsException<NotEnoughLengthOfOutputArrayException>(() => testListStr.CopyTo(new string[testListStr.Count - 1], 0));
            Assert.ThrowsException<NotEnoughLengthOfOutputArrayException>(() => testListInt.CopyTo(new int[testListInt.Count], 1));
            Assert.ThrowsException<NotEnoughLengthOfOutputArrayException>(() => testListStr.CopyTo(new string[testListStr.Count], 1));
        }
    }
}

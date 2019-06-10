using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniqueListNameSpace.Tests
{
    [TestClass]
    public class UniqueListTest
    {
        [TestInitialize]
        public void Initialize()
        {
           list  = new UniqueList();
        }

        private UniqueList list;

        [TestMethod]
        public void EasyAddTest()
        {
            string[] testData = { "a", "aa", "AA"};
            
            for (int i = 0; i < testData.Length; ++i)
            {
                list.Add(i + 1, testData[i]);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                Assert.IsTrue(list.Exist(testData[i]));
            }
        }

        [TestMethod]
        public void EasyDeleteTest()
        {
            string[] testData = { "a", "aa", "AA", "bb", "BB" };

            for (int i = 0; i < testData.Length; ++i)
            {
                list.Add(i + 1, testData[i]);
            }

            for (int i = 0; i < testData.Length; i += 2)
            {
                list.Delete(testData[i]);
            }
            for (int i = 1; i < testData.Length; i += 2)
            {
                list.Delete(testData[i]);
            }


            for (int i = 0; i < testData.Length; ++i)
            {
                Assert.IsFalse(list.Exist(testData[i]));
            }

            Assert.IsTrue(list.IsEmpty);
        }

        [TestMethod]
        public void EasyChangeTest()
        {
            string[] testData = { "a", "aa", "AA" };
            string[] testNewData = { "b", "bb", "a" };

            for (int i = 0; i < testData.Length; ++i)
            {
                list.Add(i + 1, testData[i]);
            }
            for (int i = 0; i < testNewData.Length; ++i)
            {
                list.Change(i + 1, testNewData[i]);
            }

            for (int i = 0; i < testNewData.Length; ++i)
            {
                Assert.AreEqual(testNewData[i], list.Get(i + 1).answer);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(AddExistElementException))]
        public void AddExistElementTest()
        {
            string[] testData = { "a", "aa", "AA", "aa", "aaa" };

            for (int i = 0; i < testData.Length; ++i)
            {
                list.Add(i + 1, testData[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DeleteNotExistElementException))]
        public void DeleteNotExistElementTest()
        {
            string[] testData = { "a", "aa", "AA"};

            for (int i = 0; i < testData.Length; ++i)
            {
                list.Add(i + 1, testData[i]);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                list.Delete(testData[i]);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                list.Delete(testData[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(AddExistElementException))]
        public void ChangeElementToAlreadyExistingTest()
        {
            string[] testData = { "a", "aa", "AA" };
            string testReplacement = testData[0];

            for (int i = 0; i < testData.Length; ++i)
            {
                list.Add(i + 1, testData[i]);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                list.Change(i + 1, testReplacement);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(AddExistElementException))]
        public void TruePolimorphismTest()
        {
            string testData = "AAA";
            List notUniqueList = list;

            notUniqueList.Add(1, testData);
            notUniqueList.Add(1, testData);
        }

    }
}

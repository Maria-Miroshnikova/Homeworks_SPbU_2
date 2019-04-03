namespace HashTableNameSpace.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HashTableNameSpace;

    [TestClass]
    public class HashTableTest
    {
        [TestInitialize]
        public void Initialize()
        {
            hashTable = new HashTable(5);
        }

        private HashTable hashTable;

        [TestMethod]
        public void ExistInEmptyHashTest()
        {
            string[] testData = { "a", "aa", "aaa", "a", "A", "", "\0" };
            (bool answer, bool success)[] testExAnswer1 = { (false, true), (false, true), (false, true), (false, true), (false, true), (false, false), (false, false) };

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Exist(testData[i]);
                Assert.AreEqual(testExAnswer1[i].answer, result.answer);
                Assert.AreEqual(testExAnswer1[i].success, result.success);
            }
        }

        [TestMethod]
        public void AddAndExistTest()
        {
            string[] testData = { "a", "aa", "aaa", "a", "A", "", "\0"};
            (bool answer, bool success)[] testAddAnswer = { (true, true), (true, true), (true, true), (false, true), (true, true), (false, false), (false, false) };
            (bool answer, bool success)[] testExAnswer = { (true, true), (true, true), (true, true), (true, true), (true, true), (false, false), (false, false) };

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Add(testData[i]);
                Assert.AreEqual(testAddAnswer[i].answer, result.answer);
                Assert.AreEqual(testAddAnswer[i].success, result.success);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Exist(testData[i]);
                Assert.AreEqual(testExAnswer[i].answer, result.answer);
                Assert.AreEqual(testExAnswer[i].success, result.success);
            }
        }

        [TestMethod]
        public void DeleteFromEmptyHashTest()
        {
            string[] testData = { "a", "aa", "aaa", "A", "", "\0" };

            (bool answer, bool success)[] testDelAnswer = { (false, true), (false, true), (false, true), (false, true), (false, false), (false, false) };

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Delete(testData[i]);
                Assert.AreEqual(testDelAnswer[i].answer, result.answer);
                Assert.AreEqual(testDelAnswer[i].success, result.success);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            string[] testData = { "a", "aa", "aaa", "A", "", "\0" };
            string[] testDelData = { "a", "aaa", "a", "", "\0" };
            
            (bool answer, bool success)[] testDelAnswer = { (true, true), (true, true), (false, true), (false, false), (false, false) };
            (bool answer, bool success)[] testExAnswer = { (false, true), (true, true), (false, true), (true, true), (false, false), (false, false) };

            for (int i = 0; i < testData.Length; ++i)
            {
                hashTable.Add(testData[i]);
            }

            for (int i = 0; i < testDelData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Delete(testDelData[i]);
                Assert.AreEqual(testDelAnswer[i].answer, result.answer);
                Assert.AreEqual(testDelAnswer[i].success, result.success);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Exist(testData[i]);
                Assert.AreEqual(testExAnswer[i].answer, result.answer);
                Assert.AreEqual(testExAnswer[i].success, result.success);
            }
        }

        [TestMethod]
        public void DeleteAllTest()
        {
            string[] testData = { "a", "aa", "aaa", "A" };

            for (int i = 0; i < testData.Length; ++i)
            {
                hashTable.Add(testData[i]);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                hashTable.Delete(testData[i]);
            }

            hashTable.DeleteAll();

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Exist(testData[i]);
                Assert.IsFalse(result.answer);
            }

        }
    }
}

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
            int size = 5;
            hashTable = new HashTable(size);
        }

        private HashTable hashTable;

        [TestMethod]
        public void AddAndExistTest()
        {
            string[] testData = { "a", "aa", "aaa", "a", "A", "", "\0"};
            (bool answer, bool success)[] testExAnswer1 = { (false, true), (false, true), (false, true), (false, true), (false, true), (false, false), (false, false) };
            (bool answer, bool success)[] testAddAnswer = { (true, true), (true, true), (true, true), (false, true), (true, true), (false, false), (false, false) };
            (bool answer, bool success)[] testExAnswer2 = { (true, true), (true, true), (true, true), (true, true), (true, true), (false, false), (false, false) };

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Exist(testData[i]);
                Assert.AreEqual(result.answer, testExAnswer1[i].answer);
                Assert.AreEqual(result.success, testExAnswer1[i].success);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Add(testData[i]);
                Assert.AreEqual(result.answer, testAddAnswer[i].answer);
                Assert.AreEqual(result.success, testAddAnswer[i].success);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Exist(testData[i]);
                Assert.AreEqual(result.answer, testExAnswer2[i].answer);
                Assert.AreEqual(result.success, testExAnswer2[i].success);
            }

            hashTable.DeleteAll();
        }

        [TestMethod]
        public void DeleteTest()
        {
            string[] testData = { "a", "aa", "aaa", "A", "", "\0" };
            string[] testDelData = { "a", "aaa", "a", "", "\0" };

            (bool answer, bool success)[] testDelAnswer1 = { (false, true), (false, true), (false, true), (false, true), (false, false), (false, false) };
            (bool answer, bool success)[] testDelAnswer2 = { (true, true), (true, true), (false, true), (false, false), (false, false) };
            (bool answer, bool success)[] testExAnswer = { (false, true), (true, true), (false, true), (true, true), (false, false), (false, false) };

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Delete(testData[i]);
                Assert.AreEqual(result.answer, testDelAnswer1[i].answer);
                Assert.AreEqual(result.success, testDelAnswer1[i].success);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                hashTable.Add(testData[i]);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Delete(testDelData[i]);
                Assert.AreEqual(result.answer, testDelAnswer2[i].answer);
                Assert.AreEqual(result.success, testDelAnswer2[i].success);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                (bool answer, bool success) result = hashTable.Exist(testData[i]);
                Assert.AreEqual(result.answer, testExAnswer[i].answer);
                Assert.AreEqual(result.success, testExAnswer[i].success);
            }
            
            hashTable.DeleteAll();
        }

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

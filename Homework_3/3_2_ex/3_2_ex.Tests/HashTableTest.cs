using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTableNameSpace.Tests
{
    [TestClass]
    public class HashTableTest
    {
        [TestInitialize]
        public void Initialize()
        {
            int countHashTables = 3;
            hashTable = new HashTable[countHashTables];

            hashTable[0] = new HashTable(new Hash1());
            hashTable[1] = new HashTable(new Hash2());
            hashTable[2] = new HashTable(new Hash3());
        }

        private HashTable[] hashTable;

        [TestMethod]
        public void ExistInEmptyHashTest()
        {
            string[] testData = { "a", "aa", "aaa", "a", "A", "", "\0" };
            (bool answer, bool success)[] testExAnswer1 = { (false, true), (false, true), (false, true), (false, true), (false, true), (false, false), (false, false) };

            for (int i = 0; i < testData.Length; ++i)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    (bool answer, bool success) result = hashTable[j].Exist(testData[i]);
                    Assert.AreEqual(testExAnswer1[i].answer, result.answer);
                    Assert.AreEqual(testExAnswer1[i].success, result.success);
                }
            }
        }

        [TestMethod]
        public void AddAndExistTest()
        {
            string[] testData = { "a", "aa", "aaa", "a", "A", "", "\0"};
            (bool answer, bool success)[] testAddAnswer = { (true, true), (true, true), (true, true), (false, true), (true, true), (false, false), (false, false) };
            (bool answer, bool success)[] testExistAnswer = { (true, true), (true, true), (true, true), (true, true), (true, true), (false, false), (false, false) };

            for (int i = 0; i < testData.Length; ++i)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    (bool answer, bool success) result = hashTable[j].Add(testData[i]);
                    Assert.AreEqual(testAddAnswer[i].answer, result.answer);
                    Assert.AreEqual(testAddAnswer[i].success, result.success);
                }
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    (bool answer, bool success) result = hashTable[j].Exist(testData[i]);
                    Assert.AreEqual(testExistAnswer[i].answer, result.answer);
                    Assert.AreEqual(testExistAnswer[i].success, result.success);
                }
            }
        }

        [TestMethod]
        public void DeleteFromEmptyHashTest()
        {
            string[] testData = { "a", "aa", "aaa", "A", "", "\0" };

            (bool answer, bool success)[] testDelAnswer = { (false, true), (false, true), (false, true), (false, true), (false, false), (false, false) };

            for (int i = 0; i < testData.Length; ++i)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    (bool answer, bool success) result = hashTable[j].Delete(testData[i]);
                    Assert.AreEqual(testDelAnswer[i].answer, result.answer);
                    Assert.AreEqual(testDelAnswer[i].success, result.success);
                }
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
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    hashTable[j].Add(testData[i]);
                }
            }

            for (int i = 0; i < testDelData.Length; ++i)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    (bool answer, bool success) result = hashTable[j].Delete(testDelData[i]);
                    Assert.AreEqual(testDelAnswer[i].answer, result.answer);
                    Assert.AreEqual(testDelAnswer[i].success, result.success);
                }
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    (bool answer, bool success) result = hashTable[j].Exist(testData[i]);
                    Assert.AreEqual(testExAnswer[i].answer, result.answer);
                    Assert.AreEqual(testExAnswer[i].success, result.success);
                }
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            string[] testData = { "a", "aa", "aaa", "A", "b", "BB", "bb", "Bb", "bB" };

            foreach (string str in testData)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    hashTable[j].Add(str);
                }
            }

            foreach (string str in testData)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    Assert.IsTrue(hashTable[j].Exist(str).answer);
                }
            }
        }

        [TestMethod]
        public void DeleteAllTest()
        {
            string[] testData = { "a", "aa", "aaa", "A" };

            for (int i = 0; i < testData.Length; ++i)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    hashTable[j].Add(testData[i]);
                }
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    hashTable[j].Delete(testData[i]);
                }
            }

            for (int j = 0; j < hashTable.Length; ++j)
            {
                hashTable[j].DeleteAll();
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                for (int j = 0; j < hashTable.Length; ++j)
                {
                    (bool answer, bool success) result = hashTable[j].Exist(testData[i]);
                    Assert.IsFalse(result.answer);
                }
            }

        }
    }
}

namespace HashTableNameSpace.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HashTableNameSpace;

    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]

        public void Initialize()
        {
            int size = 5;
            hashTable = new HashTable(size);
        }

        private HashTable hashTable;

        [TestMethod]
        public void AddTest()
        {
            
        }

        [TestMethod]
        public void ExistTest()
        {

        }

        [TestMethod]
        public void IsEmptyTest()
        {

        }

        [TestMethod]
        public void DeleteTest()
        {
            
        }

        public void DeleteAllTest()
        {

        }
    }
}

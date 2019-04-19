using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueueNamespace.Tests
{
    [TestClass]
    public class QueueTest
    {
        [TestInitialize]
        public void Initialize()
        {
            queue = new Queue();
        }

        private Queue queue;

        [TestMethod]
        public void EnAndDequeueLightTest()
        {
            int[] testData = { 1, 5, 7, 9, 9 };
            int[] testPriority = { 1, 5, 7, 9, 9 };
            int[] testAnswer = { 9, 9, 7, 5, 1 };

            for (int i = 0; i < testData.Length; ++i)
            {
                queue.Enqueue(testPriority[i], testData[i]);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], queue.Dequeue());
            }

        }

        [TestMethod]
        public void EnAndDequeueHardTest()
        {
            int[] testData = { 4, 1, 2, 3, 5, 6 };
            int[] testPriority = { 5, 1, 1, 4, 8, 8 };
            int[] testAnswer = { 6, 5, 4, 3, 2, 1 };

            for (int i = 0; i < testData.Length; ++i)
            {
                queue.Enqueue(testPriority[i], testData[i]);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], queue.Dequeue());
            }

        }

        [TestMethod]
        public void DeleteAllTest()
        {
            int[] testData = { 4, 1, 2, 3, 5, 6 };
            int[] testPriority = { 5, 1, 1, 4, 8, 8 };

            Assert.IsFalse(!queue.IsEmpty());

            for (int i = 0; i < testData.Length; ++i)
            {
                queue.Enqueue(testPriority[i], testData[i]);
            }

            for (int i = 0; i < testData.Length; ++i)
            {
                queue.Dequeue();
            }

            Assert.IsFalse(!queue.IsEmpty());
        }
    }
}

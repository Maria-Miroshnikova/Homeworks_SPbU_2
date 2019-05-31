using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test_2_4.Tests
{
    [TestClass]
    public class AlgorithmTests
    {
        [TestMethod]
        public void CompressionEasyTest()
        {
            int[] testDataInt = { 2, 1, 3, 4, 0, 255 };
            int[] testAnswer = { 1, 2, 1, 1, 1, 3, 1, 4, 1, 0, 1, 255 };

            var testData = new byte[testDataInt.Length];
            for (int i = 0; i < testData.Length; ++i)
            {
                testData[i] = Convert.ToByte(testDataInt[i]);
            }

            testData = Algorithm.Compression(testData);

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], Convert.ToInt32(testData[i]));
            }
        }

        [TestMethod]
        public void CompressionEqualBytesInEndOfArrayTest()
        {
            int[] testDataInt = { 2, 2, 2, 3, 0, 2, 1, 1, 1 };
            int[] testAnswer = { 3, 2, 1, 3, 1, 0, 1, 2, 3, 1};

            var testData = new byte[testDataInt.Length];
            for (int i = 0; i < testData.Length; ++i)
            {
                testData[i] = Convert.ToByte(testDataInt[i]);
            }

            testData = Algorithm.Compression(testData);

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], Convert.ToInt32(testData[i]));
            }
        }

        [TestMethod]
        public void CompressionNotEqualBytesInEndOfArrayTest()
        {
            int[] testDataInt = { 2, 2, 2, 3, 0, 2, 1, 1, 1, 4 };
            int[] testAnswer = { 3, 2, 1, 3, 1, 0, 1, 2, 3, 1, 1, 4 };

            var testData = new byte[testDataInt.Length];
            for (int i = 0; i < testData.Length; ++i)
            {
                testData[i] = Convert.ToByte(testDataInt[i]);
            }

            testData = Algorithm.Compression(testData);

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], Convert.ToInt32(testData[i]));
            }
        }

        [TestMethod]
        public void DecompressionEasyTest()
        {
            int[] testDataInt = { 1, 2, 1, 1, 1, 3, 1, 4, 1, 0, 1, 255 };
            int[] testAnswer = { 2, 1, 3, 4, 0, 255 };

            var testData = new byte[testDataInt.Length];
            for (int i = 0; i < testData.Length; ++i)
            {
                testData[i] = Convert.ToByte(testDataInt[i]);
            }

            testData = Algorithm.Decompression(testData);

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], Convert.ToInt32(testData[i]));
            }
        }

        [TestMethod]
        public void DecompressionEqualBytesInEndOfArrayTest()
        {
            int[] testDataInt = { 3, 2, 1, 3, 1, 0, 1, 2, 3, 1 };
            int[] testAnswer = { 2, 2, 2, 3, 0, 2, 1, 1, 1 };
            
            var testData = new byte[testDataInt.Length];
            for (int i = 0; i < testData.Length; ++i)
            {
                testData[i] = Convert.ToByte(testDataInt[i]);
            }

            testData = Algorithm.Decompression(testData);

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], Convert.ToInt32(testData[i]));
            }
        }

        [TestMethod]
        public void DecompressionNotEqualBytesInEndOfArrayTest()
        {

            int[] testDataInt = { 3, 2, 1, 3, 1, 0, 1, 2, 3, 1, 1, 4 };
            int[] testAnswer = { 2, 2, 2, 3, 0, 2, 1, 1, 1, 4 };

            var testData = new byte[testDataInt.Length];
            for (int i = 0; i < testData.Length; ++i)
            {
                testData[i] = Convert.ToByte(testDataInt[i]);
            }

            testData = Algorithm.Decompression(testData);

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], Convert.ToInt32(testData[i]));
            }
        }
    }
}

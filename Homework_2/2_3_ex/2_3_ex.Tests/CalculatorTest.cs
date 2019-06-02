using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackNameSpace.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Stack1Test1()
        {
            string testData = "9 6 - 1 2 + *";
            int testAnswer = 9;
            int stackType = 1;

            Assert.AreEqual(testAnswer, Calculator.Calculate(testData, stackType));
        }

        [TestMethod]
        public void Stack1Test2()
        {
            string testData = "5 2 * 5 / 3 + 2 * 1 -";
            int testAnswer = 9;
            int stackType = 1;

            Assert.AreEqual(testAnswer, Calculator.Calculate(testData, stackType));
        }

        [TestMethod]
        public void Stack1Test3()
        {
            string testData = "1 2 - 1 2 - *1 2 - *";
            int testAnswer = -1;
            int stackType = 1;

            Assert.AreEqual(testAnswer, Calculator.Calculate(testData, stackType));
        }

        [TestMethod]
        public void Stack2Test1()
        {
            string testData = "9 6 - 1 2 + *";
            int testAnswer = 9;
            int stackType = 2;

            Assert.AreEqual(testAnswer, Calculator.Calculate(testData, stackType));
        }

        [TestMethod]
        public void Stack2Test2()
        {
            string testData = "5 2 * 5 / 3 + 2 * 1 -";
            int testAnswer = 9;
            int stackType = 2;

            Assert.AreEqual(testAnswer, Calculator.Calculate(testData, stackType));
        }

        [TestMethod]
        public void Stack2Test3()
        {
            string testData = "1 2 - 1 2 - *1 2 - *";
            int testAnswer = -1;
            int stackType = 2;

            Assert.AreEqual(testAnswer, Calculator.Calculate(testData, stackType));
        }
    }
}

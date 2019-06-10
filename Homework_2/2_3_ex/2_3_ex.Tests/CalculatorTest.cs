using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackNameSpace.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void StackOnArrayEasyTest()
        {
            string[] testData = { "9 6 - 1 2 + *", "5 2 * 5 / 3 + 2 * 1 -", "1 2 - 1 2 - *1 2 - *" };
            (int, bool)[] testAnswer = { (9, true), (9, true), (-1, true) };
            var calculatorArray = new Calculator(new StackOnArray());
            var calculatorList = new Calculator(new StackOnList());

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], calculatorArray.Calculate(testData[i]));
                Assert.AreEqual(testAnswer[i], calculatorList.Calculate(testData[i]));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullStackException))]
        public void NoStackTest()
        {
            string[] testData = { "9 6 - 1 2 + *", "5 2 * 5 / 3 + 2 * 1 -", "1 2 - 1 2 - *1 2 - *" };
            (int, bool)[] testAnswer = { (9, true), (9, true), (-1, true) };
            var calculator = new Calculator();

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], calculator.Calculate(testData[i]));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullStackException))]
        public void NullStackTest()
        {
            string[] testData = { "9 6 - 1 2 + *", "5 2 * 5 / 3 + 2 * 1 -", "1 2 - 1 2 - *1 2 - *" };
            (int, bool)[] testAnswer = { (9, true), (9, true), (-1, true) };
            var calculator = new Calculator(null);

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], calculator.Calculate(testData[i]));
            }
        }

        [TestMethod]
        public void EmptyDataTest()
        {
            string[] testData = { "", null };
            (int, bool)[] testAnswer = { (0, false), (0, false) };
            var calculatorArray = new Calculator(new StackOnArray());
            var calculatorList = new Calculator(new StackOnList());

            for (int i = 0; i < testAnswer.Length; ++i)
            {
                Assert.AreEqual(testAnswer[i], calculatorArray.Calculate(testData[i]));
                Assert.AreEqual(testAnswer[i], calculatorList.Calculate(testData[i]));
            }
        }
    }
        
}

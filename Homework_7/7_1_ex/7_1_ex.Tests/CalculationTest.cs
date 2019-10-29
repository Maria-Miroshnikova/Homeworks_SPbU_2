using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _7_1_ex.Tests
{
    [TestClass]
    public class CalculationTest
    {
        private Calculation testCalculation;
        private float testCurrentData;

        [TestInitialize]
        public void Initialize()
        {
            testCalculation = new Calculation();
        }

        [TestMethod]
        public void ZeroDivisionTest()
        {
            float[] data1 = { 1, 0 };
            float[] data2 = { 5, 6, 30, 0 };
            Operation[] operations1 = { Operation.DIVISION };
            Operation[] operations2 = { Operation.MULTIPLICATION, Operation.MINUS, Operation.DIVISION };

            testCalculation.PushStack(data1[0]);
            testCalculation.PushStack(data1[1]);
            Assert.IsFalse(testCalculation.Calculate(ref testCurrentData, operations1[0]));

            testCalculation.PushStack(data2[0]);
            testCalculation.PushStack(data2[1]);
            Assert.IsTrue(testCalculation.Calculate(ref testCurrentData, operations2[0]));
            testCalculation.PushStack(data2[2]);
            Assert.IsTrue(testCalculation.Calculate(ref testCurrentData, operations2[1]));
            testCalculation.PushStack(data2[3]);
            Assert.IsFalse(testCalculation.Calculate(ref testCurrentData, operations2[2]));
        }

        [TestMethod]
        public void CalculationLongTest()
        {
            float[] data = { 4, 8, 22, -1, -3, 0.4F, -10 }; // 4 + 8 - 22 * -1 * -3 + 0.4 / -10
            float[] testAnswer = { 12, -10, 10, -30, -30.4F, 3.04F };
            Operation[] operations = { Operation.PLUS, Operation.MINUS, Operation.MULTIPLICATION, Operation.MULTIPLICATION, Operation.MINUS, Operation.DIVISION };
            float currentData = 0;

            testCalculation.PushStack(data[0]);
            for (int i = 1; i < data.Length; ++i)
            {
                testCalculation.PushStack(data[i]);
                testCalculation.Calculate(ref currentData, operations[i - 1]);
                Assert.AreEqual(testAnswer[i - 1], currentData, 0.00001);
            }
        }
    }
}

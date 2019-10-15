using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _4_1_exer.Tests
{
    [TestClass]
    public class ParsingTreeTest
    {

        [TestMethod]
        public void OneLevelTest()
        {
            string testData = "(* 3 7)";
            int testAnswer = 21;

            var testTree = new ParsingTree(testData);
            Assert.AreEqual(testAnswer, testTree.CountExpression());
        }

        [TestMethod]
        public void LeftNodeAndRightSubTreeTest()
        {
            string testData = "(- 4 (* 6  2))";
            int testAnswer = -8;

            var testTree = new ParsingTree(testData);
            Assert.AreEqual(testAnswer, testTree.CountExpression());
        }

        [TestMethod]
        public void LeftSubTreeAndRightNodeTest()
        {
            string testData = "(/ (- 9 1) 2)";
            int testAnswer = 4;

            var testTree = new ParsingTree(testData);
            Assert.AreEqual(testAnswer, testTree.CountExpression());
        }

        [TestMethod]
        public void TwoLevelsTest()
        {
            string testData = "(+ (* 2 4) (- 0 9))";
            int testAnswer = -1;

            var testTree = new ParsingTree(testData);
            Assert.AreEqual(testAnswer, testTree.CountExpression());
        }

        [TestMethod]
        public void LongTest()
        {
            string testData = "( * ( + 1 1) ( / 8 ( + ( * 1 1) ( - 5 2 ) ) ) )";
            int testAnswer = 4;

            var testTree = new ParsingTree(testData);
            Assert.AreEqual(testAnswer, testTree.CountExpression());
        }

        [TestMethod]
        [ExpectedException(typeof(ZeroDivisionException))]
        public void ZeroDivisionEasyTest()
        {
            string testData = "(/ 4 0)";

            var testTree = new ParsingTree(testData);
            testTree.CountExpression();
        }

        [TestMethod]
        [ExpectedException(typeof(ZeroDivisionException))]
        public void ZeroDivisionInsideTheExpressionTest()
        {
            string testData = "(/ (* 2  4) (+ 7 (- 2 9)))";

            var testTree = new ParsingTree(testData);
            testTree.CountExpression();
        }

        [TestMethod]
        public void PrintTest()
        {
            string[] testData = { "(* 3 7)", "(- 4 (* 6  2))", "(/ (- 9 1) 2)", "( * ( + 1 1) ( / 8 ( + ( * 1 1) ( - 5 2 ) ) ) )" };
            string[] testAnswer = { "( 3 * 7 )", "( 4 - ( 6 * 2 ) )", "( ( 9 - 1 ) / 2 )", "( ( 1 + 1 ) * ( 8 / ( ( 1 * 1 ) + ( 5 - 2 ) ) ) )"};

            for (int i = 0; i < testData.Length; ++i)
            {
                var testTreePrint = new ParsingTree(testData[i]);
                testTreePrint.CountExpression();
                Assert.AreEqual(testAnswer[i], testTreePrint.Print());
            }
        }
    }
}

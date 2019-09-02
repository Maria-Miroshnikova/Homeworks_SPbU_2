using System;

namespace _4_1_exer
{
    /// <summary>
    /// This class presents a parsing tree, which is made from string, contains only '()/*+-' and numbers from 0 to 9;
    /// The string presents an expression in correct form: '(<operation> <operand_1> <operand_2>)'.
    /// </summary>
    public class ParsingTree
    {
        /// <summary>
        /// This inner class presents a node of parsing tree;
        /// </summary>
        private abstract class ParsingTreeElement
        {
            /// <summary>
            /// This property presents left node of current node in the tree;
            /// </summary>
            public ParsingTreeElement LeftNode { get; set; }

            /// <summary>
            /// This property presents right node of current node in the tree;
            /// </summary>
            public ParsingTreeElement RightNode { get; set; }

            /// <summary>
            /// This method returns the value of expression which contains in the sub tree whith root in current node;
            /// </summary>
            public abstract int Count();
        }

        /// <summary>
        /// This inner class presents a node of parsing tree, which contains an operation (+-/*);
        /// </summary>
        private class NodeOperation : ParsingTreeElement
        {
            /// <summary>
            /// This property presents the operation which contains in current node of tree;
            /// </summary>
            public char Operation { get; set; }

            public NodeOperation(char operation = '\0')
            {
                this.Operation = operation;
            }

            public override int Count()
            {
                if (Operation == '+')
                {
                    return LeftNode.Count() + RightNode.Count();
                }
                else if (Operation == '-')
                {
                    return LeftNode.Count() - RightNode.Count();
                }
                else if (Operation == '*')
                {
                    return LeftNode.Count() * RightNode.Count();
                }
                else
                {
                    int firstOperand = LeftNode.Count();
                    int secondOperand = RightNode.Count();
                    if (secondOperand == 0)
                    {
                        throw new ZeroDivisionException();
                    }
                    return firstOperand / secondOperand;
                }
            }
        }

        /// <summary>
        /// This inner class presents a node of parsing tree, which contain a number (from 0 to 9);
        /// </summary>
        private class NodeNumber : ParsingTreeElement
        {
            /// <summary>
            /// This property presents the number which contains in current node of tree;
            /// </summary>
            public int Value { get; }

            public NodeNumber(int value = -10)
            {
                this.Value = value;
            }

            public override int Count()
            {
                return Value;
            }
        }

        private string data;
        private ParsingTreeElement currentNode;
        private ParsingTreeElement head;
        private int indexStr;

        public ParsingTree(string data)
        {
            this.data = data;
            this.currentNode = null;
            this.head = null;
            this.indexStr = 0;
        }

        /// <summary>
        /// This method returns true if tree is empty and false otherwise;
        /// </summary>
        public bool IsEmpty
            => head == null;

        private bool AddNumber()
        {
            while ((data[indexStr] >= '0') && (data[indexStr] <= '9'))
            {
                bool isRightNodeNull = true;
                if (currentNode.LeftNode == null)
                {
                    currentNode.LeftNode = new NodeNumber(data[indexStr] - '0');
   //                 currentNode = currentNode.LeftNode;
                }
                else
                {
                    currentNode.RightNode = new NodeNumber(data[indexStr] - '0');
 //                   currentNode = currentNode.RightNode;
                    isRightNodeNull = false;
                    return isRightNodeNull;
                }
                if (!GetNewChar())
                {
                    return false;
                }
            }
            return true;
        }

        private void MakeParsingTree()
        {
            if (!GetNewChar())
            {
                return;
            }

            if (!AddNumber())
            {
                return;
            }

            while ((data[indexStr] == '*') || (data[indexStr] == '/') || (data[indexStr] == '+') || (data[indexStr] == '-'))
            {
                if (IsEmpty)
                {
                    currentNode = new NodeOperation(data[indexStr]);
                    head = currentNode;
                    MakeParsingTree();

                }
                else if (currentNode.LeftNode == null)
                {
                    currentNode.LeftNode = new NodeOperation(data[indexStr]);
                    var oldNode = currentNode;
                    currentNode = currentNode.LeftNode;
                    MakeParsingTree();
                    currentNode = oldNode;
                }
                else
                {
                    currentNode.RightNode = new NodeOperation(data[indexStr]);
                    var oldNode = currentNode;
                    currentNode = currentNode.RightNode;
                    MakeParsingTree();
                    currentNode = oldNode;
                    return;
                }

                if (!GetNewChar())
                {
                    return;
                }
            }

            if (!AddNumber())
            {
                return;
            }

        }

        /// <summary>
        /// This method returns the value of expression which contains in parsing tree;
        /// </summary>
        /// <returns></returns>
        public int CountExpression()
        {
            MakeParsingTree();
            return head.Count();
        }

        /// <summary>
        /// This method deletes parsing tree;
        /// </summary>
        public void DeleteTree()
            => head = null;

        private bool GetNewSymbolFromStr()
        {
            if (indexStr >= data.Length - 1)
            {
                return false;
            }
            else
            {
                ++indexStr;
                return true;
            }
        }

        private bool GetNewChar()
        {
            if (!GetNewSymbolFromStr())
            {
                return false;
            }
            while ((data[indexStr] == '(') || (data[indexStr] == ')') || (data[indexStr] == ' '))
            {
                if (!GetNewSymbolFromStr())
                {
                    return false;
                }
            }
            return true;
        }
    }
}

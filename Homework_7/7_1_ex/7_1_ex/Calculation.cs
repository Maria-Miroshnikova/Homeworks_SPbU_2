using System;
using System.Collections.Generic;

namespace _7_1_ex
{
    public class Calculation
    {
        private Stack<float> stack = new Stack<float>();

        public void PushStack(float data)
        {
            stack.Push(data);
        }

        public bool Calculate(ref float currentData, Operation operation)
        {
            if (stack.Count == 0)
            {
                return true;
            }
            var secondOperand = stack.Pop();

            if (stack.Count == 0)
            {
                stack.Push(secondOperand);
                return true;
            }
            var firstOperand = stack.Pop();

            switch (operation)
            {
                case Operation.PLUS:
                    currentData = firstOperand + secondOperand;
                    break;

                case Operation.MINUS:
                    currentData = firstOperand - secondOperand;
                    break;

                case Operation.MULTIPLICATION:
                    currentData = firstOperand * secondOperand;
                    break;

                case Operation.DIVISION:
                    if (secondOperand == 0)
                    {
                        return false;
                    }
                    currentData = firstOperand / secondOperand;
                    break;

                default:
                    throw new InvalidOperationException();
            }

            stack.Push(currentData);
            return true;
        }
    }
}

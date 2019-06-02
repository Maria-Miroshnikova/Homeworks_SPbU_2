using System;

namespace StackNameSpace
{
    /// <summary>
    /// Class Calculator, which provides to calculate the value of expression (in postfix form), which contains numbers and ' +-*/' only.
    /// </summary>
    public static class Calculator
    {
        /// <summary>
        /// This method calculates and returns the value of expression.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="stackType"></param>
        /// <returns></returns>
        public static int Calculate(string data, int stackType)
        {
            IStackable stack;

            if (stackType == 1)
            {
                stack = new Stack1();
            }
            else
            {
                stack = new Stack2();
            }

            for (int i = 0; i < data.Length; ++i)
            {
                if (data[i] == ' ')
                {
                    ++i;
                }

                if (data[i] == '*')
                {
                    stack.Push(stack.Pop().answer * stack.Pop().answer);
                }
                else if (data[i] == '/')
                {
                    int firstValue = stack.Pop().answer;
                    int secondValue = stack.Pop().answer;
                    stack.Push(secondValue / firstValue);
                }
                else if (data[i] == '+')
                {
                    stack.Push(stack.Pop().answer + stack.Pop().answer);
                }
                else if (data[i] == '-')
                {
                    int firsValue = stack.Pop().answer;
                    int secondValue = stack.Pop().answer;
                    stack.Push(secondValue - firsValue);
                }

                else
                {
                    stack.Push(data[i] - '0');
                }
            }

            int answer = stack.Pop().answer;
            stack.Clear();
            return answer;
        }
    }
}

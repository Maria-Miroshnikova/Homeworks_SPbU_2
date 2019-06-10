using System;

namespace StackNameSpace
{
    /// <summary>
    /// Class Calculator, which provides to calculate the value of expression (in postfix form), which contains numbers and ' +-*/' only.
    /// </summary>
    public class Calculator
    {
        private IStack stack;

        public Calculator(IStack stack = null)
        {
            if (stack == null)
            {
                throw new NullStackException();
            }
            else
            {
                this.stack = stack;
            }
        }

        private bool IsNotEmptyData(string data)
            => (data != "") && (data != null);

        /// <summary>
        /// This method calculates and returns the value of expression.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="stackType"></param>
        /// <returns></returns>
        public (int answer, bool success) Calculate(string data)
        {
            if (!IsNotEmptyData(data))
            {
                return (0, false);
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
            return (answer, true);
        }
    }
}

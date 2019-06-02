using System;

namespace StackNameSpace
{
    /// <summary>
    /// Class Stack1 (of ints), based on array of ints.
    /// </summary>
    class Stack1 : IStackable
    {
        private int head;
        private int size;
        private int[] stack;

        public Stack1()
        {
            int size = 1000;
            this.size = size;
            this.stack = new int[size];
            this.head = -1;
        }

        public int Size => size;

        public bool IsEmpty => head == -1;

        /// <summary>
        /// This method adds element to the stack;
        /// </summary>
        /// <param name="data"></param>
        public void Push(int data)
        {
            ++head;
            ++size;
            stack[head] = data;
        }

        /// <summary>
        /// This method deletes element from the stack and return it;
        /// </summary>
        /// <returns></returns>
        public (int answer, bool success) Pop()
        {
            (int answer, bool success) result = (0, false);

            if (IsEmpty)
            {
                return result;
            }

            result = (stack[head], true);
            --head;
            --size;
            return result;
        }

        /// <summary>
        /// This method deletes the stack;
        /// </summary>
        public void Clear()
        {
            stack = null;
        }
    }
}

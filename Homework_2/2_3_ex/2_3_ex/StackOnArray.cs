using System;

namespace StackNameSpace
{
    /// <summary>
    /// Class Stack1 (of ints), based on array of ints.
    /// </summary>
    public class StackOnArray : IStack
    {
        private int head;
        private int[] stack;

        public StackOnArray()
        {
            int size = 1000;
            this.stack = new int[size];
            this.head = -1;
        }

        /// <summary>
        /// This property returns the size of the stack;
        /// </summary>
        public int Size => head + 1;

        /// <summary>
        /// This property returns if the stack is empty;
        /// </summary>
        public bool IsEmpty => head == -1;

        /// <summary>
        /// This method adds element to the stack;
        /// If size is 1000, there will be TooMuchElementsInStackException;
        /// </summary>
        public void Push(int data)
        {
            if (Size == 1000)
            {
                throw new TooMuchElementsInStackException();
            }

            ++head;
            stack[head] = data;
        }

        /// <summary>
        /// This method deletes element from the stack and return it;
        /// </summary>
        public (int answer, bool success) Pop()
        {
            (int answer, bool success) result = (0, false);

            if (IsEmpty)
            {
                return result;
            }

            result = (stack[head], true);
            --head;
            return result;
        }

        /// <summary>
        /// This method deletes the stack;
        /// </summary>
        public void Clear()
            => stack = null;
    }
}

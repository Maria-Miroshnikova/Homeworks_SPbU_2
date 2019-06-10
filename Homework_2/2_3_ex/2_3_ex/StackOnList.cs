using System;

namespace StackNameSpace
{
    /// <summary>
    /// Class Stack2 (of ints), which looks like list of ints.
    /// </summary>
    public class StackOnList : IStack
    {
        /// <summary>
        /// Inner (for Stack2) class StackElement, which contains data (int) and pointer to the next element of stack.
        /// </summary>
        private class StackElement
        {
            public StackElement(int data, StackElement next)
            {
                this.Data = data;
                this.Next = next;
            }

            public int Data { get; set; }
            public StackElement Next { get; set; }
        }

        private StackElement head;
        private int size;

        /// <summary>
        /// This property returns the size of the stack;
        /// </summary>
        public int Size => size;

        /// <summary>
        /// This property returns if the stack is empty;
        /// </summary>
        public bool IsEmpty => head == null;

        /// <summary>
        /// This method adds data to the stack;
        /// If size is 1000, there will be TooMuchElementsInStackException;
        /// </summary>
        public void Push(int data)
        {
            int maxSize = 1000;
            if (Size == maxSize)
            {
                throw new TooMuchElementsInStackException();
            }

            var newElement = new StackElement(data, head);
            head = newElement;
            ++size;
        }

        /// <summary>
        /// This method deletes the first element of the stack and returns it;
        /// </summary>
        public (int answer, bool success) Pop()
        {
            (int answer, bool success) result = (0, false);

            if (IsEmpty)
            {
                return result;
            }

            result = (head.Data, true);

            head = head.Next;
            --size;

            return result;
        }

        /// <summary>
        /// This method deletes the stack;
        /// </summary>
        public void Clear()
        {
            head = null;
        }

    }
}

using System;

namespace StackNameSpace
{
    /// <summary>
    /// Class Stack2 (of ints), which looks like list of ints.
    /// </summary>
    class Stack2 : IStackable
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

        StackElement head;
        int size;

        public int Size => size;

        public bool IsEmpty => head == null;

        /// <summary>
        /// This method adds data to the stack;
        /// </summary>
        /// <param name="data"></param>
        public void Push(int data)
        {
            var newElement = new StackElement(data, head);
            head = newElement;
            ++size;
        }

        /// <summary>
        /// This method deletes the first element of the stack and returns it;
        /// </summary>
        /// <returns></returns>
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

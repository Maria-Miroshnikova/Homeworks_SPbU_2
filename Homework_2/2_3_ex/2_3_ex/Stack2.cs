using System;

namespace StackNameSpace
{
    class Stack2 : IStackable
    {
        private class StackElement
        {
            int data;
            StackElement next;

            public StackElement(int data, StackElement next)
            {
                this.data = data;
                this.next = next;
            }

            public int Data { get; set; }
            public StackElement Next { get; set; }
        }

        StackElement head;
        int size;

        public int Size => size;

        public bool IsEmpty => head == null;

        public void Push(int data)
        {
            var newElement = new StackElement(data, head);
            head = newElement;
            ++size;
        }

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

        public void Clear()
        {
            head = null;
        }

    }
}

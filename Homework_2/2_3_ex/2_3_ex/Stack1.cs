using System;

namespace StackNameSpace
{
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

        public void Push(int data)
        {
            ++head;
            ++size;
            stack[head] = data;
        }

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

        public void Clear()
        {
            stack = null;
        }
    }
}

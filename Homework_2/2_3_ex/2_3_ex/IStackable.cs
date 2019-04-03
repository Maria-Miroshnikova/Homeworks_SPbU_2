using System;

namespace StackNameSpace
{
    interface IStackable
    {
        int Size { get; }
        bool IsEmpty { get; }

        void Push(int data);
        (int answer, bool success) Pop();
        void Clear();
    }
}

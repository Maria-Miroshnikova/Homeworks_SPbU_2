using System;

namespace StackNameSpace
{
    /// <summary>
    /// Interface, which requires objects to behave like stack.
    /// </summary>
    public interface IStackable
    {
        int Size { get; }
        bool IsEmpty { get; }

        void Push(int data);
        (int answer, bool success) Pop();
        void Clear();
    }
}

using System;

namespace StackNameSpace
{
    /// <summary>
    /// Interface, which requires objects to behave like stack;
    /// </summary>
    public interface IStack
    {
        int Size { get; }
        bool IsEmpty { get; }

        /// <summary>
        /// This method adds data on the top of the stack;
        /// If size is 1000, there will be TooMuchElementsInStackException;
        /// </summary>
        /// <param name="data"></param>
        void Push(int data);

        /// <summary>
        /// This method returns and deletes top element from the stack;
        /// </summary>
        /// <returns></returns>
        (int answer, bool success) Pop();

        /// <summary>
        /// This method deletes the stack;
        /// </summary>
        void Clear();
    }
}

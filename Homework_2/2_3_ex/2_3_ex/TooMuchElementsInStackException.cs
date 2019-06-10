using System;

namespace StackNameSpace
{
    /// <summary>
    /// This exception should be trown when someone adds to stack more then 1000 elements.
    /// </summary>
    public class TooMuchElementsInStackException : Exception
    {
        public TooMuchElementsInStackException()
        {

        }

        public TooMuchElementsInStackException(string message)
            : base(message)
        {

        }
    }
}

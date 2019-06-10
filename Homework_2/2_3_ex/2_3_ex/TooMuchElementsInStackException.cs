using System;

namespace StackNameSpace
{
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
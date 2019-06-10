using System;

namespace StackNameSpace
{
    /// <summary>
    /// This exception should be trown when someone try to create Calculator with no stack.
    /// </summary>
    public class NullStackException : Exception
    {
        public NullStackException()
        {

        }

        public NullStackException(string message)
            : base(message)
        {

        }
    }
}

using System;

namespace StackNameSpace
{
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

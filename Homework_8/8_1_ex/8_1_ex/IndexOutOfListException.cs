using System;

namespace ListNameSpace
{
    /// <summary>
    /// This exception should be trown when someone try to work with index out of list.
    /// </summary>
    public class IndexOutOfListException : Exception
    {
        public IndexOutOfListException()
        {

        }

        public IndexOutOfListException(string message)
            : base(message)
        {

        }
    }
}

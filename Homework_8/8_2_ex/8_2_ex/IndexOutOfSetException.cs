using System;

namespace _8_2_ex
{
    /// <summary>
    /// This exception should be thrown when index is out of set.
    /// </summary>
    public class IndexOutOfSetException : Exception
    {
        public IndexOutOfSetException()
        {

        }

        public IndexOutOfSetException(string message)
            : base(message)
        {

        }
    }
}

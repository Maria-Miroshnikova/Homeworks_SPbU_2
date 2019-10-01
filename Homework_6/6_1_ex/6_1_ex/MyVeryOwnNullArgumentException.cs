using System;

namespace _6_1_ex
{
    /// <summary>
    /// This exception should be thrown if there is null argument;
    /// </summary>
    public class MyVeryOwnNullArgumentException : Exception
    {
        public MyVeryOwnNullArgumentException()
        {

        }

        public MyVeryOwnNullArgumentException(string message)
            : base(message)
        {

        }
    }
}

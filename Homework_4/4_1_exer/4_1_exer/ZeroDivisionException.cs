using System;

namespace _4_1_exer
{
    /// <summary>
    /// This exception is thrown when there is division by zero;
    /// </summary>
    public class ZeroDivisionException : Exception
    {
        public ZeroDivisionException()
        {
        }

        public ZeroDivisionException(string message)
            : base(message)
        {
        }
    }
}

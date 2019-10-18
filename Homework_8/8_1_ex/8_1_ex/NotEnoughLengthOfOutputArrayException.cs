using System;

namespace ListNameSpace
{
    /// <summary>
    /// This exception should be thrown if there is not enough
    /// length of outputArray for putting too mush elements to it.
    /// </summary>
    public class NotEnoughLengthOfOutputArrayException : Exception
    {
        public NotEnoughLengthOfOutputArrayException()
        {

        }

        public NotEnoughLengthOfOutputArrayException(string message)
            : base(message)
        {

        }
    }
}
using System;

namespace _8_2_ex
{
    /// <summary>
    /// This exception should be thrown if there is not enough
    /// length of outputArray for putting too mush elements to it.
    /// </summary>
    public class NotEnoughLengthOfOutputArray : Exception
    {
        public NotEnoughLengthOfOutputArray()
        {

        }

        public NotEnoughLengthOfOutputArray(string message)
            : base(message)
        {

        }
    }
}

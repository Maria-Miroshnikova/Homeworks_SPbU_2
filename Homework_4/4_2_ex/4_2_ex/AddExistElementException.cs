using System;

namespace UniqueListNameSpace
{
    /// <summary>
    /// This exception should be trown when someone adds existing in list element to the list.
    /// </summary>
    public class AddExistElementException : Exception
    {
        public AddExistElementException()
        {

        }

        public AddExistElementException(string message)
            : base(message)
        {

        }
    }
}

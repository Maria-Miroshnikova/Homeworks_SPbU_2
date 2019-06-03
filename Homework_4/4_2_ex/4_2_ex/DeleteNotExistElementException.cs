using System;

namespace UniqueListNameSpace
{
    /// <summary>
    /// This exception should be trown when someone deletes not existing in list element from the list.
    /// </summary>
    public class DeleteNotExistElementException : Exception
    {
        public DeleteNotExistElementException()
        {

        }

        public DeleteNotExistElementException(string message)
            : base(message)
        {

        }
    }
}

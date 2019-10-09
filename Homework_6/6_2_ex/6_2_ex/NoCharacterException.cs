using System;

namespace _6_2_ex
{
    /// <summary>
    /// Should be thrown when there is no character ('@') on game map;
    /// </summary>
    public class NoCharacterException : Exception
    {
        public NoCharacterException()
        {

        }

        public NoCharacterException(string message)
            : base(message)
        {

        }
    }
}

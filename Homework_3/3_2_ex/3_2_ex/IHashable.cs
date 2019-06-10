using System;

namespace HashTableNameSpace
{
    /// <summary>
    /// Interface, which requires objects to have hash function;
    /// </summary>
    public interface IHashable
    {
        /// <summary>
        /// This method returns hash for data;
        /// </summary>
        /// <param name="data"></param>
        int HashFunction(string data);
    }
}

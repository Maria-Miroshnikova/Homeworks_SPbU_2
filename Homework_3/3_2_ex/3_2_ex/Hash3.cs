using System;

namespace HashTableNameSpace
{
    /// <summary>
    /// Class Hash1 which provide the hash function (negative constant);
    /// </summary>
    public class Hash3 : IHashable
    {
        /// <summary>
        /// This method returns hash for data;
        /// </summary>
        /// <param name="data"></param>
        public int HashFunction(string data)
        {
            int constHash = -10;
            return constHash;
        }
    }
}

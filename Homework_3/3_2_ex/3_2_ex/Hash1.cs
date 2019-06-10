using System;

namespace HashTableNameSpace
{
    /// <summary>
    /// Class Hash1 which provide the hash function (polynomial);
    /// </summary>
    public class Hash1 : IHashable
    {
        /// <summary>
        /// This method returns hash for data;
        /// </summary>
        /// <param name="data"></param>
        public int HashFunction(string data)
        {
            int prime = 7;
            int hash = 0;
            foreach (var i in data)
            {
                hash = hash * prime + (i - '0');
            }
            return hash;
        }
    }
}

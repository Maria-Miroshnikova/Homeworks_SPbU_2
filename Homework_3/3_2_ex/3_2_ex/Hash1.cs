using System;

namespace HashTableNameSpace
{
    public class Hash1 : IHashable
    {
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

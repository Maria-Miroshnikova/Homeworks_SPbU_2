using System;

namespace HashTableNameSpace
{
    public interface IHashable
    {
        int HashFunction(string data);
    }
}

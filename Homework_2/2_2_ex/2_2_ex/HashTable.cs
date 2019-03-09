using System;

namespace HashTableNameSpace
{
    /// <summary>
    /// 
    /// 
    /// </summary>

    public class HashTable
    {
        public HashTable(int size)
        {
            this.buckets = new List[size];
            this.size = size;
        }

        private List[] buckets;
        private int size;

        private int HashFunction(string str)
        {
            int prime = 7;
            int hash = 0;
            foreach (var i in str)
            {
                hash = hash * prime + (i - '0');
            }
            return Math.Abs(hash);
        }

        public bool Exist(string findWord)
        {
            int hash = HashFunction(findWord) % buckets.Length;
            if (buckets[hash].Exist(findWord))
            {
                return true;
            }
            return false;
        }
        
        public bool Add(string newWord)
        {
	        int hash = HashFunction(newWord) % buckets.Length;
            if (!Exist(newWord))
            {
                buckets[hash].Add(1, newWord);
                return true;
            }

            return false;
        }

        public bool Delete(string word)
        {
            int hash = HashFunction(word) % buckets.Length;
            int indexWord = buckets[hash].Find(word);

            if (indexWord != 0)
            {
                buckets[hash].Delete(indexWord);
                return true;
            }

            return false;
        }

        public void DeleteAll()
        {
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i].DeleteAll();
            }
        }
    }
}

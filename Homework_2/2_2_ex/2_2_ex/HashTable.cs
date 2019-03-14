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

        private bool IsCorrectData(string str)
        {
            if ((str == "\0") || (str == ""))
            {
                return false;
            }
            return true;
        }

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

        public (bool answer, bool success) Exist(string findWord)
        {
            if (!IsCorrectData(findWord))
            {
                return (false, false);
            }

            int hash = HashFunction(findWord) % buckets.Length;
            if (buckets[hash].Exist(findWord))
            {
                return (true, true);
            }
            return (false, true);
        }
        
        public (bool answer, bool success) Add(string newWord)
        {
            if (!IsCorrectData(newWord))
            {
                return (false, false);
            }

            int hash = HashFunction(newWord) % buckets.Length;

            if (!Exist(newWord).answer)
            {
                buckets[hash].Add(1, newWord);
                return (true, true);
            }

            return (false, true);
        }

        public (bool answer, bool success) Delete(string word)
        {
            if (!IsCorrectData(word))
            {
                return (false, false);
            }

            int hash = HashFunction(word) % buckets.Length;
            int indexWord = buckets[hash].Find(word);

            if (indexWord != 0)
            {
                buckets[hash].Delete(indexWord);
                return (true, true);
            }

            return (false, true);
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

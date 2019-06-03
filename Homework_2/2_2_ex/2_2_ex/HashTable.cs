using System;

namespace HashTableNameSpace
{
    /// <summary>
    ///  class HashTable (of unique strings), based on array of Lists.
    /// </summary>
    public class HashTable
    {
        private List[] buckets;
        private int size;
        private int notEmptyBuckets;
        private double loadFactor;

        public HashTable(int size = 5)
        {
            this.size = size;
            this.buckets = new List[size];
            for (int i = 0; i < size; ++i)
            {
                this.buckets[i] = new List();
            }
            this.loadFactor = 0;
        }

        private bool IsCorrectData(string str) => (str != "") && (str != "\0");

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

        private void UpdateHashTable()
        {
            double maxLoadFactor = 0.7;

            if (loadFactor >= maxLoadFactor)
            {
                int updateSizeFactor = 2;

                var newHashTable = new HashTable(size * updateSizeFactor);

                for (int i = 0; i < size; ++i)
                {
                    for (int j = 1; j <= buckets[i].Size; ++j)
                    {
                        newHashTable.Add(buckets[i].Get(j).answer);
                    }
                }

                buckets = newHashTable.buckets;
                size = newHashTable.size;
                notEmptyBuckets = newHashTable.notEmptyBuckets;
                loadFactor = newHashTable.loadFactor;
            }
        }

        /// <summary>
        /// The method which checks if the word presents in hashtable.
        /// </summary>
        /// <param name="findWord"> The word which presence you want to check.</param>
        /// <returns> (true, true) - if the word presents in hashtable
        /// (false, true) - if it doesn`t
        /// (false, false) - if data is incorrect</returns>
        public (bool answer, bool success) Exist(string findWord)
        {
            if (!IsCorrectData(findWord))
            {
                return (false, false);
            }

            int hash = HashFunction(findWord) % buckets.Length;

            return (buckets[hash].Exist(findWord), true);
        }

        /// <summary>
        /// The method which adds the word to hashtable.
        /// </summary>
        /// <param name="newWord">The word which you want to add</param>
        /// <returns> (true, true) - if the word was added to hashtable
        /// (false, true) - if it wasn`t because it already presents
        /// (false, false) - if data is incorrect</returns>
        public (bool answer, bool success) Add(string newWord)
        {
            if (!IsCorrectData(newWord))
            {
                return (false, false);
            }

            UpdateHashTable();

            int hash = HashFunction(newWord) % buckets.Length;

            if (!Exist(newWord).answer)
            {
                if (buckets[hash].IsEmpty)
                {
                    ++notEmptyBuckets;
                    loadFactor = (notEmptyBuckets * 1.0) / size;
                }
                buckets[hash].Add(1, newWord);
                return (true, true);
            }

            return (false, true);
        }

        /// <summary>
        /// The method which deletes the word from hashtable.
        /// </summary>
        /// <param name="word">The word which you want to delete</param>
        /// <returns> (true, true) - if the word was deleted from hashtable
        /// (false, true) - if it wasn`t because it already doesn`t present
        /// (false, false) - if data is incorrect</returns>
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
                if (buckets[hash].IsEmpty)
                {
                    --notEmptyBuckets;
                    loadFactor = (notEmptyBuckets * 1.0) / size;
                }
                return (true, true);
            }

            return (false, true);
        }

        /// <summary>
        /// The method which deletes all elements from hashtable.
        /// </summary>
        public void DeleteAll()
        {
            for (int i = 0; i < buckets.Length; ++i)
            {
                buckets[i].DeleteAll();
            }

            int startSize = 5;
            buckets = new List[startSize];
            for (int i = 0; i < size; ++i)
            {
                buckets[i] = new List();
            }
            size = startSize;
            loadFactor = 0;
            notEmptyBuckets = 0;
        }
    }
}

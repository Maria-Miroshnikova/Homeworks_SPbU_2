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

        public HashTable(int size)
        {
            this.buckets = new List[size];
            for (int i = 0; i < size; ++i)
            {
                this.buckets[i] = new List();
            }
            this.size = size;
        }

        private bool IsCorrectData(string str)
            => (str != "") && (str != "\0");

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

            if (buckets[hash].Exist(findWord))
            {
                return (true, true);
            }
            return (false, true);
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

            int hash = HashFunction(newWord) % buckets.Length;

            if (!Exist(newWord).answer)
            {
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
        }
    }
}

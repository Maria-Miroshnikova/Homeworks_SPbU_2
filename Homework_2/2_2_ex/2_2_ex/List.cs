using System;

namespace HashTableNameSpace
{
    /// <summary>
    ///  class List (of strings), made of ListsElements (inner class).
    /// </summary>
    class List
    {
        /// <summary>
        ///  class ListElement (of strings).
        /// </summary>
        private class ListElement
        {
            public ListElement(string data, ListElement next)
            {
                this.Data = data;
                this.Next = next;
            }
            
            public string Data { get; set; }
            public ListElement Next { get; set; }
        }

        private ListElement head;
        private int size;

        public bool IsEmpty => head == null;

        public int Size => size;

        private ListElement FindPrevious(int index)
        {
            int i = 1;
            ListElement element = head;
            while (i < index - 1)
            {
                element = element.Next;
                ++i;
            }
            return element;
        }

        /// <summary>
        /// The method which find the word in list.
        /// </summary>
        /// <param name="data"> The word which you want to find </param>
        /// <returns> the index of the word in list or 0 if it doesn`t present.</returns>
        public int Find(string data)
        {
            for (int i = 1; i <= size; ++i)
            {
                if (this.Get(i).answer == data)
                {
                    return i;
                }
            }

            return 0;
        }

        /// <summary>
        /// The method which checks if the word presents in list.
        /// </summary>
        /// <param name="data"> The word which presence you want to check.</param>
        /// <returns> true if the word presents and false otherwise.</returns>
        public bool Exist(string data)
        {
            for (int i = 1; i <= size; ++i)
            {
                if (this.Get(i).answer == data)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// The method which adds if the word to the position of list.
        /// </summary>
        /// <param name="index"> The position of list to which you want to add the element.</param>
        /// <param name="data"> The word which you want to add to the position of list.</param>
        /// <returns> true if the word was added and false if the position was incorrect</returns>
        public bool Add(int index, string data)
        {
            if ((index > size + 1) || (index < 1))
            {
                return false;
            }

            var newElement = new ListElement(data, null);
            ++this.size;

            if (index == 1)
            {
                newElement.Next = head;
                this.head = newElement;
                return true;
            }

            ListElement element = FindPrevious(index);

            newElement.Next = element.Next;
            element.Next = newElement;
            return true;
        }

        /// <summary>
        /// The method which shows the word from the position of list.
        /// </summary>
        /// <param name="index"> The index of list from which you want to see the element.</param>
        /// <returns>(smth, false) - if the index wac incorrect
        /// (string, true) - otherwise.</returns>
        public (string answer, bool success) Get(int index)
        {
            (string answer, bool success) result = (null, false);

            if ((index > size) || (index < 1))
            {
                result.success = false;
                return result;
            }

            if (index == 1)
            {
                result.answer = head.Data;
                result.success = true;
                return result;
            }

            result.answer = FindPrevious(index).Next.Data;
            result.success = true;
            return result;
        }

        /// <summary>
        /// The method which replaces a word from the position of list with another element.
        /// </summary>
        /// <param name="index"> The position of list the elemnt from which you want to change.</param>
        /// <param name="data"> The word for replacement.</param>
        /// <returns> true if the word was replaced and false if the position is incorrect.</returns>
        public bool Change(int index, string data)
        {
            if ((index > size) || (index < 1))
            {
                return false;
            }

            if (index == 1)
            {
                head.Data = data;
                return true;
            }

            FindPrevious(index).Next.Data = data;
            return true;
        }

        /// <summary>
        /// The method which returns all the words from list.
        /// </summary>
        /// <returns> the array of strings with list`s words.</returns>
        public string[] GetAll()
        {
            var outputList = new string[size];
            for (int i = 1; i <= size; ++i)
            {
                outputList[i - 1] = this.Get(i).answer;
            }
            return outputList;
        }

        /// <summary>
        /// The method which deletes a word from the position of list.
        /// </summary>
        /// <param name="index"> The position of list from which you want to delete a word.</param>
        /// <returns></returns>
        public bool Delete(int index)
        {
            if ((index > size) || (index < 1))
            {
                return false;
            }

            --this.size;

            if (index == 1)
            {
                this.head = head.Next;
                return true;
            }

            ListElement element = FindPrevious(index);
            element.Next = element.Next.Next;
            return true;
        }

        /// <summary>
        /// The method which deletes all word from list.
        /// </summary>
        /// <returns> false if list wasn`t empty and true otherwise.</returns>
        public bool DeleteAll()
        {
            if (IsEmpty)
            {
                return false;
            }

            this.head = null;
            this.size = 0;
            return true;
        }
    }
}
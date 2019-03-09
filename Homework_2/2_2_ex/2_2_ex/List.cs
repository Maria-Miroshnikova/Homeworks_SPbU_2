using System;

namespace HashTableNameSpace
{
    class List
    {
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

        public string[] GetAll()
        {
            var outputList = new string[size];
            for (int i = 1; i <= size; ++i)
            {
                outputList[i - 1] = this.Get(i).answer;
            }
            return outputList;
        }

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
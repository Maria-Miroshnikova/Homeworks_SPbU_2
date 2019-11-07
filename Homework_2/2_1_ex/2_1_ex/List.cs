using System;

namespace ListNamespace
{
    class List
    {
        private class ListElement
        {
            public ListElement(int data, ListElement next)
            {
                this.Data = data;
                this.Next = next;
            }

            public int Data { get; set; }
            public ListElement Next { get; set; }
        }

        public List()
        {
            this.head = null;
            this.size = 0;
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

        public bool Add(int index, int data)
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

        public (int answer, bool success) Get(int index)
        {
            (int answer, bool success) result = (0, false);

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

        public bool Change(int index, int data)
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

        public int[] GetAll()
        {
            var outputList = new int[size];
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
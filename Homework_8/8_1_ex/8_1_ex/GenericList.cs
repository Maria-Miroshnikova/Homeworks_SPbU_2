using System;
using System.Collections;
using System.Collections.Generic;

namespace ListNameSpace
{
    /// <summary>
    /// Class List (with index, starts from 0), made of ListsElements (inner class);
    /// </summary>
    public class GenericList<T> : IList<T>
    {
        /// <summary>
        ///  class ListElement;
        /// </summary>
        protected class ListElement
        {
            public ListElement(T data, ListElement next)
            {
                this.Data = data;
                this.Next = next;
            }

            public T Data { get; set; }
            public ListElement Next { get; set; }
        }

        private ListElement head;
        private ListElement tail;

        /// <summary>
        /// This property returns if the list is empty;
        /// </summary>
        public bool IsEmpty => head == null;
    
        /// <summary>
        /// This property returns the count of elements in the list;
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// %his property shows that we can get and set elements to (from) list; 
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Access to element of the list by the index;
        /// </summary>
        public T this[int index]
        {
            get
            {
                if ((index > Count - 1) || (index < 0))
                {
                    throw new IndexOutOfListException();
                }

                if (index == 0)
                {
                    return head.Data;
                }

                return FindPrevious(index).Next.Data;
            }

            set
            {
                if ((index > Count - 1) || (index < 0))
                {
                    throw new IndexOutOfListException();
                }

                if (index == 0)
                {
                    head.Data = value;
                    return;
                }

                FindPrevious(index).Next.Data = value;
            }
        }
        
        private ListElement FindPrevious(int index)
        {
            int i = 0;
            ListElement element = head;
            while (i < index - 1)
            {
                element = element.Next;
                ++i;
            }
            return element;
        }

        /// <summary>
        /// The method which find the element in list;
        /// </summary>
        /// <param name="data"> The element which you want to find </param>
        /// <returns> the index of the element in list or -1 if it doesn`t present.</returns>
        public int IndexOf(T data)
        {
            int i = 0;
            foreach (T element in this)
            {
                if (element.Equals(data))
                {
                    return i;
                }
                ++i;
            }

            return -1;
        }

        /// <summary>
        /// The method which checks if the element presents in list;
        /// </summary>
        /// <param name="data"> The element which presence you want to check.</param>
        public bool Contains(T data)
        {
            foreach (T element in this)
            {
                if (element.Equals(data))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method adds element to the end of the list;
        /// </summary>
        public void Add(T data)
        {
            var newElement = new ListElement(data, null);
            ++Count;

            if (IsEmpty)
            {
                head = newElement;
                tail = head;
                return;
            }

            tail.Next = newElement;
            tail = newElement;
        }

        /// <summary>
        /// This method inserts new element to the position of the list; 
        /// </summary>
        public void Insert(int index, T data)
        {
            if ((index > Count - 1) || (index < 0))
            {
                throw new IndexOutOfListException();
            }

            var newElement = new ListElement(data, null);
            ++Count;

            if (index == 0)
            {
                newElement.Next = head;
                this.head = newElement;
                return;
            }

            ListElement element = FindPrevious(index);

            newElement.Next = element.Next;
            element.Next = newElement;
        }

        /// <summary>
        /// The method which returns all the elements from list in array;
        /// </summary>
        public void CopyTo(T[] outputList, int index)
        {
            if ((index > Count - 1) || (index < 0))
            {
                throw new IndexOutOfListException();
            }

            for (int i = 0; i < Count - index; ++i)
            {
                outputList[i] = this[i + index];
            }
        }

        /// <summary>
        /// The method which deletes the element from the list;
        /// </summary>
        /// <param name="data"> The element which you want to delete from the list.</param>
        public bool Remove(T data)
        {
            int index = IndexOf(data);
            if (index == -1)
            {
                return false;
            }

            if (index == 0)
            {
                if (tail == head)
                {
                    tail = null;
                }

                head = head.Next;
            }
            else
            {
                var element = FindPrevious(index);
                element.Next = element.Next.Next;

                if (index == Count - 1)
                {
                    tail = element;
                }
            }

            --Count;

            return true;
        }

        /// <summary>
        /// This method deletes element from the position of the list;
        /// </summary>
        public void RemoveAt(int index)
        {
            if ((index > Count - 1) || (index < 0))
            {
                throw new IndexOutOfListException();
            }

            if (index == 0)
            {
                if (tail == head)
                {
                    tail = null;
                }

                head = head.Next;

                --Count;

                return;
            }

            ListElement element = FindPrevious(index);
            element.Next = element.Next.Next;

            if (index == Count - 1)
            {
                tail = element;
            }

            --Count;
        }

        /// <summary>
        /// The method which deletes all elements from list;
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        /// <summary>
        /// Enumerator for GerericList;
        /// </summary>
        private class ListEnumerator : IEnumerator<T>
        {
            private GenericList<T> list;
            private ListElement currentElement;

            public ListEnumerator(GenericList<T> list)
            {
                this.list = list;
            }

            /// <summary>
            /// This property returns value of current element of the list or allows to set the value of this element; 
            /// </summary>
            public T Current
            {
                get
                {
                    return currentElement.Data;
                }
                set
                {
                    currentElement.Data = value;
                }
            }

            /// <summary>
            /// Vestiges of the past
            /// </summary>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// This method moves to next element of the list, returning true, or returns false, if current element is the last; 
            /// </summary>
            public bool MoveNext()
            {
                if (currentElement == null)
                {
                    currentElement = list.head;
                    return true;
                }

                if (currentElement.Next == null)
                {
                    return false;
                }
                else
                {
                    currentElement = currentElement.Next;
                }

                return true;
            }

            /// <summary>
            /// This method moves current element to the pre-start of the list;
            /// </summary>
            public void Reset()
            {
                currentElement = null;
            }

            /// <summary>
            /// Destructor 
            /// </summary>
            public void Dispose()
            {
            }
        }

        public IEnumerator<T> GetEnumerator() => new ListEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => new ListEnumerator(this);
    }
}

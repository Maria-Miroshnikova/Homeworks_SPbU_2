using System;

namespace QueueNamespace
{
    /// <summary>
    ///  class Queue (of ints with priorities), made of QueueElements (inner class).
    /// </summary>
    public class Queue
    {
        /// <summary>
        ///  class QueueElement (of ints with priority).
        /// </summary>
        private class QueueElement
        {
            public int Data { get; set; }
            public int Priority { get; set; }
            public QueueElement Next { get; set; }

            public QueueElement(int data, int priority, QueueElement next)
            {
                this.Data = data;
                this.Priority = priority;
                this.Next = next;
            }

        }

        private QueueElement head;
        private int size;

        public Queue()
        {
            this.head = null;
            this.size = 0;
        }

        public bool IsEmpty()
        {
            return (head == null);
        }

        public int Size()
        {
            return size;
        }

        /// <summary>
        /// The method which finds the previous element in queue by priority.
        /// </summary>
        private QueueElement FindPrevious(int priority)
        {
            QueueElement element = head;
            while ((element.Next != null) && (element.Next.Priority <= priority))
            {
                element = element.Next;
            }

            return element;
        }

        /// <summary>
        /// The method which adds element to the queue with priority.
        /// </summary>
        public bool Enqueue(int priority, int data)
        {
            if (priority < 0)
            {
                return false;
            }

            var newElement = new QueueElement(data, priority, null);
            ++this.size;

            if ((IsEmpty()) || (priority < head.Priority))
            {
                newElement.Next = head;
                this.head = newElement;
                return true;
            }

            QueueElement element = FindPrevious(priority);

            newElement.Next = element.Next;
            element.Next = newElement;
            return true;
        }

        /// <summary>
        /// The method which returns data of element with highst priority and deletes him from queue.
        /// </summary>
        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException();
            }

            QueueElement elementPrev = null;
            QueueElement element = head;
            
            while (element.Next != null)
            {
                elementPrev = element;
                element = element.Next;
            }

            int result = element.Data;
            
            if (elementPrev == null)
            {
                head = null;
            }
            else
            {
                elementPrev.Next = null;
            }
            
            --size;

            return result;
        }

        /// <summary>
        /// The method which deletes all elements from queue.
        /// </summary>
        public bool DeleteAll()
        {
            if (IsEmpty())
            {
                return false;
            }

            while (!IsEmpty())
            {
                Dequeue();
            }

            return true;
        }
    }
}
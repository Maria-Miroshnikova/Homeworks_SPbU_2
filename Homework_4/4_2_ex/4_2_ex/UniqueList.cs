using System;

namespace UniqueListNameSpace
{
    /// <summary>
    /// Class UniqueList (of strings without the same elements, with index), based on ListElement (inner class).
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// The method which adds the word to the position of list and throws exception if the word already exists in the list.
        /// </summary>
        /// <param name="index"> The position of list to which you want to add the element.</param>
        /// <param name="data"> The word which you want to add to the position of list.</param>
        /// <returns> true if the word was added and false if the position was incorrect</returns>
        public new bool Add(int index, string data)
        {
            if ((index > size + 1) || (index < 1))
            {
                return false;
            }

            if (Exist(data))
            {
                throw new AddExistElementException();
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
        /// The method which deletes the word from the list and throws exception if the word doesn`t exist in the list.
        /// </summary>
        /// <param name="data"> The word which you want to delete from the list.</param>
        public new void Delete(string data)
        {
            int index = Find(data);
            if (index == 0)
            {
                throw new DeleteNotExistElementException();
            }

            if (index == 1)
            {
                head = head.Next;
            }
            else
            {
                var element = FindPrevious(index);
                element.Next = element.Next.Next;
            }
            --this.size;
        }
    }
}

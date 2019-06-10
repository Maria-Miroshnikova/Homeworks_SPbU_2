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
        public override bool Add(int index, string data)
        {
            if (Exist(data))
            {
                throw new AddExistElementException();
            }

            return base.Add(index, data);
        }

        /// <summary>
        /// The method which deletes the word from the list and throws exception if the word doesn`t exist in the list.
        /// </summary>
        /// <param name="data"> The word which you want to delete from the list.</param>
        public override void Delete(string data)
        {
            int index = Find(data);
            if (index == 0)
            {
                throw new DeleteNotExistElementException();
            }

            base.Delete(data);
        }

        /// <summary>
        /// The method which replaces a word from the position of list with another element.
        /// It throws exception if the word for replacement already exists in the list.
        /// </summary>
        /// <param name="index"> The position of list the elemnt from which you want to change.</param>
        /// <param name="data"> The word for replacement.</param>
        /// <returns> true if the word was replaced and false if the position is incorrect.</returns>
        public override bool Change(int index, string data)
        {
            if (Exist(data) && (Find(data) != index))
            {
                throw new AddExistElementException();
            }

            return base.Change(index, data);
        }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _8_2_ex
{
    /// <summary>
    /// This class presents the generis set (AVL-tree), made of SetElements (inner class).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericSet<T> : ISet<T>
    {
        /// <summary>
        /// This class presents the elements of set.
        /// </summary>
        private class SetElement
        {
            public SetElement LeftChild { get; set; }
            public SetElement RightChild { get; set; }

            public T Data { get; set; }

            public SetElement(T data)
            {
                this.Data = data;
            }
        }

        private IComparer<T> comparer;
        private SetElement head;

        public GenericSet(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// This property returns true if the set is empty and false otherwise.
        /// </summary>
        public bool IsEmpty => head == null;

        /// <summary>
        /// This property returns the count of elements in the set.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// This property returns if the set is read only;
        /// </summary>
        public bool IsReadOnly => false;

        private void FindElementByIndex(ref int currentIndex, int findIndex, ref SetElement result, SetElement currentElement)
        {
            if (currentElement.LeftChild != null)
            {
                FindElementByIndex(ref currentIndex, findIndex, ref result, currentElement.LeftChild);
            }

            if (currentIndex > findIndex)
            {
                return;
            }

            if (currentIndex == findIndex)
            {
                result = currentElement;
            }

            ++currentIndex;

            if (currentElement.RightChild != null)
            {
                FindElementByIndex(ref currentIndex, findIndex, ref result, currentElement.RightChild);
            }
        }

        private T this[int index]
        {
            get
            {
                if ((index < 0) || (index >= Count))
                {
                    throw new IndexOutOfSetException();
                }

                SetElement result = null;
                int position = 0;
                FindElementByIndex(ref position, index, ref result, head);

                return result.Data;
            }
        }

        /// <summary>
        /// This method checks if the set contains given element.
        /// </summary>
        public bool Contains(T data)
        {
            if (IsEmpty)
            {
                return false;
            }

            var currentElement = head;

            while (true)
            {
                if (comparer.Compare(currentElement.Data, data) > 0)
                {
                    if (currentElement.LeftChild == null)
                    {
                        return false;
                    }
                    else
                    {
                        currentElement = currentElement.LeftChild;
                    }
                }
                else if (comparer.Compare(currentElement.Data, data) <0)
                {
                    if (currentElement.RightChild == null)
                    {
                        return false;
                    }
                    else
                    {
                        currentElement = currentElement.RightChild;
                    }
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// This method adds the unique element to the set
        /// (and returns false if the set contains this element already).
        /// </summary>
        public bool Add(T data)
        {
            if (IsEmpty)
            {
                head = new SetElement(data);
                ++Count;
                return true;
            }

            if (Contains(data))
            {
                return false;
            }

            var newElement = new SetElement(data);
            var currentElement = head;

            while (true)
            {
                if (comparer.Compare(currentElement.Data, data) > 0)
                {
                    if (currentElement.LeftChild == null)
                    {
                        currentElement.LeftChild = newElement;
                        ++Count;
                        return true;
                    }
                    else
                    {
                        currentElement = currentElement.LeftChild;
                    }
                }
                else
                {
                    if (currentElement.RightChild == null)
                    {
                        currentElement.RightChild = newElement;
                        ++Count;
                        return true;
                    }
                    else
                    {
                        currentElement = currentElement.RightChild;
                    }
                }
            }
        }

        /// <summary>
        /// Don`t know what is it???
        /// </summary>
        /// <param name="data"></param>
        void ICollection<T>.Add(T data)
        {
            Add(data);
        }

        private void DFS(SetElement currentElement, T[] outputArray, ref int indexOutput)
        {
            if (currentElement == null)
            {
                return;
            }

            DFS(currentElement.LeftChild, outputArray, ref indexOutput);

            outputArray[indexOutput] = currentElement.Data;
            ++indexOutput;

            DFS(currentElement.RightChild, outputArray, ref indexOutput);
        }

        /// <summary>
        /// This method copies all elements of the set to the given array in ascending order.
        /// </summary>
        public void CopyTo(T[] outputArray, int indexOutput)
        {            
            if (IsEmpty)
            {
                return;
            }

            int indexCopy = indexOutput;

            DFS(head, outputArray, ref indexOutput);
        }

        private void DeleteSimpleCase(SetElement element, SetElement elementParent)
        {
            bool isLeftChild;
            if (elementParent.LeftChild == element)
            {
                isLeftChild = true;
            }
            else
            {
                isLeftChild = false;
            }

            if (elementParent == null)
            {
                head = null;  //  удаление корня
            }

            if ((element.LeftChild == null) && (element.RightChild == null)) // удаление листа
            {
                if (isLeftChild)
                {
                    elementParent.LeftChild = null;
                }
                else
                {
                    elementParent.RightChild = null;
                }
            }

            else if ((element.LeftChild == null) || (element.RightChild == null)) // удаление элемента с одним сыном
            {
                if (element.LeftChild == null)
                {
                    if (isLeftChild)
                    {
                        elementParent.LeftChild = element.RightChild;
                    }
                    else
                    {
                        elementParent.RightChild = element.RightChild;
                    }
                }
                else
                {
                    if (isLeftChild)
                    {
                        elementParent.LeftChild = element.LeftChild;
                    }
                    else
                    {
                        elementParent.RightChild = element.LeftChild;
                    }
                }
            }
        }

        private SetElement FindReplacement(SetElement element)
        {
            if (element.RightChild != null)
            {
                return FindReplacement(element.RightChild);
            }
            return element;
        }

        private SetElement FindParentForExistElement(SetElement element)
        {
            if (element == head)
            {
                return null;
            }

            var currentElement = head;
            while (true)
            {
                if ((comparer.Compare(currentElement.Data, element.Data) > 0))
                {
                    if (currentElement.LeftChild == element)
                    {
                        return currentElement;
                    }
                    currentElement = currentElement.LeftChild; 
                }
                else
                {
                    if (currentElement.RightChild == element)
                    {
                        return currentElement;
                    }
                    currentElement = currentElement.RightChild;
                }
            }
        }

        private bool DeleteElement(SetElement currentElement, T data)
        {
            if (currentElement == null)
            {
                return false;
            }
            else if (comparer.Compare(currentElement.Data, data) == 0)
            {
                if ((currentElement.LeftChild != null) && (currentElement.RightChild != null)) // удаление элемента с двумя сыновьями
                {
                    var replacement = FindReplacement(currentElement.LeftChild);
                    var replacementParent = FindParentForExistElement(replacement);

                    currentElement.Data = replacement.Data; // копирует значение заменителя в удаляемый элемент
                    DeleteSimpleCase(replacement, replacementParent);      // удаляет заменитель
                }
                else
                {
                    DeleteSimpleCase(currentElement, FindParentForExistElement(currentElement));
                }
                return true;
            }
            else if (comparer.Compare(currentElement.Data, data) < 0)
            {
                return DeleteElement(currentElement.RightChild, data);
            }
            else
            {
                return DeleteElement(currentElement.LeftChild, data);
            }
        }

        /// <summary>
        /// This method deletes the element from the set.
        /// </summary>
        public bool Remove(T data)
        {
            if (IsEmpty)
            {
                return false;
            }

            if (DeleteElement(head, data))
            {
                --Count;
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method deletes all elements from the set.
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// This method adds all elements of given set to the set.
        /// </summary>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach(T element in other)
            {
                if (!Contains(element))
                {
                    Add(element);
                }
            }
        }

        /// <summary>
        /// This method deletes elements of the set, which are not contained in given set, from the set. 
        /// </summary>
        /// <param name="other"></param>
        public void IntersectWith(IEnumerable<T> other)
        {
            var setElements = new T[Count];
            CopyTo(setElements, 0);

            foreach(T element in setElements)
            {
                if (!other.Contains(element))
                {
                    Remove(element);
                }
            }
        }

        /// <summary>
        /// This method deletes elements of the set, which are contained in given set, from the set.
        /// </summary>
        /// <param name="other"></param>
        public void ExceptWith(IEnumerable<T> other)
        {
            foreach(T element in other)
            {
                Remove(element);
            }
        }

        /// <summary>
        /// This method adds elements from given set, which are not contained in the set, to the set
        /// and deleted elements, which are contained in both sets, from the set.
        /// </summary>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            foreach(T element in other)
            {
                if (Contains(element))
                {
                    Remove(element);
                }
                else
                {
                    Add(element);
                }
            }
        }

        /// <summary>
        /// This method checks if the set is subset of given set.
        /// </summary>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            foreach (T element in this)
            {
                if (!other.Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This method checks if given set is subset of the set.
        /// </summary>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            foreach (T element in other)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This method checks if given set is proper subset of the set.
        /// </summary>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return (IsSupersetOf(other)) && (Count > other.Count());
        }

        /// <summary>
        /// This method checks if the set is proper subset of given set.
        /// </summary>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return (IsSubsetOf(other)) && (Count < other.Count());
        }

        /// <summary>
        /// This method cheks if there is elements in sets, which are contained in both sets.
        /// </summary>
        public bool Overlaps(IEnumerable<T> other)
        {
            foreach(T element in other)
            {
                if (Contains(element))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// This method cheks if the set and given set are equal.
        /// </summary>
        public bool SetEquals(IEnumerable<T> other)
        {
            return (IsSubsetOf(other)) && (Count == other.Count());
        }

        // <summary>
        /// Lets use foreach with the GenericSet
        /// </summary>
        public IEnumerator<T> GetEnumerator() => new SetEnumerator<T>(this);

        // <summary>
        /// Lets use foreach with the GenericSet
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => new SetEnumerator<T>(this);

        /// <summary>
        /// The enumerator for GenerisSet
        /// </summary>
        private class SetEnumerator<T> : IEnumerator<T>
        {
            private GenericSet<T> set;

            private int position = -1;

            public SetEnumerator(GenericSet<T> set)
            {
                this.set = set;
            }

            /// <summary>
            /// Current element
            /// </summary>
            public T Current
            {
                get
                {
                    if ((position < 0) || (position >= set.Count))
                    {
                        throw new IndexOutOfRangeException();
                    }

                    return set[position];
                }
            }

            /// <summary>
            /// Make step to next element
            /// </summary>
            public bool MoveNext()
            {
                if ((position >= set.Count - 1))
                {
                    return false;
                }

                ++position;
                return true;
            }

            /// <summary>
            /// Returns to the pre-beginning of set
            /// </summary>
            public void Reset() => position = -1;

            /// <summary>
            /// Need to be here
            /// </summary>
            public void Dispose()
            {
            }

            /// <summary>
            /// Need to be here
            /// </summary>
            object IEnumerator.Current => throw new NotImplementedException();
        }

    }
}
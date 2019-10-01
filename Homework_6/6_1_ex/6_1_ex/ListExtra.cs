using System;
using System.Collections.Generic;

namespace _6_1_ex
{
    /// <summary>
    /// Includes some spesial static methods to transformate the list;
    /// </summary>
    public class ListExtra
    {
        /// <summary>
        /// Returns the list of transformated with the function elements of the list;
        /// </summary>
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            if ((list == null) || (function == null))
            {
                throw new MyVeryOwnNullArgumentException();
            }

            var resultList = new List<int>();
            for(int i = 0; i < list.Count; ++i)
            {
                resultList.Add(function(list[i]));
            }
            return resultList;
        }

        /// <summary>
        /// Returns the list of elements wich were accepted by the function;
        /// </summary>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            if ((list == null) || (function == null))
            {
                throw new MyVeryOwnNullArgumentException();
            }

            var resultList = new List<int>();
            foreach (int element in list)
            {
                if (function(element))
                {
                    resultList.Add(element);
                }
            }
            return resultList;
        }

        /// <summary>
        /// Returns the value of accumulator;
        /// </summary>
        public static int Fold(List<int> list, int accumulatorStart, Func<(int accumulator, int element),int> function)
        {
            if ((list == null) || (function == null))
            {
                throw new MyVeryOwnNullArgumentException();
            }

            int accumulator = accumulatorStart;
            foreach (int element in list)
            {
                accumulator = function((accumulator, element));
            }
            return accumulator;
        }
    }
}

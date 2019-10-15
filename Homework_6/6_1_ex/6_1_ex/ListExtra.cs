using System;
using System.Collections.Generic;

namespace _6_1_ex
{
    /// <summary>
    /// Includes some spesial static methods to transform the list;
    /// </summary>
    public class ListExtra 
    {
        /// <summary>
        /// Returns the list of transformated with the function elements of the list;
        /// </summary>
        public static List<T2> Map<T1, T2>(List<T1> list, Func<T1, T2> function)
        {
            if ((list == null) || (function == null))
            {
                throw new ArgumentNullException();
            }

            var resultList = new List<T2>();
            for (int i = 0; i < list.Count; ++i)
            {
                resultList.Add(function(list[i]));
            }
            return resultList;
        }

        /// <summary>
        /// Returns the list of elements wich were accepted by the function;
        /// </summary>
        public static List<T> Filter<T>(List<T> list, Func<T, bool> function)
        {
            if ((list == null) || (function == null))
            {
                throw new ArgumentNullException();
            }

            var resultList = new List<T>();
            foreach (T element in list)
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
        public static T2 Fold<T1, T2>(List<T1> list, T2 accumulatorStart, Func<(T2 accumulator, T1 element), T2> function)
        {
            if ((list == null) || (function == null))
            {
                throw new ArgumentNullException();
            }

            T2 accumulator = accumulatorStart;
            foreach (T1 element in list)
            {
                accumulator = function((accumulator, element));
            }
            return accumulator;
        }
    }
}

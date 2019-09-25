using System;
using System.Collections.Generic;

namespace _8_2_ex
{
    /// <summary>
    /// This class presents the comoparer for integers.
    /// </summary>
    public class ComparerInt : IComparer<int>
    {
        /// <summary>
        /// This method compares two ints.
        /// </summary>
        public int Compare(int first, int second)
        {
            if (first > second)
            {
                return 1;
            }
            else if (first < second)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace test_2_2
{
    public class BubbleSort<T>
    {
        public List<T> list;
        public Comparer comparer;

        public delegate bool Comparer(T firstElement, T secondElement);

        public List<T> MySort()
        {
            for (int i = 0; i < list.Count - 1; ++i)
            {
                for (int j = 0; j < list.Count - 1; ++j)
                {
                    if (comparer(list[j], list[j + 1]))
                    {
                        T tmp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = tmp;
                    }
                }
            }
            return list;
        }
    }
}

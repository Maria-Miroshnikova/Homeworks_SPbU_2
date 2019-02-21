using System;

namespace SortArray
{
    class Program
    {
        static int Middle(int[] sortArray, int firstIndex, int secondIndex, int thirdIndex)
        {
            if ((sortArray[secondIndex] > sortArray[firstIndex]) && (sortArray[secondIndex] < sortArray[thirdIndex]))
            {
                return secondIndex;
            }
            if ((sortArray[firstIndex] > sortArray[secondIndex]) && (sortArray[firstIndex] < sortArray[thirdIndex]))
            {
                return firstIndex;
            }
            return thirdIndex;
        }

        static int MedianElement(int[] sortArray, int left, int right)
        {
            int sameElementsDetect = 0;
            int sameElementsFix = 0;
            int firstIndex = left;
            int firstElement = sortArray[firstIndex];
            int lastIndex = right;
            int lastElement = sortArray[lastIndex];
            if (lastElement == firstElement)
            {
                ++sameElementsDetect;
                for (int i = right - 1; i > left; --i)
                {
                    if (sortArray[i] != firstElement)
                    {
                        lastElement = sortArray[i];
                        lastIndex = i;
                        ++sameElementsFix;
                        break;
                    }
                }
            }
            int middleIndex = left + 1;
            int middleElement = sortArray[middleIndex];
            if ((middleElement == lastElement) || (middleElement == firstElement))
            {
                ++sameElementsDetect;
                for (int i = middleIndex; i < right; ++i)
                {
                    if ((sortArray[i] != firstElement) && (sortArray[i] != lastElement))
                    {
                        middleElement = sortArray[i];
                        middleIndex = i;
                        ++sameElementsFix;
                        break;
                    }
                }
            }
            if ((sameElementsDetect > 0) && (sameElementsFix != sameElementsDetect))
            {
                if (sameElementsDetect - sameElementsFix == 1)
                {
                    return -2;
                }
                return -1;
            }
            return Middle(sortArray, firstIndex, lastIndex, middleIndex);
        }

        static void Swap(int[] array, int index1, int index2)
        {
            int tmp = array[index1];
            array[index1] = array[index2];
            array[index2] = tmp;
        }

        static void InsertionSort(int[] sortArray, int left, int rigth)
        {
            for (int i = left + 1; i <= rigth; ++i)
            {
                int sortElement = sortArray[i];
                int index = i;
                for (int j = index - 1; j >= left; --j)
                {
                    if (sortArray[j] <= sortElement)
                    {
                        break;
                    }
                    else
                    {
                        Swap(sortArray, j, index);
                        --index;
                    }
                }
            }
        }

        static void QuickSort(int[] sortArray, int left, int right)
        {
            int length = right - left + 1;
            if (length < 10)
            {
                InsertionSort(sortArray, left, right);
                return;
            }
            int supportElementIndex = MedianElement(sortArray, left, right);
            if (supportElementIndex >= 0)
            {
                int supportElement = sortArray[supportElementIndex];
                int indexLeft = left;
                int indexRight = right;
                while (indexLeft < indexRight)
                {
                    while ((sortArray[indexLeft] <= supportElement) && (indexLeft < indexRight))
                    {
                        ++indexLeft;
                    }
                    while ((sortArray[indexRight] > supportElement) && (indexLeft < indexRight))
                    {
                        --indexRight;
                    }
                    Swap(sortArray, indexLeft, indexRight);
                }
                int left1 = left;
                int right1 = indexLeft - 1;
                int left2 = indexLeft;
                int right2 = right;
                QuickSort(sortArray, left1, right1);
                QuickSort(sortArray, left2, right2);
            }
            else
            {
                InsertionSort(sortArray, left, right);
            }
        }

        static void OutputArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }
        }

        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            int lengthArray = randomNumber.Next(1, 100);
            int[] array = new int[lengthArray];
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = randomNumber.Next(-10, 10);
            }

            Console.WriteLine("The array is:");
            OutputArray(array);

            QuickSort(array, 0, array.Length - 1);

            Console.WriteLine("\n Sorted array is:");
            OutputArray(array);

            Console.ReadLine();
      
        }
    }
}

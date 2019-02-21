using System;

namespace SortMatrix
{
    class Program
    {
        static int Middle(int[ , ] sortMatrix, int firstIndex, int secondIndex, int thirdIndex, int supportLineIndex)
        {
            if ((sortMatrix[supportLineIndex, secondIndex] > sortMatrix[supportLineIndex, firstIndex]) && (sortMatrix[supportLineIndex, secondIndex] < sortMatrix[supportLineIndex, thirdIndex]))
            {
                return secondIndex;
            }
            if ((sortMatrix[supportLineIndex, firstIndex] > sortMatrix[supportLineIndex, secondIndex]) && (sortMatrix[supportLineIndex, firstIndex] < sortMatrix[supportLineIndex, thirdIndex]))
            {
                return firstIndex;
            }
            return thirdIndex;
        }

        static int MedianElement(int[ , ] sortMatrix, int left, int right, int supportLineIndex)
        {
            int sameElementsDetect = 0;
            int sameElementsFix = 0;
            int firstIndex = left;
            int firstElement = sortMatrix[supportLineIndex, firstIndex];
            int lastIndex = right;
            int lastElement = sortMatrix[supportLineIndex, lastIndex];
            if (lastElement == firstElement)
            {
                ++sameElementsDetect;
                for (int j = right - 1; j > left; --j)
                {
                    if (sortMatrix[supportLineIndex, j] != firstElement)
                    {
                        lastElement = sortMatrix[supportLineIndex, j];
                        lastIndex = j;
                        ++sameElementsFix;
                        break;
                    }
                }
            }
            int middleIndex = left + 1;
            int middleElement = sortMatrix[supportLineIndex, middleIndex];
            if ((middleElement == lastElement) || (middleElement == firstElement))
            {
                ++sameElementsDetect;
                for (int j = middleIndex; j < right; ++j)
                {
                    if ((sortMatrix[supportLineIndex, j] != firstElement) && (sortMatrix[supportLineIndex, j] != lastElement))
                    {
                        middleElement = sortMatrix[supportLineIndex, j];
                        middleIndex = j;
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
            return Middle(sortMatrix, firstIndex, lastIndex, middleIndex, supportLineIndex);
        }

        static void SwapColumns(int[ , ] matrix, int index1, int index2)
        {
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                int tmp = matrix[i, index1];
                matrix[i, index1] = matrix[i, index2];
                matrix[i, index2] = tmp;
            }
        }

        static void InsertionSort(int[ , ] sortMatrix, int left, int rigth, int supportLineIndex)
        {
            for (int j = left + 1; j <= rigth; ++j)
            {
                int sortElement = sortMatrix[supportLineIndex, j];
                int index = j;
                for (int k = index - 1; k >= left; --k)
                {
                    if (sortMatrix[supportLineIndex, k] <= sortElement)
                    {
                        break;
                    }
                    else
                    {
                        SwapColumns(sortMatrix, k, index);
                        --index;
                    }
                }
            }
        }

        static void QuickSortMatrixColumn(int[ , ] sortMatrix, int left, int right, int supportLineIndex)
        {
            int length = right - left + 1;
            if (length < 10)
            {
                InsertionSort(sortMatrix, left, right, supportLineIndex);
                return;
            }
            int supportElementIndex = MedianElement(sortMatrix, left, right, supportLineIndex);
            if (supportElementIndex >= 0)
            {
                int supportElement = sortMatrix[supportLineIndex, supportElementIndex];
                int indexLeft = left;
                int indexRight = right;
                while (indexLeft < indexRight)
                {
                    while ((sortMatrix[supportLineIndex, indexLeft] <= supportElement) && (indexLeft < indexRight))
                    {
                        ++indexLeft;
                    }
                    while ((sortMatrix[supportLineIndex, indexRight] > supportElement) && (indexLeft < indexRight))
                    {
                        --indexRight;
                    }
                    SwapColumns(sortMatrix, indexLeft, indexRight);
                }
                int left1 = left;
                int right1 = indexLeft - 1;
                int left2 = indexLeft;
                int right2 = right;
                QuickSortMatrixColumn(sortMatrix, left2, right2, supportLineIndex);
                QuickSortMatrixColumn(sortMatrix, left1, right1, supportLineIndex);
            }
            else
            {
                InsertionSort(sortMatrix, left, right, supportLineIndex);
            }
        }

        static void OutputMatrix(int[,] matrix)
        {
            Console.Write("\n");

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.Write("\n");
            }

            Console.Write("\n");
        }

        static int[,] MakeRandomMatrix()
        {
            Random randomNumber = new Random();
            int iLenMatrix = randomNumber.Next(1, 15);
            int jLenMatrix = randomNumber.Next(1, 15);
            int[,] matrix = new int[iLenMatrix, jLenMatrix];

            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = randomNumber.Next(0, 9);
                }
            }
            return matrix;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The matrix is:");

            int[ , ] matrix = MakeRandomMatrix();
            OutputMatrix(matrix);

            int supportLineIndex = 0;

            QuickSortMatrixColumn(matrix, 0, matrix.GetLength(1) - 1, supportLineIndex);

            Console.WriteLine("Now sorted matrix is:");
            OutputMatrix(matrix);
        }
    }
}

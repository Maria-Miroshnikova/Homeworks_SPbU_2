using System;

namespace SpiralArrayWalk
{
    class Program
    {
        static void OutputArrayElement(int[,] array, int i, int j)
        {
            Console.WriteLine($"{array[i, j]} : [{i}, {j}]");
        }

        static void SpiralArrayWalk(int[,] array)
        {
            int center = array.GetLength(0) / 2;
            int i = center;
            int j = center;

            for (int branchSpiral = 1; branchSpiral <= center; ++branchSpiral)
            {
                while (j != center + branchSpiral)
                {
                    OutputArrayElement(array, i, j);
                    ++j;
                }

                while (i != center - branchSpiral)
                {
                    OutputArrayElement(array, i, j);
                    --i;
                }

                while (j != center - branchSpiral)
                {
                    OutputArrayElement(array, i, j);
                    --j;
                }

                while (i != center + branchSpiral)
                {
                    OutputArrayElement(array, i, j);
                    ++i;
                }

                while (j != center + branchSpiral)
                {
                    OutputArrayElement(array, i, j);
                    ++j;
                }
            }

            OutputArrayElement(array, array.GetLength(0) - 1, array.GetLength(0) - 1);
        }

        static void OutputArray(int[,] array)
        {
            Console.Write("\n");

            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.Write("\n");
            }

            Console.Write("\n");
        }

        static int[,] MakeRandomArray(int lengthArray)
        {
            var randomNumber = new Random();
            var array = new int[lengthArray, lengthArray];
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    array[i, j] = randomNumber.Next(0, 9);
                }
            }
            return array;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("This program will output the elements of random array \nin a spiral range from the center.");
            Console.Write("Please, enter the size of array (uneven only): ");

            int lengthArray = Convert.ToInt32(Console.ReadLine());
            if ((lengthArray < 1) || (lengthArray % 2 == 0))
            {
                Console.Write("Wrong data: entered size of array must be uneven! ");
                return;
            }

            int[,] array = MakeRandomArray(lengthArray);

            Console.WriteLine("The array is:");
            OutputArray(array);

            SpiralArrayWalk(array);
        }
    }
}

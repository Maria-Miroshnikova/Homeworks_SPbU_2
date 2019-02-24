using System;

namespace FibonacciNumbers
{
    class Program
    {
        static int FibonacciNumbers(int n)
        {
            int fibonacciOne = 0;
            int fibonacciTwo = 1;
            for (int i = 1; i <= n; ++i)
            {
                int tmp = fibonacciOne;
                fibonacciOne = fibonacciTwo;
                fibonacciTwo += tmp;
            }
            return fibonacciTwo;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("In this program F(0) = 1, F(1) = 1, F(2) = 2, etc.");
            Console.WriteLine("Please, enter the index of Fibonacci number to count:");

            int number = Convert.ToInt32(Console.ReadLine());
            if (number < 0)
            {
                Console.WriteLine("Wrong data!");
                return;
            }

            Console.WriteLine($"The answer is: {FibonacciNumbers(number)}.");
        }
    }
}

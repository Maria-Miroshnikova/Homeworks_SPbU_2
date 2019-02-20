using System;

namespace FibonacciNumbers
{
    class Program
    {
        static int FibonacciNumbers(int n)
        {
            if ((n == 0) || (n == 1))
            {
                return 1;
            }
            else
            {
                return FibonacciNumbers(n - 1) + FibonacciNumbers(n - 2);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("In this program F(0) = 1, F(1) = 1, F(2) = 2, etc.");
            Console.WriteLine("Please, enter the index of Fibonacci number to count:");

            int number = Convert.ToInt32(Console.ReadLine());
            if (number < 0)
            {
                Console.WriteLine("Wrong data!");
            }
            else
            {
                Console.WriteLine($"The answer is: {FibonacciNumbers(number)}.");
            }

            Console.ReadLine();
        }
    }
}

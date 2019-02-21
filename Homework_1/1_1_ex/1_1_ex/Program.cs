using System;

namespace Factorial
{
    class Program
    {
        static int Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please, input the number to count the factorial:");

            int number = Convert.ToInt32(Console.ReadLine());
            if (number < 0)
            {
                Console.WriteLine("Wrong data!");
                return;
            }

            Console.WriteLine($"The answer is: {Factorial(number)}.");
        }
    }
}

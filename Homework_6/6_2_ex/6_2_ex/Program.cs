using System;

namespace _6_2_ex
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Map.txt";

            var game = new Game();
        //     Console.WriteLine("THE GAME STARTED!\npress 'Escape' to exit");
            game.Start(fileName);
        }
    }
}

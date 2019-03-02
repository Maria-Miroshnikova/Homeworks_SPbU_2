using System;
using System.IO;

namespace ListNamespace
{
    class Interface
    {
        static void OutputArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.WriteLine($"{element}");
            }
        }

        static void Help()
        {
            Console.Write("\n");
            using (var helpFile = new StreamReader("HELP.txt"))
            {
                Console.WriteLine(helpFile.ReadToEnd());
            }
        }

        static void GetCommand()
        {
            string[] commands = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "HELP" };

            Help();
            Console.Write("\nPlease, enter the command: ");
            string command = Console.ReadLine();

            string parameter1;
            int parameterInt1 = 0;
            string parameter2;
            int parameterInt2 = 0;

            var list = new List();

            while (command != commands[0])
            {
                if (command == commands[1])
                {
                    Console.Write("Please, enter the number to add: ");
                    parameter1 = Console.ReadLine();
                    if (!Int32.TryParse(parameter1, out parameterInt1))
                    {
                        Console.WriteLine("\nError: incorrect data!");
                    }

                    else
                    {
                        Console.Write("Please, enter the index of list element to add: ");
                        parameter2 = Console.ReadLine();
                        if (!Int32.TryParse(parameter2, out parameterInt2))
                        {
                            Console.WriteLine("\nError: incorrect data!");
                        }
                        else if (!list.Add(parameterInt2, parameterInt1))
                        {
                            Console.WriteLine("\nError: index out of list!");
                        }
                    }
                }

                else if (command == commands[2])
                {
                    Console.Write("Please, enter the index of list element to delete: ");

                    parameter1 = Console.ReadLine();
                    if (!Int32.TryParse(parameter1, out parameterInt1))
                    {
                        Console.WriteLine("\nError: incorrect data!");
                    }
                    else if (!list.Delete(parameterInt1))
                    {
                        Console.WriteLine("\nError: index out of list!");
                    }
                }

                else if (command == commands[3])
                {
                    Console.Write("The size of array is: {0}\n", list.Size);
                }

                else if (command == commands[4])
                {
                    if (list.IsEmpty)
                    {
                        Console.WriteLine("The list is empty!");
                    }
                    else
                    {
                        Console.WriteLine("The list is NOT empty!");
                    }
                }

                else if (command == commands[5])
                {
                    Console.Write("Please, enter the index of list element to output: ");

                    parameter1 = Console.ReadLine();
                    if (!Int32.TryParse(parameter1, out parameterInt1))
                    {
                        Console.WriteLine("\nError: incorrect data!");
                    }

                    else
                    {
                        var result = list.Get(parameterInt1);

                        if (!result.success)
                        {
                            Console.WriteLine("\nError: index out of list!");
                        }
                        else
                        {
                            Console.WriteLine("The {0} elemet is: {1}", parameterInt1, result.answer);
                        }
                    }
                }

                else if (command == commands[6])
                {
                    Console.Write("Please, enter the index of list element to change: ");
                    parameter1 = Console.ReadLine();
                    if (!Int32.TryParse(parameter1, out parameterInt1))
                    {
                        Console.WriteLine("\nError: incorrect data!");
                    }

                    else
                    {
                        Console.Write("Please, enter the number for replacement: ");
                        parameter2 = Console.ReadLine();
                        if (!Int32.TryParse(parameter2, out parameterInt2))
                        {
                            Console.WriteLine("\nError: incorrect data!");
                        }

                        else if (!list.Change(parameterInt1, parameterInt2))
                        {
                            Console.WriteLine("\nError: index out of list!");
                        }
                    }
                }

                else if (command == commands[7])
                {
                    if (list.IsEmpty)
                    {
                        Console.WriteLine("The list is empty!");
                    }
                    else
                    {
                        Console.WriteLine("The list is:\n");
                        OutputArray(list.GetAll());
                    }
                }

                else if (command == commands[8])
                {
                    if (!list.DeleteAll())
                    {
                        Console.WriteLine("\nThe list is already empty!");
                    }
                }

                else if (command == commands[9])
                {
                    Help();
                }

                else
                {
                    Console.WriteLine("\nError: wrong command! Please, enter HELP to see the list of commands!");
                }

                Console.Write("\nPlease, enter the command: ");
                command = Console.ReadLine();
            }

            list.DeleteAll();

        }

        static void Main(string[] args)
        {
            GetCommand();
        }
    }
}

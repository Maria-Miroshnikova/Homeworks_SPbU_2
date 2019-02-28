using System;
using System.IO;

namespace List
{
    struct Answer
    {
        public int answer;
        public bool success;
    }

    class ListElement
    {
        public ListElement(int data, ListElement next)
        {
            this.data = data;
            this.next = next;
        }

        private int data;
        private ListElement next;

        public ListElement GetNext()
        {
            return next;
        }

        public int GetData()
        {
            return data;
        }

        public void ChangeNext(ListElement newNext)
            => this.next = newNext;

        public void ChangeData(int newData)
            => this.data = newData;

    }

    class List
    {
        public List()
        {
            this.head = null;
            this.size = 0;
        }

        private ListElement head;
        private int size;

        public bool IsEmpty()
        {
            return (head == null);
        }

        public int Size()
        {
            return size;
        }

        private ListElement FindPrevious(int index)
        {
            int i = 1;
            ListElement element = head;
            while (i < index - 1)
            {
                element = element.GetNext();
                ++i;
            }
            return element;
        }

        public bool Add(int index, int data)
        {
            if ((index > size + 1) || (index < 1))
            {
                return false;
            }

            var newElement = new ListElement(data, null);
            ++this.size;

            if (index == 1)
            {
                newElement.ChangeNext(head);
                this.head = newElement;
                return true;
            }

            ListElement element = FindPrevious(index);

            newElement.ChangeNext(element.GetNext());
            element.ChangeNext(newElement);
            return true;
        }

        public Answer Get(int index)
        {
            var result = new Answer();

            if ((index > size) || (index < 1))
            {
                result.success = false;
                return result;
            }
            
            if (index == 1)
            {
                result.answer = head.GetData();
                result.success = true;
                return result;
            }

            result.answer = FindPrevious(index).GetNext().GetData();
            result.success = true;
            return result;
        }

        public bool Change(int index, int data)
        {
            if ((index > size) || (index < 1))
            {
                return false;
            }

            if (index == 1)
            {
                head.ChangeData(data);
                return true;
            }

            FindPrevious(index).GetNext().ChangeData(data);
            return true;
        }

        public int[] GetAll()
        {
            var outputList = new int[size];
            for (int i = 1; i <= size; ++i)
            {
                outputList[i - 1] = this.Get(i).answer;
            }
            return outputList;
        }

        public bool Delete(int index)
        {
            if ((index > size) || (index < 1))
            {
                return false;
            }

            --this.size;

            if (index == 1)
            {
                this.head = head.GetNext();
                return true;
            }

            ListElement element = FindPrevious(index);
            element.ChangeNext(element.GetNext().GetNext());
            return true;
        }

        public bool DeleteAll()
        {
            if (IsEmpty())
            {
                return false;
            }

            this.head = null;
            this.size = 0;
            return true;
        }
    }

    class Interface
    {
        static void outputArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.WriteLine($"{element}");
            }
        }

        static void help()
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

            help();
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
                        Console.WriteLine("\nError: incorrect data!");

                    else
                    {
                        Console.Write("Please, enter the index of list element to add: ");
                        parameter2 = Console.ReadLine();
                        if (!Int32.TryParse(parameter2, out parameterInt2))
                            Console.WriteLine("\nError: incorrect data!");
                        else if (!list.Add(parameterInt2, parameterInt1))
                            Console.WriteLine("\nError: index out of list!");
                    }
                }

                else if (command == commands[2])
                {
                    Console.Write("Please, enter the index of list element to delete: ");

                    parameter1 = Console.ReadLine();
                    if (!Int32.TryParse(parameter1, out parameterInt1))
                        Console.WriteLine("\nError: incorrect data!");
                    else if (!list.Delete(parameterInt1))
                        Console.WriteLine("\nError: index out of list!");
                }

                else if (command == commands[3])
                {
                    Console.Write("The size of array is: {0}\n", list.Size());
                }

                else if (command == commands[4])
                {
                    if (list.IsEmpty())
                        Console.WriteLine("The list is empty!");
                    else
                        Console.WriteLine("The list is NOT empty!");
                }

                else if (command == commands[5])
                {
                    Console.Write("Please, enter the index of list element to output: ");

                    parameter1 = Console.ReadLine();
                    if (!Int32.TryParse(parameter1, out parameterInt1))
                        Console.WriteLine("\nError: incorrect data!");

                    else
                    {
                        Answer result = list.Get(parameterInt1);

                        if (!result.success)
                            Console.WriteLine("\nError: index out of list!");
                        else
                            Console.WriteLine("The {0} elemet is: {1}", parameterInt1, result.answer);
                    }
                }

                else if (command == commands[6])
                {
                    Console.Write("Please, enter the index of list element to change: ");
                    parameter1 = Console.ReadLine();
                    if (!Int32.TryParse(parameter1, out parameterInt1))
                        Console.WriteLine("\nError: incorrect data!");

                    else
                    {
                        Console.Write("Please, enter the number for replacement: ");
                        parameter2 = Console.ReadLine();
                        if (!Int32.TryParse(parameter2, out parameterInt2))
                            Console.WriteLine("\nError: incorrect data!");

                        else if (!list.Change(parameterInt1, parameterInt2))
                            Console.WriteLine("\nError: index out of list!");
                    }
                }

                else if (command == commands[7])
                {
                    if (list.IsEmpty())
                        Console.WriteLine("The list is empty!");
                    else
                    {
                        Console.WriteLine("The list is:\n");
                        outputArray(list.GetAll());
                    }
                }

                else if (command == commands[8])
                {
                    if (!list.DeleteAll())
                        Console.WriteLine("\nThe list is already empty!");
                }

                else if (command == commands[9])
                {
                    help();
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

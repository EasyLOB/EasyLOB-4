using System;

namespace EasyLOB
{
    public static partial class ShellHelper
    {
        public static void PersistenceDemo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Persistence Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> Northwind Demo");

                Console.Write("\nChoose an option... ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        PersistenceNorthwindDemo();
                        break;
                }

                if (!exit)
                {
                    Console.Write("\nPress <KEY> to continue... ");
                    Console.ReadKey();
                }
            }
        }
    }
}
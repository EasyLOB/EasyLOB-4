using AutoMapper;
using System;
using System.IO;

namespace EasyLOB
{
    public static partial class ShellHelper
    {
        public static void AutoMapperDemo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("AutoMapper Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> MyLOB DTO -> Data -> DTO");
                Console.WriteLine("<2> EasyLOB Export");

                Console.Write("\nChoose an option... ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        AutoMapperMyLOBDemo();
                        break;

                    case ('2'):
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                            "AutoMapper.txt");

                        Console.WriteLine("\nAutoMapper EasyLOB Export: {0}", filePath);

                        using (StreamWriter stream = new StreamWriter(filePath))
                        {
                            TypeMap[] typeMaps = EasyLOBHelper.Mapper.ConfigurationProvider.GetAllTypeMaps();
                            foreach (TypeMap typeMap in typeMaps)
                            {
                                stream.WriteLine("{0} -> {1}", typeMap.SourceType.ToString(), typeMap.DestinationType.ToString());
                            }
                        }

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
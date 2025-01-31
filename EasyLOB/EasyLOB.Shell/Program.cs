using Autofac;
using EasyLOB.Environment;
using System;
// Entity Framework Log
//using EasyLOB.Persistence;
//using System.Data.Entity.Infrastructure.Interception;

namespace EasyLOB.Shell
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // Autofac
            AppHelper.Setup(new ContainerBuilder());

            MultiTenantHelper.IsAuto = false;
            MultiTenantHelper.TenantName = "MyLOB";

            // Entity Framework Log
            //ILogManager logManager = EasyLOBHelper.GetService<ILogManager>();
            //DbInterception.Add(new EasyLOBDbCommandInterceptor(logManager));

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("EasyLOB Shell\n");
                Console.WriteLine("<0> EXIT");
                Console.WriteLine("<1> Application Demo");
                Console.WriteLine("<2> Persistence Demo");
                Console.WriteLine("<3> AutoMapper Demo");
                Console.WriteLine("<4> CRUD Demo");
                Console.WriteLine("<5> LINQ Demo");
                Console.WriteLine("<6> EDM Demo");
                Console.WriteLine("<7> Demo");

                Console.Write("\nChoose an option... ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        ApplicationDemo();
                        break;

                    case ('2'):
                        PersistenceDemo();
                        break;

                    case ('3'):
                        AutoMapperDemo();
                        break;

                    case ('4'):
                        CRUDDemo();
                        break;

                    case ('5'):
                        LINQDemo();
                        break;

                    case ('6'):
                        EDMDemo();
                        break;

                    case ('7'):
                        Demo();
                        break;
                }

                //if (!exit)
                //{
                //    Console.Write("\nPress <KEY> to continue... ");
                //    Console.ReadKey();
                //}
            }
        }
    }
}

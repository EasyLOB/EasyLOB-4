using Autofac;
using EasyLOB;
using EasyLOB.Environment;
using System;

// Entity Framework Log
//using EasyLOB.Persistence;
//using System.Data.Entity.Infrastructure.Interception;

namespace MyLOB.Shell
{
    partial class Program
    {
        private static void Main(string[] args)
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
                Console.WriteLine("MyLOB Shell\n");
                Console.WriteLine("<0> EXIT");
                Console.WriteLine("<1> Application Demo");
                Console.WriteLine("<2> Persistence Demo");
                Console.WriteLine("<3> Auto-Mapper Demo");
                Console.WriteLine("<4> Web API Demo");

                Console.Write("\nChoose an option... ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        ShellHelper.ApplicationDemo();
                        break;

                    case ('2'):
                        ShellHelper.PersistenceDemo();
                        break;

                    case ('3'):
                        ShellHelper.AutoMapperDemo();
                        break;

                    case ('4'):
                        ShellHelper.WebAPIDemo();
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
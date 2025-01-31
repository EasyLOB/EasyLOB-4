using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DemoEnvironmentSession()
        {
            IEnvironmentManager environmentManager = EasyLOBHelper.GetService<IEnvironmentManager>();

            Console.WriteLine("\nSession Demo");
            Console.WriteLine("\nIs Web ? " + environmentManager.IsWeb.ToString());
            Console.WriteLine("Session Write");
            SessionWrite();
            Console.WriteLine("Session Read");
            SessionRead();
            Console.WriteLine("Session Clear");
            SessionClear();
        }

        private static void SessionWrite()
        {
            IEnvironmentManager environmentManager = EasyLOBHelper.GetService<IEnvironmentManager>();

            Console.WriteLine("1 => Session[A]");
            environmentManager.SessionWrite("A", "1");
            Console.WriteLine("2 => Session[B]");
            environmentManager.SessionWrite("B", "2");

            Console.WriteLine("1 => Session[A]");
            environmentManager.SessionWrite("A", "1");
            Console.WriteLine("2 => Session[B]");
            environmentManager.SessionWrite("B", "2");
        }

        private static void SessionRead()
        {
            IEnvironmentManager environmentManager = EasyLOBHelper.GetService<IEnvironmentManager>();

            string sessionName;

            sessionName = "A";
            Console.WriteLine(((string)environmentManager.SessionRead(sessionName) ?? "") + " <= " + "Session[" + sessionName + "]");
            sessionName = "B";
            Console.WriteLine(((string)environmentManager.SessionRead(sessionName) ?? "") + " <= " + "Session[" + sessionName + "]");

            sessionName = "A";
            Console.WriteLine(((string)environmentManager.SessionRead(sessionName) ?? "") + " <= " + "Session[" + sessionName + "]");
            sessionName = "B";
            Console.WriteLine(((string)environmentManager.SessionRead(sessionName) ?? "") + " <= " + "Session[" + sessionName + "]");
        }

        private static void SessionClear()
        {
            IEnvironmentManager environmentManager = EasyLOBHelper.GetService<IEnvironmentManager>();

            string sessionName;

            sessionName = "A";
            environmentManager.SessionClear(sessionName);
            Console.WriteLine((string)environmentManager.SessionRead(sessionName) ?? "" + " <= " + "Session[" + sessionName + "]");
            sessionName = "B";
            environmentManager.SessionClear(sessionName);
            Console.WriteLine((string)environmentManager.SessionRead(sessionName) ?? "" + " <= " + "Session[" + sessionName + "]");

            sessionName = "A";
            environmentManager.SessionClear(sessionName);
            Console.WriteLine((string)environmentManager.SessionRead(sessionName) ?? "" + " <= " + "Session[" + sessionName + "]");
            sessionName = "B";
            environmentManager.SessionClear(sessionName);
            Console.WriteLine((string)environmentManager.SessionRead(sessionName) ?? "" + " <= " + "Session[" + sessionName + "]");
        }
    }
}
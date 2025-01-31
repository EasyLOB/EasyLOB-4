using EasyLOB.Data;
using EasyLOB.Library;
using Newtonsoft.Json;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void Demo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> CodeSmith Demo");
                Console.WriteLine("<2> Configuration Demo");
                Console.WriteLine("<3> DI Demo");
                Console.WriteLine("<4> e-mail Demo");
                Console.WriteLine("<5> Environment Application Demo");
                Console.WriteLine("<6> Environment Session Demo");
                Console.WriteLine("<7> Log Demo");
                Console.WriteLine("<8> Message Demo");
                Console.WriteLine("<9> Multi-Tenant Demo");
                Console.WriteLine("<A> Resources Demo");
                Console.WriteLine("<B> ZOperationResult Serialization");
                Console.WriteLine("<C> Clone");

                Console.Write("\nChoose an option... ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        DemoCodeSmith();
                        break;

                    case ('2'):
                        DemoConfiguration();
                        break;

                    case ('3'):
                        DemoDI();
                        break;

                    case ('4'):
                        DemoEMail();
                        break;

                    case ('5'):
                        DemoEnvironmentApplication();
                        break;

                    case ('6'):
                        DemoEnvironmentSession();
                        break;

                    case ('7'):
                        DemoLog();
                        break;

                    case ('8'):
                        Console.WriteLine();
                        Console.WriteLine(LibraryHelper.MessageNotFound("AuditTrailLog"));
                        Console.WriteLine(LibraryHelper.MessageNotFound("AuditTrailLog", 1));
                        Console.WriteLine(LibraryHelper.MessageNotFound("AuditTrailLog", null));
                        Console.WriteLine(LibraryHelper.MessageNotFound("AuditTrailLog", new object[] { 1, 2, 3 }));
                        Console.WriteLine(LibraryHelper.MessageNotFound("AuditTrailLog", new object[] { 1, "A", DateTime.Today }));
                        Console.WriteLine(LibraryHelper.MessageNotFound("AuditTrailLog", new object[] { 1, null, 3 }));
                        break;

                    case ('9'):
                        DemoMultiTenant();
                        break;

                    case ('a'):
                    case ('A'):
                        DemoResources();
                        break;

                    case ('b'):
                    case ('B'):
                        ZOperationResult operationResult = new ZOperationResult();

                        operationResult.InformationCode = "1";
                        operationResult.InformationMessage = "Information";
                        operationResult.WarningCode = "2";
                        operationResult.WarningMessage = "Warning";
                        operationResult.ErrorCode = "3";
                        operationResult.ErrorMessage = "Error";
                        operationResult.Data = "123";
                        operationResult.AddOperationInformation("11", "Information");
                        operationResult.AddOperationWarning("22", "Warning");
                        operationResult.AddOperationError("33", "Error");
                        operationResult.ParseException(new Exception("Exception"));

                        string json = JsonConvert.SerializeObject(operationResult);
                        operationResult = JsonConvert.DeserializeObject<ZOperationResult>(json);
                        int i = operationResult.Data.ToInt32();

                        WriteHelper.WriteObject(operationResult);

                        break;

                    case ('c'):
                    case ('C'):

                        //// Associations

                        EasyLOB.Activity.Data.ActivityRole activityRole1 = new EasyLOB.Activity.Data.ActivityRole();
                        activityRole1.ActivityId = "123";

                        // [Serializable]
                        //EasyLOB.Activity.Data.ActivityRole activityRole2 = activityRole1.CloneDeep<EasyLOB.Activity.Data.ActivityRole>();
                        //Console.WriteLine($"\nActivityRole CloneDeep() {activityRole2.ActivityId}");

                        EasyLOB.Activity.Data.ActivityRole activityRole3 = new EasyLOB.Activity.Data.ActivityRole();
                        activityRole3 = (EasyLOB.Activity.Data.ActivityRole)activityRole3.CloneShallow();
                        Console.WriteLine($"ActivityRole CloneShallow() {activityRole3.ActivityId}");

                        //EasyLOB.Activity.Data.ActivityRole activityRole4 = LibraryHelper.Clone(activityRole1);
                        //Console.WriteLine($"\nActivityRole LibraryHelper.Clone() {activityRole4.ActivityId}");

                        // Collections { get; }

                        EasyLOB.Activity.Data.Activity activity1 = new EasyLOB.Activity.Data.Activity();
                        activity1.Id = "123";

                        // [Serializable]
                        //EasyLOB.Activity.Data.Activity activity2 = activity1.CloneDeep<EasyLOB.Activity.Data.Activity>();
                        //Console.WriteLine($"\nActivity CloneDeep() {activity2.Id}");

                        EasyLOB.Activity.Data.Activity activity3 = (EasyLOB.Activity.Data.Activity)activity1.CloneShallow();
                        Console.WriteLine($"Activity CloneShallow() {activity3.Id}");

                        // { get; }
                        //EasyLOB.Activity.Data.Activity activity4 = LibraryHelper.Clone<EasyLOB.Activity.Data.Activity>(activity1);
                        //Console.WriteLine($"\nActivity LibraryHelper.Clone() {activity4.Id}");

                        // Profile

                        ZProfile profile1;
                        ZProfile profile2;

                        profile1 = (ZProfile)DataHelper.GetProfile(typeof(EasyLOB.Activity.Data.ActivityRole));
                        profile2 = profile1.CloneDeep<ZProfile>();
                        //profile2 = LibraryHelper.Clone<ZProfile>(profile1);
                        WriteHelper.WriteFileJSON("ActivityRole1.json", profile1);
                        WriteHelper.WriteFileJSON("ActivityRole2.json", profile2);

                        profile1 = (ZProfile)DataHelper.GetProfile(typeof(EasyLOB.Activity.Data.Activity));
                        profile2 = profile1.CloneDeep<ZProfile>();
                        //profile2 = LibraryHelper.Clone<ZProfile>(profile1);
                        WriteHelper.WriteFileJSON("Activity1.json", profile1);
                        WriteHelper.WriteFileJSON("Activity2.json", profile2);

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
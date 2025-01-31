using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void CRUDApplication()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("CRUD Application Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<T> TRUNCATE TABLE AuditTrailLog");
                Console.WriteLine("<1> CREATE AuditTrailLog");
                Console.WriteLine("<2> SEARCH AuditTrailLog [ 1 ]");
                Console.WriteLine("<3> UPDATE AuditTrailLog");
                Console.WriteLine("<4> DELETE AuditTrailLog");
                Console.WriteLine("<5> TRANSACTION COMMIT AuditTrailLog");
                Console.WriteLine("<6> TRANSACTION ROLLBAK AuditTrailLog");
                Console.WriteLine("<7> SEARCH + UPDATE");
                Console.WriteLine("<8> INSERT + SEARCH + UPDATE");

                Console.Write("\nChoose an option... ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                ZOperationResult operationResult = new ZOperationResult();

                IAuditTrailGenericApplication<AuditTrailLog> application = 
                    EasyLOBHelper.GetService<IAuditTrailGenericApplication<AuditTrailLog>>();
                AuditTrailLog auditTrailLog;

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;
                        application.Create(operationResult, auditTrailLog);

                        break;

                    case ('2'):
                        auditTrailLog = application.GetById(operationResult, 1);
                        if (auditTrailLog != null)
                        {
                            WriteHelper.WriteJSON(auditTrailLog);
                        }

                        break;

                    case ('3'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;
                        if (application.Create(operationResult, auditTrailLog))
                        {
                            auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                            auditTrailLog.LogTime = DateTime.Now.AddMonths(1);
                            application.Update(operationResult, auditTrailLog);
                        }

                        break;

                    case ('4'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;
                        if (application.Create(operationResult, auditTrailLog))
                        {
                            application.Delete(operationResult, auditTrailLog);
                        }

                        break;

                    case ('5'):
                        try
                        {
                            if (application.UnitOfWork.BeginTransaction(operationResult))
                            {
                                auditTrailLog = new AuditTrailLog();
                                auditTrailLog.LogDate = DateTime.Today;
                                auditTrailLog.LogTime = DateTime.Now;
                                if (application.Create(operationResult, auditTrailLog))
                                {
                                    auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                                    auditTrailLog.LogTime = DateTime.Now.AddMonths(1);
                                    if (application.Update(operationResult, auditTrailLog))
                                    {
                                        application.UnitOfWork.CommitTransaction(operationResult);
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            operationResult.ParseException(exception);
                        }

                        if (!operationResult.Ok)
                        {
                            application.UnitOfWork.RollbackTransaction(operationResult);
                        }

                        break;

                    case ('6'):
                        try
                        {
                            if (application.UnitOfWork.BeginTransaction(operationResult))
                            {
                                auditTrailLog = new AuditTrailLog();
                                auditTrailLog.LogDate = DateTime.Today;
                                auditTrailLog.LogTime = DateTime.Now;
                                if (application.Create(operationResult, auditTrailLog))
                                {
                                    auditTrailLog.LogDate = (auditTrailLog.LogDate ?? DateTime.Today).AddMonths(1);
                                    auditTrailLog.LogTime = (auditTrailLog.LogTime ?? DateTime.Now).AddMonths(1);
                                    if (application.Update(operationResult, auditTrailLog))
                                    {
                                        application.UnitOfWork.RollbackTransaction(operationResult);
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            operationResult.ParseException(exception);
                        }

                        if (!operationResult.Ok)
                        {
                            application.UnitOfWork.RollbackTransaction(operationResult);
                        }

                        break;

                    case ('7'):
                        try
                        {
                            // SEARCH
                            auditTrailLog = application
                                .Search(operationResult, x => x.Id >= 0)
                                .FirstOrDefault();
                            if (auditTrailLog != null)
                            {
                                Console.WriteLine($"\nSEARCH {auditTrailLog.Id} {auditTrailLog.LogDate}");

                                // UPDATE
                                auditTrailLog.LogDate = (auditTrailLog.LogDate ?? DateTime.Today).AddMonths(1);
                                auditTrailLog.LogTime = (auditTrailLog.LogTime ?? DateTime.Now).AddMonths(1);
                                if (application.Update(operationResult, auditTrailLog))
                                {
                                    Console.WriteLine($"UPDATE {auditTrailLog.Id} {auditTrailLog.LogDate}");

                                    //if (application.Delete(operationResult, auditTrailLog))
                                    //{
                                    //    Console.WriteLine($"DELETE");
                                    //}
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            operationResult.ParseException(exception);
                        }

                        break;

                    case ('8'):
                        try
                        {
                            // INSERT
                            auditTrailLog = new AuditTrailLog();
                            auditTrailLog.LogDate = DateTime.Today;
                            auditTrailLog.LogTime = DateTime.Now;
                            if (application.Create(operationResult, auditTrailLog))
                            {
                                Console.WriteLine($"\nINSERT {auditTrailLog.Id} {auditTrailLog.LogDate}");

                                int id = auditTrailLog.Id;

                                // SEARCH
                                auditTrailLog = application
                                    .Search(operationResult, x => x.Id == id)
                                    .FirstOrDefault();
                                if (auditTrailLog != null)
                                {
                                    Console.WriteLine($"SEARCH {auditTrailLog.Id} {auditTrailLog.LogDate}");

                                    // UPDATE
                                    auditTrailLog.LogDate = (auditTrailLog.LogDate ?? DateTime.Today).AddMonths(1);
                                    auditTrailLog.LogTime = (auditTrailLog.LogTime ?? DateTime.Now).AddMonths(1);
                                    if (application.Update(operationResult, auditTrailLog))
                                    {
                                        Console.WriteLine($"UPDATE {auditTrailLog.Id} {auditTrailLog.LogDate}");

                                        //if (application.Delete(operationResult, auditTrailLog))
                                        //{
                                        //    Console.WriteLine($"DELETE");
                                        //}
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            operationResult.ParseException(exception);
                        }

                        break;

                    case ('t'):
                    case ('T'):
                        application.UnitOfWork.SQLCommand("TRUNCATE TABLE EasyLOBAuditTrailLog");
                        break;
                }

                if (!exit)
                {
                    if (operationResult.Ok)
                    {
                        List<AuditTrailLog> list = (List<AuditTrailLog>)application
                            .Search(operationResult, null, o => o.OrderByDescending(x => x.Id))
                            .Take(5)
                            .ToList();
                        if (operationResult.Ok)
                        {
                            if (list.Count > 0)
                            {
                                Console.WriteLine();
                            }
                            foreach (AuditTrailLog entity in list)
                            {
                                Console.WriteLine("{0} {1} {2}", entity.Id, entity.LogDate, entity.LogTime);
                            }
                        }
                    }

                    if (!operationResult.Ok)
                    {
                        Console.WriteLine(operationResult.Text);
                    }

                    Console.Write("\nPress <KEY> to continue... ");
                    Console.ReadKey();
                }
            }
        }
    }
}
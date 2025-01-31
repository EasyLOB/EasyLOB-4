using EasyLOB.AuditTrail.Data;
using EasyLOB.AuditTrail.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void CRUDEntityFramework()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("CRUD Entity Framework Demo\n");
                Console.WriteLine("DO NOT USE Entity Framework ( or any other ORM ) classes in your application");
                Console.WriteLine("USE Persistence or Application layers classes");
                Console.WriteLine("The following examples are only for comparison with Persistence and Application implementations\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<T> TRUNCATE TABLE AuditTrailLog");
                Console.WriteLine("<1> CREATE AuditTrailLog");
                Console.WriteLine("<2> SEARCH AuditTrailLog [ 1 ]");
                Console.WriteLine("<3> UPDATE AuditTrailLog");
                Console.WriteLine("<4> DELETE AuditTrailLog");
                Console.WriteLine("<5> TRANSACTION COMMIT AuditTrailLog");
                Console.WriteLine("<6> TRANSACTION ROLLBAK AuditTrailLog");

                Console.Write("\nChoose an option... ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                ZOperationResult operationResult = new ZOperationResult();

                AuditTrailDbContext dbContext = new AuditTrailDbContext();
                DbSet<AuditTrailLog> dbSet = dbContext.AuditTrailLogs; // DBSet
                AuditTrailLog auditTrailLog;

                DbContextTransaction transaction;

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;

                        dbSet.Add(auditTrailLog);
                        dbContext.SaveChanges();

                        WriteHelper.WriteJSON(auditTrailLog);

                        break;

                    case ('2'):
                        auditTrailLog = dbSet
                            .Where(x => x.Id == 1)
                            .FirstOrDefault();
                        if (auditTrailLog != null)
                        {
                            WriteHelper.WriteJSON(auditTrailLog);
                        }

                        break;

                    case ('3'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;

                        dbSet.Add(auditTrailLog);
                        dbContext.SaveChanges();

                        auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                        auditTrailLog.LogTime = DateTime.Now.AddMonths(1);

                        dbContext.SaveChanges();

                        WriteHelper.WriteJSON(auditTrailLog);

                        break;

                    case ('4'):
                        auditTrailLog = new AuditTrailLog();
                        auditTrailLog.LogDate = DateTime.Today;
                        auditTrailLog.LogTime = DateTime.Now;

                        dbSet.Add(auditTrailLog);
                        dbContext.SaveChanges();

                        dbSet.Remove(auditTrailLog);
                        dbContext.SaveChanges();

                        WriteHelper.WriteJSON(auditTrailLog);

                        break;

                    case ('5'):
                        transaction = dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);

                        try
                        {
                            auditTrailLog = new AuditTrailLog();
                            auditTrailLog.LogDate = DateTime.Today;
                            auditTrailLog.LogTime = DateTime.Now;

                            dbSet.Add(auditTrailLog);
                            dbContext.SaveChanges();

                            auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                            auditTrailLog.LogTime = DateTime.Now.AddMonths(1);

                            dbContext.SaveChanges();

                            WriteHelper.WriteJSON(auditTrailLog);

                            transaction.Commit();
                        }
                        catch (Exception exception)
                        {
                            operationResult.ParseException(exception);

                            transaction.Rollback();
                        }

                        break;

                    case ('6'):
                        transaction = dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);

                        try
                        {
                            auditTrailLog = new AuditTrailLog();
                            auditTrailLog.LogDate = DateTime.Today;
                            auditTrailLog.LogTime = DateTime.Now;

                            dbSet.Add(auditTrailLog);
                            dbContext.SaveChanges();

                            auditTrailLog.LogDate = DateTime.Today.AddMonths(1);
                            auditTrailLog.LogTime = DateTime.Now.AddMonths(1);

                            dbContext.SaveChanges();

                            WriteHelper.WriteJSON(auditTrailLog);

                            transaction.Rollback();
                        }
                        catch (Exception exception)
                        {
                            operationResult.ParseException(exception);

                            transaction.Rollback();
                        }

                        break;

                    case ('t'):
                    case ('T'):
                        dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE EasyLOBAuditTrailLog");

                        break;
                }

                if (!exit)
                {
                    if (operationResult.Ok)
                    {
                        List<AuditTrailLog> list = dbSet.AsQueryable<AuditTrailLog>()
                            .OrderByDescending(x => x.Id)
                            .Take(5)
                            .ToList();
                        if (list.Count > 0)
                        {
                            Console.WriteLine();
                        }
                        foreach (AuditTrailLog entity in list)
                        {
                            Console.WriteLine("{0} {1} {2}", entity.Id, entity.LogDate, entity.LogTime);
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
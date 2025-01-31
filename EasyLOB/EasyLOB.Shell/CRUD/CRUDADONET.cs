using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Environment;
using EasyLOB.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void CRUDADONET()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("CRUD ADO.NET\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<T> TRUNCATE TABLE AuditTrailLog");
                Console.WriteLine("<1> INSERT + UPDATE AuditTrailLog");
                Console.WriteLine("<2> SELECT + DELETE AuditTrailLog");
                //Console.WriteLine("<3> UPDATE AuditTrailLog");
                //Console.WriteLine("<4> DELETE AuditTrailLog");
                //Console.WriteLine("<5> TRANSACTION COMMIT AuditTrailLog");
                //Console.WriteLine("<6> TRANSACTION ROLLBAK AuditTrailLog");

                Console.Write("\nChoose an option... ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                ZOperationResult operationResult = new ZOperationResult();

                IUnitOfWork unitOfWork =
                    EasyLOBHelper.GetService<IAuditTrailUnitOfWork>();
                IGenericRepository<AuditTrailLog> repository =
                    unitOfWork.GetRepository<AuditTrailLog>();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        {
                            try
                            {
                                string connectionName = MultiTenantHelper.GetConnectionName("AuditTrail");
                                DbProviderFactory provider = AdoNetHelper.GetProvider(connectionName);

                                using (DbConnection connection = provider.CreateConnection())
                                {
                                    connection.ConnectionString = AdoNetHelper.GetConnectionString(connectionName);
                                    connection.Open();

                                    DbCommand command = provider.CreateCommand();
                                    command.Connection = connection;
                                    command.CommandTimeout = 600;
                                    command.CommandType = CommandType.Text;

                                    // INSERT

                                    command.CommandText = @"
-- DECLARE @LogDate date = SYSDATETIME();
-- DECLARE @LogTime datetime = SYSDATETIME();

INSERT INTO EasyLOBAuditTrailLog (LogDate, LogTime) VALUES (@LogDate, @LogTime );
"
    + AdoNetHelper.GetIdSql(AdoNetHelper.GetDBMS(provider)); // IDENTITY

                                    command.Parameters.Clear();

                                    DbParameter parameter;

                                    parameter = command.CreateParameter();
                                    parameter.DbType = DbType.Date;
                                    parameter.ParameterName = "@LogDate";
                                    parameter.Value = DateTime.Today;
                                    command.Parameters.Add(parameter);

                                    parameter = command.CreateParameter();
                                    parameter.DbType = DbType.DateTime;
                                    parameter.ParameterName = "@LogTime";
                                    parameter.Value = DateTime.Now;
                                    command.Parameters.Add(parameter);

                                    AdoNetHelper.SqlParameters(command); // @ -> @ | :

                                    object id = command.ExecuteScalar(); // IDENTITY

                                    // UPDATE

                                    command.CommandText = @"
-- DECLARE @LogDate date = SYSDATETIME();
-- DECLARE @LogTime datetime = SYSDATETIME();

UPDATE EasyLOBAuditTrailLog SET LogDate = @LogDate, LogTime = @LogTime WHERE Id = @Id;
";

                                    command.Parameters.Clear();

                                    parameter = command.CreateParameter();
                                    parameter.DbType = DbType.Date;
                                    parameter.ParameterName = "@LogDate";
                                    parameter.Value = DateTime.Today.AddMonths(1);
                                    command.Parameters.Add(parameter);

                                    parameter = command.CreateParameter();
                                    parameter.DbType = DbType.DateTime;
                                    parameter.ParameterName = "@LogTime";
                                    parameter.Value = DateTime.Now.AddMonths(1);
                                    command.Parameters.Add(parameter);

                                    parameter = command.CreateParameter();
                                    parameter.DbType = DbType.Int32;
                                    parameter.ParameterName = "@Id";
                                    parameter.Value = id;
                                    command.Parameters.Add(parameter);

                                    AdoNetHelper.SqlParameters(command); // @ -> @ | :

                                    command.ExecuteNonQuery();
                                }
                            }
                            catch (Exception exception)
                            {
                                operationResult.ParseException(exception);
                            }
                        }

                        break;

                    case ('2'):
                        {
                            try
                            {
                                string connectionName = MultiTenantHelper.GetConnectionName("AuditTrail");
                                DbProviderFactory provider = AdoNetHelper.GetProvider(connectionName);

                                using (DbConnection connection = provider.CreateConnection())
                                {
                                    connection.ConnectionString = AdoNetHelper.GetConnectionString(connectionName);
                                    connection.Open();

                                    DbCommand command = provider.CreateCommand();
                                    command.Connection = connection;
                                    command.CommandTimeout = 600;
                                    command.CommandType = CommandType.Text;

                                    command.CommandText = @"
SET NOCOUNT ON

SELECT * FROM EasyLOBAuditTrailLog ORDER BY Id;
";

                                    command.Parameters.Clear();

                                    //DbParameter parameter;

                                    using (DbDataReader reader = command.ExecuteReader(IsolationLevel.ReadUncommitted))
                                    {
                                        if (reader.Read())
                                        {
                                            int id = reader.ToInt32("Id");
                                            DateTime logTime = reader.ToDateTime("LogTime");
                                            Console.WriteLine("\n{0} {1}", id, logTime);

                                            AdoNetHelper.SqlCommand("AuditTrail", $"DELETE FROM EasyLOBAuditTrailLog WHERE Id = {id};");
                                        }
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                WriteHelper.WriteException(exception);
                            }
                        }

                        break;

                    case ('3'):

                        break;

                    case ('4'):
                        break;

                    case ('5'):
                        break;

                    case ('6'):
                        break;

                    case ('t'):
                    case ('T'):
                        AdoNetHelper.SqlCommand("AuditTrail", "TRUNCATE TABLE EasyLOBAuditTrailLog;");

                        break;
                }

                if (!exit)
                {
                    if (operationResult.Ok)
                    {
                        {
                            try
                            {
                                string connectionName = MultiTenantHelper.GetConnectionName("AuditTrail");
                                DbProviderFactory provider = AdoNetHelper.GetProvider(connectionName);

                                using (DbConnection connection = provider.CreateConnection())
                                {
                                    connection.ConnectionString = AdoNetHelper.GetConnectionString(connectionName);
                                    connection.Open();

                                    DbCommand command = provider.CreateCommand();
                                    command.Connection = connection;
                                    command.CommandTimeout = 600;
                                    command.CommandType = CommandType.Text;

                                    command.CommandText = @"
SET NOCOUNT ON

SELECT * FROM EasyLOBAuditTrailLog ORDER BY Id DESC
";

                                    command.Parameters.Clear();

                                    AdoNetHelper.SqlParameters(command); // @ -> @ | :

                                    bool line = false;

                                    using (DbDataReader reader = command.ExecuteReader(IsolationLevel.ReadUncommitted))
                                    {
                                        while (reader.Read())
                                        {
                                            if (!line)
                                            {
                                                Console.WriteLine();
                                                line = true;
                                            }

                                            int id = reader.ToInt32("Id");
                                            DateTime logDate = reader.ToDateTime("LogDate");
                                            DateTime logTime = reader.ToDateTime("LogTime");
                                            Console.WriteLine("{0} {1} {2}", id, logDate, logTime);
                                        }
                                    }
                                }
                            }
                            catch (Exception exception)
                            {
                                operationResult.ParseException(exception);
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
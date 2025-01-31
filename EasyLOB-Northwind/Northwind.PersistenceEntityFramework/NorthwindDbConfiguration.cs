using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

// Install-Package System.Data.SqlClient -Version 4.6.0

namespace Northwind.Persistence
{
    public class NorthwindDbConfiguration : DbConfiguration
    {
        public NorthwindDbConfiguration()
        {
            // Connection resiliency and retry logic
            // https://docs.microsoft.com/en-us/ef/ef6/fundamentals/connection-resiliency/retry-logic#configuring-the-execution-strategy
            // The SqlAzureExecutionStrategy will retry instantly the first time a transient failure occurs,
            // but will delay longer between each retry until
            // either the max retry limit is exceeded or the total time hits the max delay.
            // 0
            // 1: +0 seconds
            // 2: +2.5 seconds
            // 3: +5.0 seconds
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy(3, TimeSpan.FromMilliseconds(2500)));
            //SetExecutionStrategy("System.Data.SqlClient", () => new NorthwindExecutionStrategy(3, TimeSpan.FromMilliseconds(2500)));
        }
    }
    /*
    public static class SqlServerErrorCodes
    {
        public const int CouldNotOpenConnection = 53;
        public const int Deadlock = 1205;
        public const int TimeoutExpired = -2;
        public const int TransportFail = 121;
    }

    public class NorthwindExecutionStrategy : SqlAzureExecutionStrategy // DbExecutionStrategy
    {
        public NorthwindExecutionStrategy(int maxRetryCount, TimeSpan maxDelay)
            : base(maxRetryCount, maxDelay)
        {
        }

        private readonly List<int> _errorCodes = new List<int>
        {
            SqlServerErrorCodes.CouldNotOpenConnection,
            SqlServerErrorCodes.Deadlock,
            SqlServerErrorCodes.TimeoutExpired,
            SqlServerErrorCodes.TransportFail
        };

        protected override bool ShouldRetryOn(Exception exception)
        {
            var sqlException = exception as SqlException;
            if (sqlException != null)
            {
                foreach (SqlError error in sqlException.Errors)
                {
                    if (_errorCodes.Contains(error.Number))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
     */
}     

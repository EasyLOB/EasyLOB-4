using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindEmployeeTerritoryRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<EmployeeTerritory>
    {
        #region Methods

        public NorthwindEmployeeTerritoryRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<EmployeeTerritory> Join(IQueryable<EmployeeTerritory> query)
        {
            return
                from employeeTerritory in query
                join employee in UnitOfWork.GetQuery<Employee>() on employeeTerritory.EmployeeId equals employee.EmployeeId // INNER JOIN
                join territory in UnitOfWork.GetQuery<Territory>() on employeeTerritory.TerritoryId equals territory.TerritoryId // INNER JOIN
                select new EmployeeTerritory
                {
                    EmployeeId = employeeTerritory.EmployeeId,
                    TerritoryId = employeeTerritory.TerritoryId,
                    Employee = employee,
                    Territory = territory
                };
        }

        #endregion Methods
    }
}


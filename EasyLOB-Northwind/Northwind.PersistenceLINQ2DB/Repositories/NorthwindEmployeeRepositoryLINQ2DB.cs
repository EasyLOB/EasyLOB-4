using Northwind.Data;
using EasyLOB;
using System.Linq;

namespace Northwind.Persistence
{
    public class NorthwindEmployeeRepositoryLINQ2DB : NorthwindGenericRepositoryLINQ2DB<Employee>
    {
        #region Methods

        public NorthwindEmployeeRepositoryLINQ2DB(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<Employee> Join(IQueryable<Employee> query)
        {
            return
                from employee in query
                from employeeReportsTo in UnitOfWork.GetQuery<Employee>().Where(x => x.EmployeeId == employee.ReportsTo).DefaultIfEmpty() // LEFT JOIN
                select new Employee
                {
                    EmployeeId = employee.EmployeeId,
                    LastName = employee.LastName,
                    FirstName = employee.FirstName,
                    Title = employee.Title,
                    TitleOfCourtesy = employee.TitleOfCourtesy,
                    BirthDate = employee.BirthDate,
                    HireDate = employee.HireDate,
                    Address = employee.Address,
                    City = employee.City,
                    Region = employee.Region,
                    PostalCode = employee.PostalCode,
                    Country = employee.Country,
                    HomePhone = employee.HomePhone,
                    Extension = employee.Extension,
                    Photo = employee.Photo,
                    Notes = employee.Notes,
                    ReportsTo = employee.ReportsTo,
                    PhotoPath = employee.PhotoPath,
                    EmployeeX = employeeReportsTo
                };
        }

        #endregion Methods
    }
}


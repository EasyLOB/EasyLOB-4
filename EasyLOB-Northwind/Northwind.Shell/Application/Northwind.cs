using Northwind;
using Northwind.Data;
using EasyLOB.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB
{
    public static partial class ShellHelper
    {
        private static void ApplicationNorthwindDemo()
        {
            Console.WriteLine("\nApplication Northwind Demo\n");

            ApplicationNorthwindData<Category>();
            ApplicationNorthwindDTO<CategoryDTO, Category>();

            ApplicationNorthwindData<CustomerCustomerDemo>();
            ApplicationNorthwindDTO<CustomerCustomerDemoDTO, CustomerCustomerDemo>();

            ApplicationNorthwindData<CustomerDemographic>();
            ApplicationNorthwindDTO<CustomerDemographicDTO, CustomerDemographic>();

            ApplicationNorthwindData<Customer>();
            ApplicationNorthwindDTO<CustomerDTO, Customer>();

            ApplicationNorthwindData<Employee>();
            ApplicationNorthwindDTO<EmployeeDTO, Employee>();

            ApplicationNorthwindData<EmployeeTerritory>();
            ApplicationNorthwindDTO<EmployeeTerritoryDTO, EmployeeTerritory>();

            ApplicationNorthwindData<OrderDetail>();
            ApplicationNorthwindDTO<OrderDetailDTO, OrderDetail>();

            ApplicationNorthwindData<Order>();
            ApplicationNorthwindDTO<OrderDTO, Order>();

            ApplicationNorthwindData<Product>();
            ApplicationNorthwindDTO<ProductDTO, Product>();

            ApplicationNorthwindData<Region>();
            ApplicationNorthwindDTO<RegionDTO, Region>();

            ApplicationNorthwindData<Shipper>();
            ApplicationNorthwindDTO<ShipperDTO, Shipper>();

            ApplicationNorthwindData<Supplier>();
            ApplicationNorthwindDTO<SupplierDTO, Supplier>();

            ApplicationNorthwindData<Territory>();
            ApplicationNorthwindDTO<TerritoryDTO, Territory>();
        }

        private static void ApplicationNorthwindData<TEntity>()
            where TEntity : ZDataModel
        {
            ZOperationResult operationResult = new ZOperationResult();

            INorthwindGenericApplication<TEntity> application =
                EasyLOBHelper.GetService<INorthwindGenericApplication<TEntity>>();
            List<TEntity> enumerable = application.Search(operationResult, null, null, null, 100, null);
            //IEnumerable<TEntity> enumerable = application.SearchAll(operationResult);
            if (operationResult.Ok)
            {
                Console.WriteLine(typeof(TEntity).Name + ": {0}", enumerable.Count());
            }
            else
            {
                Console.WriteLine(operationResult.Text);
            }
        }

        private static void ApplicationNorthwindDTO<TEntityDTO, TEntity>()
            where TEntityDTO : ZDTOModel<TEntityDTO, TEntity>
            where TEntity : ZDataModel
        {
            ZOperationResult operationResult = new ZOperationResult();

            INorthwindGenericApplicationDTO<TEntityDTO, TEntity> application =
                EasyLOBHelper.GetService<INorthwindGenericApplicationDTO<TEntityDTO, TEntity>>();
            List<TEntityDTO> enumerable = application.Search(operationResult, null, null, null, 100, null);
            //IEnumerable<TEntityDTO> enumerable = application.SearchAll(operationResult);
            if (operationResult.Ok)
            {
                Console.WriteLine(typeof(TEntity).Name + ": {0}", enumerable.Count());
            }
            else
            {
                Console.WriteLine(operationResult.Text);
            }
        }
    }
}

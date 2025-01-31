using Northwind.Data;
using System;

namespace EasyLOB
{
    public static partial class ShellHelper
    {
        private static void AutoMapperNorthwindDemo()
        {
            Console.WriteLine("\nAutoMapper Northwind Demo\n");

            {
                Console.WriteLine("Category");
                Category data = new Category();
                CategoryDTO dto = EasyLOBHelper.Mapper.Map<CategoryDTO>(data);
                data = EasyLOBHelper.Mapper.Map<Category>(dto);
            }

            {
                Console.WriteLine("CustomerCustomerDemo");
                CustomerCustomerDemo data = new CustomerCustomerDemo();
                CustomerCustomerDemoDTO dto = EasyLOBHelper.Mapper.Map<CustomerCustomerDemoDTO>(data);
                data = EasyLOBHelper.Mapper.Map<CustomerCustomerDemo>(dto);
            }

            {
                Console.WriteLine("CustomerDemographic");
                CustomerDemographic data = new CustomerDemographic();
                CustomerDemographicDTO dto = EasyLOBHelper.Mapper.Map<CustomerDemographicDTO>(data);
                data = EasyLOBHelper.Mapper.Map<CustomerDemographic>(dto);
            }

            {
                Console.WriteLine("Customer");
                Customer data = new Customer();
                CustomerDTO dto = EasyLOBHelper.Mapper.Map<CustomerDTO>(data);
                data = EasyLOBHelper.Mapper.Map<Customer>(dto);
            }

            {
                Console.WriteLine("Employee");
                Employee data = new Employee();
                EmployeeDTO dto = EasyLOBHelper.Mapper.Map<EmployeeDTO>(data);
                data = EasyLOBHelper.Mapper.Map<Employee>(dto);
            }

            {
                Console.WriteLine("EmployeeTerritory");
                EmployeeTerritory data = new EmployeeTerritory();
                EmployeeTerritoryDTO dto = EasyLOBHelper.Mapper.Map<EmployeeTerritoryDTO>(data);
                data = EasyLOBHelper.Mapper.Map<EmployeeTerritory>(dto);
            }

            {
                Console.WriteLine("OrderDetail");
                OrderDetail data = new OrderDetail();
                OrderDetailDTO dto = EasyLOBHelper.Mapper.Map<OrderDetailDTO>(data);
                data = EasyLOBHelper.Mapper.Map<OrderDetail>(dto);
            }

            {
                Console.WriteLine("Order");
                Order data = new Order();
                OrderDTO dto = EasyLOBHelper.Mapper.Map<OrderDTO>(data);
                data = EasyLOBHelper.Mapper.Map<Order>(dto);
            }

            {
                Console.WriteLine("Product");
                Product data = new Product();
                ProductDTO dto = EasyLOBHelper.Mapper.Map<ProductDTO>(data);
                data = EasyLOBHelper.Mapper.Map<Product>(dto);
            }

            {
                Console.WriteLine("Region");
                Region data = new Region();
                RegionDTO dto = EasyLOBHelper.Mapper.Map<RegionDTO>(data);
                data = EasyLOBHelper.Mapper.Map<Region>(dto);
            }

            {
                Console.WriteLine("Shipper");
                Shipper data = new Shipper();
                ShipperDTO dto = EasyLOBHelper.Mapper.Map<ShipperDTO>(data);
                data = EasyLOBHelper.Mapper.Map<Shipper>(dto);
            }

            {
                Console.WriteLine("Supplier");
                Supplier data = new Supplier();
                SupplierDTO dto = EasyLOBHelper.Mapper.Map<SupplierDTO>(data);
                data = EasyLOBHelper.Mapper.Map<Supplier>(dto);
            }

            {
                Console.WriteLine("Territory");
                Territory data = new Territory();
                TerritoryDTO dto = EasyLOBHelper.Mapper.Map<TerritoryDTO>(data);
                data = EasyLOBHelper.Mapper.Map<Territory>(dto);
            }
        }
    }
}
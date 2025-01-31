using Northwind;
using Northwind.Application;
using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB
{
    public static partial class ShellHelper
    {
        #region Methods

        public static void Tutorial()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Tutorial\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<E> EasyLOB");
                Console.WriteLine("<A> Application Layer");
                Console.WriteLine("<P> Persistence Layer");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar)
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('E'):
                    case ('e'):
                        {

                            // *Manager = classe
                            
                            // AuditTrailManager
                            // AuthenticationManager
                            // AuthorizationManager
                            // LogManager

                            // *Helper = classe estática

                            // ConfigurationHelper
                            //     AppSettings<>()
                            // EasyLOBHelper
                            //     Mapper
                            //     GetService<>()
                            // EMailHelper
                            // MultiTenantHelper | NorthwindMultiTenantHelper

                            //// ZOperation Result

                            ZOperationResult operationResult = new ZOperationResult();

                            // GREEN
                            // operationResult.Ok = true
                            operationResult.AddOperationInformation("", "Information");

                            // YELLOW
                            // operationResult.Ok = false
                            operationResult.AddOperationWarning("", "Warning");

                            // READ
                            // operationResult.Ok = false
                            operationResult.AddOperationError("", "Error");

                            Console.WriteLine("\n{0}", operationResult.Text);
                            Console.WriteLine("\n{0}", operationResult.Html);

                            //// ConfigurationHelper

                            //{
                            //    "Northwind": {
                            //        "API": {
                            //            "Url": "http://localhost:55201",
                            //        }
                            //    }
                            //}
                            string setting1 = ConfigurationHelper.AppSettings<string>("WebAPI.Url");
                            Console.WriteLine("\n{0}", setting1);

                            // AutoMapper

                            Product product = new Product();
                            ProductDTO productDTO = EasyLOBHelper.Mapper.Map<ProductDTO>(product);
                            product = EasyLOBHelper.Mapper.Map<Product>(productDTO);
                        }
                        break;

                    case ('A'):
                    case ('a'):
                        {
                            // Application Layer

                            // :: IGenericApplication
                            //    returns the entity and ALL the associated entities ( first level of FKs )
                            //        Product
                            //            Category
                            //            Supplier
                            // :: Create(), Update() e Delete() execute the operation and the COMMIT
                            // :: allows dynamic LINQ in the Search method "where" and "orderBy" parameters
                            // :: does not allow LINQ among entities
                            // :: enforces Authorization
                            // :: enforces Audit Trail, if enabled

                            Console.WriteLine("\nApplication");

                            ZOperationResult operationResult = new ZOperationResult();

                            // DI
                            INorthwindGenericApplication<Product> applicationProduct =
                                EasyLOBHelper.GetService<INorthwindGenericApplication<Product>>();

                            Product product;

                            product = applicationProduct
                                .GetById(operationResult, 0);
 
                            product = applicationProduct
                                //.Search(operationResult, where, orderBy, skip, take, associations);
                                .Search(operationResult, x => x.ProductId < 10, x => x.OrderBy(y => y.ProductName))
                                .FirstOrDefault();

                            Console.WriteLine();
                            WriteHelper.WriteJSON(product);

                            ProductDTO productDTO = EasyLOBHelper.Mapper.Map<ProductDTO>(product);

                            Console.WriteLine();
                            WriteHelper.WriteJSON(productDTO);

                            List<Product> products = applicationProduct
                                .Search(operationResult, "ProductId < 10");

                            //product = new Product();
                            //if (applicationProduct.Create(operationResult, product))
                            //{
                            //}

                            //product = applicationProduct.GetById(operationResult, 0);
                            //if (operationresut &&
                            //    product != null && applicationProduct.Update(operationResult, product))
                            //{
                            //}

                            //product = new Product { Id = 0 }; // PK
                            //if (applicationProduct.Delete(operationResult, product))
                            //{
                            //}

                            // UnitOfWork

                            IUnitOfWork unitOfWork = applicationProduct.UnitOfWork;
                        }
                        break;

                    case ('P'):
                    case ('p'):
                        {
                            // Persistence Layer

                            // :: IGenericRepository
                            // :: IQueryable
                            //    returns the entity and ALL the associated entities ( first level of FKs )
                            //        Product
                            //            Category
                            //            Supplier
                            // :: Create(), Update() e Delete() executam a operação, mas precisam de um Save()
                            // :: allows dynamic LINQ in the Search method "where" and "orderBy" parameters
                            // :: allows LINQ between entities

                            Console.WriteLine("\nPersistence");

                            ZOperationResult operationResult = new ZOperationResult();

                            // DI
                            //IUnitOfWork unitOfWork =
                            INorthwindUnitOfWork unitOfWork =
                                EasyLOBHelper.GetService<INorthwindUnitOfWork>();

                            IGenericRepository<Product> repositoryProduct = unitOfWork.GetRepository<Product>();

                            Product product;

                            // IGenericRepository

                            product = repositoryProduct
                                .GetById(1);

                            Console.WriteLine("\nIGenericRepository");
                            WriteHelper.WriteJSON(product);

                            ProductDTO productDTO = EasyLOBHelper.Mapper.Map<ProductDTO>(product);

                            Console.WriteLine();
                            WriteHelper.WriteJSON(productDTO);

                            product = repositoryProduct
                                //.Search(where, orderBy, skip, take, associations);
                                .Search(x => x.ProductId < 10)
                                .OrderBy(x => x.ProductName)
                                .FirstOrDefault();

                            Console.WriteLine("\nIGenericRepository");
                            WriteHelper.WriteJSON(product);

                            // IQueryable

                            product = repositoryProduct.Query()
                                .Where(x => x.ProductId == 1)
                                .FirstOrDefault();

                            Console.WriteLine("\nIQueryable");
                            WriteHelper.WriteJSON(product);

                            List<Product> products = repositoryProduct
                                .Search("ProductId < 10");

                            List<string> suppliers =
                                (
                                    from xProduct in unitOfWork.GetQuery<Product>()
                                    join xCategory in unitOfWork.GetQuery<Category>() on
                                        xProduct.CategoryId equals xCategory.CategoryId
                                    join xSupplier in unitOfWork.GetQuery<Supplier>() on
                                        xProduct.SupplierId equals xSupplier.SupplierId
                                    select xSupplier.CompanyName
                                )
                                .ToList();
                            /*
                            product = new Product();
                            if (repositoryProduct.Create(operationResult, product))
                            {
                                if (unitOfWork.Save(operationResult))
                                {
                                }
                            }

                            product = repositoryProduct.GetById(1);
                            if (product != null && repositoryProduct.Update(operationResult, product))
                            {
                                if (unitOfWork.Save(operationResult))
                                {
                                }
                            }

                            product = new Product { Id = 0 };
                            if (repositoryProduct.Delete(operationResult, product))
                            {
                                if (unitOfWork.Save(operationResult))
                                {
                                }
                            }
                            */
                        }
                        break;
                }

                if (!exit)
                {
                    Console.Write("\nPress <KEY> to continue... ");
                    Console.ReadKey();
                }
            }
        }

        #endregion Methods
    }
}
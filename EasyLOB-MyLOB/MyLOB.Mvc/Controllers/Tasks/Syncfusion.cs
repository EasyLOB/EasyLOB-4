using EasyLOB.Resources;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        #region Methods

        // GET: Tasks/Syncfusion
        [HttpGet]
        public ActionResult Syncfusion()
        {
            TaskViewModel viewModel = new TaskViewModel("Tasks", "Syncfusion", "Syncfusion");

            List<object> list = new List<object>();

            list.Add(new {
                OrderID = 1,
                CustomerID = 1,
                OrderDate = DateTime.Today,
                Freight = 1.11,
                ShippedDate = DateTime.Today.AddMonths(-1),
                ShipCountry = "Country",
                ShipCity = "City"
            });
            list.Add(new
            {
                OrderID = 2,
                CustomerID = 2,
                OrderDate = DateTime.Today,
                Freight = 2.22,
                ShippedDate = DateTime.Today.AddMonths(-1),
                ShipCountry = "Country",
                ShipCity = "City"
            });
            list.Add(new
            {
                OrderID = 3,
                CustomerID = 3,
                OrderDate = DateTime.Today,
                Freight = 3.33,
                ShippedDate = DateTime.Today.AddMonths(-1),
                ShipCountry = "Country",
                ShipCity = "City"
            });

            ViewBag.datasource = list;

            return ZView(viewModel);
        }

        #endregion Methods
    }
}
using Northwind.Application;
using Northwind.Data;
using Northwind.Data.Resources;
using EasyLOB;
using EasyLOB.WebApi;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Northwind.WebApi
{
    [RoutePrefix("api/CustomerCustomerDemo")]
    public class CustomerCustomerDemoAPIController : BaseApiControllerApplicationDTO<CustomerCustomerDemoDTO, CustomerCustomerDemo>
    {
        #region Methods

        public CustomerCustomerDemoAPIController(INorthwindGenericApplicationDTO<CustomerCustomerDemoDTO, CustomerCustomerDemo> application,
            IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        /// <summary>
        /// DELETE: api/CustomerCustomerDemo/1 
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="customerTypeId">customerTypeId</param>
        /// <returns>object[] Ids</returns>
        [Route("{customerId}/{customerTypeId}")]
        public IHttpActionResult DeleteCustomerCustomerDemo([FromUri] string customerId, [FromUri] string customerTypeId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsDelete(operationResult))
                {
                    object[] ids = new object[] { customerId, customerTypeId };
                    CustomerCustomerDemoDTO customerCustomerDemoDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (customerCustomerDemoDTO != null)
                        {
                            if (Application.Delete(operationResult, customerCustomerDemoDTO))
                            {
                                return Ok(ids);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < ids.Length; i++)
                            {
                                ids[i] = null;
                            }

                            return Ok(ids);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ActionResultOperationResult(operationResult);
        }

        /// <summary>
        /// GET: api/CustomerCustomerDemo/1
        /// </summary>
        /// <param name="customerId">customerId</param>
        /// <param name="customerTypeId">customerTypeId</param>
        /// <returns>CustomerCustomerDemoDTO</returns>
        [Route("{customerId}/{customerTypeId}")]
        public IHttpActionResult GetCustomerCustomerDemo([FromUri] string customerId, [FromUri] string customerTypeId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsSearch(operationResult))
                {
                    object[] ids = new object[] { customerId, customerTypeId };
                    CustomerCustomerDemoDTO customerCustomerDemoDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (customerCustomerDemoDTO != null)
                        {
                            return Ok(customerCustomerDemoDTO);
                        }
                        else
                        {
                            return Ok((object)null);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ActionResultOperationResult(operationResult);
        }

        /// <summary>
        /// GET: api/CustomerCustomerDemo/Where="null"/OrderBy="null"/Skip=0/Take=100
        /// </summary>
        /// <param name="where">WHERE</param>
        /// <param name="orderBy">ORDER BY</param>
        /// <param name="skip">SKIP</param>
        /// <param name="take">TAKE</param>
        /// <returns>List[CustomerCustomerDemoDTO]</returns>
        [Route("{where}/{orderBy}/{skip}/{take}")]
        public IHttpActionResult GetCustomerCustomerDemos([FromUri] string where = null,
            [FromUri] string orderBy = null,
            [FromUri] int? skip = null,
            [FromUri] int? take = null)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsSearch(operationResult))
                {
                    where = string.IsNullOrEmpty(where) || where.ToLower() == "null" ? null : where;
                    orderBy = string.IsNullOrEmpty(orderBy) || orderBy.ToLower() == "null" ? null : orderBy;

                    IEnumerable<CustomerCustomerDemoDTO> result = Application.Search(operationResult,
                        where, null, orderBy, skip, take ?? AppDefaults.SyncfusionRecordsBySearch);
                    if (operationResult.Ok)
                    {
                        return Ok(result);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ActionResultOperationResult(operationResult);
        }

        /// <summary>
        /// POST: api/CustomerCustomerDemo
        /// </summary>
        /// <param name="customerCustomerDemoDTO">CustomerCustomerDemoDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PostCustomerCustomerDemo([FromBody] CustomerCustomerDemoDTO customerCustomerDemoDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsCreate(operationResult))
                {
                    if (Application.Create(operationResult, customerCustomerDemoDTO))
                    {
                        return Ok(customerCustomerDemoDTO.ToData().GetId());
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ActionResultOperationResult(operationResult);
        }

        /// <summary>
        /// PUT: api/CustomerCustomerDemo
        /// </summary>
        /// <param name="customerCustomerDemoDTO">CustomerCustomerDemoDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PutCustomerCustomerDemo([FromBody] CustomerCustomerDemoDTO customerCustomerDemoDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsUpdate(operationResult))
                {
                    object[] ids = customerCustomerDemoDTO.ToData().GetId();
                    CustomerCustomerDemoDTO dto = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (dto != null)
                        {
                            if (Application.Update(operationResult, customerCustomerDemoDTO))
                            {
                                return Ok(ids);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < ids.Length; i++)
                            {
                                ids[i] = null;
                            }

                            return Ok(ids);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ActionResultOperationResult(operationResult);
        }

        #endregion Methods REST
    }
}

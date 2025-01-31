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
    [RoutePrefix("api/CustomerDemographic")]
    public class CustomerDemographicAPIController : BaseApiControllerApplicationDTO<CustomerDemographicDTO, CustomerDemographic>
    {
        #region Methods

        public CustomerDemographicAPIController(INorthwindGenericApplicationDTO<CustomerDemographicDTO, CustomerDemographic> application,
            IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        /// <summary>
        /// DELETE: api/CustomerDemographic/1 
        /// </summary>
        /// <param name="customerTypeId">customerTypeId</param>
        /// <returns>object[] Ids</returns>
        [Route("{customerTypeId}")]
        public IHttpActionResult DeleteCustomerDemographic([FromUri] string customerTypeId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsDelete(operationResult))
                {
                    object[] ids = new object[] { customerTypeId };
                    CustomerDemographicDTO customerDemographicDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (customerDemographicDTO != null)
                        {
                            if (Application.Delete(operationResult, customerDemographicDTO))
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
        /// GET: api/CustomerDemographic/1
        /// </summary>
        /// <param name="customerTypeId">customerTypeId</param>
        /// <returns>CustomerDemographicDTO</returns>
        [Route("{customerTypeId}")]
        public IHttpActionResult GetCustomerDemographic([FromUri] string customerTypeId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsSearch(operationResult))
                {
                    object[] ids = new object[] { customerTypeId };
                    CustomerDemographicDTO customerDemographicDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (customerDemographicDTO != null)
                        {
                            return Ok(customerDemographicDTO);
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
        /// GET: api/CustomerDemographic/Where="null"/OrderBy="null"/Skip=0/Take=100
        /// </summary>
        /// <param name="where">WHERE</param>
        /// <param name="orderBy">ORDER BY</param>
        /// <param name="skip">SKIP</param>
        /// <param name="take">TAKE</param>
        /// <returns>List[CustomerDemographicDTO]</returns>
        [Route("{where}/{orderBy}/{skip}/{take}")]
        public IHttpActionResult GetCustomerDemographics([FromUri] string where = null,
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

                    IEnumerable<CustomerDemographicDTO> result = Application.Search(operationResult,
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
        /// POST: api/CustomerDemographic
        /// </summary>
        /// <param name="customerDemographicDTO">CustomerDemographicDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PostCustomerDemographic([FromBody] CustomerDemographicDTO customerDemographicDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsCreate(operationResult))
                {
                    if (Application.Create(operationResult, customerDemographicDTO))
                    {
                        return Ok(customerDemographicDTO.ToData().GetId());
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
        /// PUT: api/CustomerDemographic
        /// </summary>
        /// <param name="customerDemographicDTO">CustomerDemographicDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PutCustomerDemographic([FromBody] CustomerDemographicDTO customerDemographicDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsUpdate(operationResult))
                {
                    object[] ids = customerDemographicDTO.ToData().GetId();
                    CustomerDemographicDTO dto = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (dto != null)
                        {
                            if (Application.Update(operationResult, customerDemographicDTO))
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

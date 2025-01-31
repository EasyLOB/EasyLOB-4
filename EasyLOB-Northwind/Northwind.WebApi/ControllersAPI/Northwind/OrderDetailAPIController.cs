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
    [RoutePrefix("api/OrderDetail")]
    public class OrderDetailAPIController : BaseApiControllerApplicationDTO<OrderDetailDTO, OrderDetail>
    {
        #region Methods

        public OrderDetailAPIController(INorthwindGenericApplicationDTO<OrderDetailDTO, OrderDetail> application,
            IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        /// <summary>
        /// DELETE: api/OrderDetail/1 
        /// </summary>
        /// <param name="orderId">orderId</param>
        /// <param name="productId">productId</param>
        /// <returns>object[] Ids</returns>
        [Route("{orderId}/{productId}")]
        public IHttpActionResult DeleteOrderDetail([FromUri] int orderId, [FromUri] int productId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsDelete(operationResult))
                {
                    object[] ids = new object[] { orderId, productId };
                    OrderDetailDTO orderDetailDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (orderDetailDTO != null)
                        {
                            if (Application.Delete(operationResult, orderDetailDTO))
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
        /// GET: api/OrderDetail/1
        /// </summary>
        /// <param name="orderId">orderId</param>
        /// <param name="productId">productId</param>
        /// <returns>OrderDetailDTO</returns>
        [Route("{orderId}/{productId}")]
        public IHttpActionResult GetOrderDetail([FromUri] int orderId, [FromUri] int productId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsSearch(operationResult))
                {
                    object[] ids = new object[] { orderId, productId };
                    OrderDetailDTO orderDetailDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (orderDetailDTO != null)
                        {
                            return Ok(orderDetailDTO);
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
        /// GET: api/OrderDetail/Where="null"/OrderBy="null"/Skip=0/Take=100
        /// </summary>
        /// <param name="where">WHERE</param>
        /// <param name="orderBy">ORDER BY</param>
        /// <param name="skip">SKIP</param>
        /// <param name="take">TAKE</param>
        /// <returns>List[OrderDetailDTO]</returns>
        [Route("{where}/{orderBy}/{skip}/{take}")]
        public IHttpActionResult GetOrderDetails([FromUri] string where = null,
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

                    IEnumerable<OrderDetailDTO> result = Application.Search(operationResult,
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
        /// POST: api/OrderDetail
        /// </summary>
        /// <param name="orderDetailDTO">OrderDetailDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PostOrderDetail([FromBody] OrderDetailDTO orderDetailDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsCreate(operationResult))
                {
                    if (Application.Create(operationResult, orderDetailDTO))
                    {
                        return Ok(orderDetailDTO.ToData().GetId());
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
        /// PUT: api/OrderDetail
        /// </summary>
        /// <param name="orderDetailDTO">OrderDetailDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PutOrderDetail([FromBody] OrderDetailDTO orderDetailDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsUpdate(operationResult))
                {
                    object[] ids = orderDetailDTO.ToData().GetId();
                    OrderDetailDTO dto = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (dto != null)
                        {
                            if (Application.Update(operationResult, orderDetailDTO))
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

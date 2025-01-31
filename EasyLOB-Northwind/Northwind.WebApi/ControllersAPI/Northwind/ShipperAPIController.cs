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
    [RoutePrefix("api/Shipper")]
    public class ShipperAPIController : BaseApiControllerApplicationDTO<ShipperDTO, Shipper>
    {
        #region Methods

        public ShipperAPIController(INorthwindGenericApplicationDTO<ShipperDTO, Shipper> application,
            IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        /// <summary>
        /// DELETE: api/Shipper/1 
        /// </summary>
        /// <param name="shipperId">shipperId</param>
        /// <returns>object[] Ids</returns>
        [Route("{shipperId}")]
        public IHttpActionResult DeleteShipper([FromUri] int shipperId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsDelete(operationResult))
                {
                    object[] ids = new object[] { shipperId };
                    ShipperDTO shipperDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (shipperDTO != null)
                        {
                            if (Application.Delete(operationResult, shipperDTO))
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
        /// GET: api/Shipper/1
        /// </summary>
        /// <param name="shipperId">shipperId</param>
        /// <returns>ShipperDTO</returns>
        [Route("{shipperId}")]
        public IHttpActionResult GetShipper([FromUri] int shipperId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsSearch(operationResult))
                {
                    object[] ids = new object[] { shipperId };
                    ShipperDTO shipperDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (shipperDTO != null)
                        {
                            return Ok(shipperDTO);
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
        /// GET: api/Shipper/Where="null"/OrderBy="null"/Skip=0/Take=100
        /// </summary>
        /// <param name="where">WHERE</param>
        /// <param name="orderBy">ORDER BY</param>
        /// <param name="skip">SKIP</param>
        /// <param name="take">TAKE</param>
        /// <returns>List[ShipperDTO]</returns>
        [Route("{where}/{orderBy}/{skip}/{take}")]
        public IHttpActionResult GetShippers([FromUri] string where = null,
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

                    IEnumerable<ShipperDTO> result = Application.Search(operationResult,
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
        /// POST: api/Shipper
        /// </summary>
        /// <param name="shipperDTO">ShipperDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PostShipper([FromBody] ShipperDTO shipperDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsCreate(operationResult))
                {
                    if (Application.Create(operationResult, shipperDTO))
                    {
                        return Ok(shipperDTO.ToData().GetId());
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
        /// PUT: api/Shipper
        /// </summary>
        /// <param name="shipperDTO">ShipperDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PutShipper([FromBody] ShipperDTO shipperDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsUpdate(operationResult))
                {
                    object[] ids = shipperDTO.ToData().GetId();
                    ShipperDTO dto = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (dto != null)
                        {
                            if (Application.Update(operationResult, shipperDTO))
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

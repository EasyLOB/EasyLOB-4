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
    [RoutePrefix("api/Region")]
    public class RegionAPIController : BaseApiControllerApplicationDTO<RegionDTO, Region>
    {
        #region Methods

        public RegionAPIController(INorthwindGenericApplicationDTO<RegionDTO, Region> application,
            IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        /// <summary>
        /// DELETE: api/Region/1 
        /// </summary>
        /// <param name="regionId">regionId</param>
        /// <returns>object[] Ids</returns>
        [Route("{regionId}")]
        public IHttpActionResult DeleteRegion([FromUri] int regionId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsDelete(operationResult))
                {
                    object[] ids = new object[] { regionId };
                    RegionDTO regionDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (regionDTO != null)
                        {
                            if (Application.Delete(operationResult, regionDTO))
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
        /// GET: api/Region/1
        /// </summary>
        /// <param name="regionId">regionId</param>
        /// <returns>RegionDTO</returns>
        [Route("{regionId}")]
        public IHttpActionResult GetRegion([FromUri] int regionId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsSearch(operationResult))
                {
                    object[] ids = new object[] { regionId };
                    RegionDTO regionDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (regionDTO != null)
                        {
                            return Ok(regionDTO);
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
        /// GET: api/Region/Where="null"/OrderBy="null"/Skip=0/Take=100
        /// </summary>
        /// <param name="where">WHERE</param>
        /// <param name="orderBy">ORDER BY</param>
        /// <param name="skip">SKIP</param>
        /// <param name="take">TAKE</param>
        /// <returns>List[RegionDTO]</returns>
        [Route("{where}/{orderBy}/{skip}/{take}")]
        public IHttpActionResult GetRegions([FromUri] string where = null,
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

                    IEnumerable<RegionDTO> result = Application.Search(operationResult,
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
        /// POST: api/Region
        /// </summary>
        /// <param name="regionDTO">RegionDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PostRegion([FromBody] RegionDTO regionDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsCreate(operationResult))
                {
                    if (Application.Create(operationResult, regionDTO))
                    {
                        return Ok(regionDTO.ToData().GetId());
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
        /// PUT: api/Region
        /// </summary>
        /// <param name="regionDTO">RegionDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PutRegion([FromBody] RegionDTO regionDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsUpdate(operationResult))
                {
                    object[] ids = regionDTO.ToData().GetId();
                    RegionDTO dto = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (dto != null)
                        {
                            if (Application.Update(operationResult, regionDTO))
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

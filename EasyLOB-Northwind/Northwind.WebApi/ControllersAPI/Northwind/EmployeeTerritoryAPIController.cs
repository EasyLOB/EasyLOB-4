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
    [RoutePrefix("api/EmployeeTerritory")]
    public class EmployeeTerritoryAPIController : BaseApiControllerApplicationDTO<EmployeeTerritoryDTO, EmployeeTerritory>
    {
        #region Methods

        public EmployeeTerritoryAPIController(INorthwindGenericApplicationDTO<EmployeeTerritoryDTO, EmployeeTerritory> application,
            IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        /// <summary>
        /// DELETE: api/EmployeeTerritory/1 
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="territoryId">territoryId</param>
        /// <returns>object[] Ids</returns>
        [Route("{employeeId}/{territoryId}")]
        public IHttpActionResult DeleteEmployeeTerritory([FromUri] int employeeId, [FromUri] string territoryId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsDelete(operationResult))
                {
                    object[] ids = new object[] { employeeId, territoryId };
                    EmployeeTerritoryDTO employeeTerritoryDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (employeeTerritoryDTO != null)
                        {
                            if (Application.Delete(operationResult, employeeTerritoryDTO))
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
        /// GET: api/EmployeeTerritory/1
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="territoryId">territoryId</param>
        /// <returns>EmployeeTerritoryDTO</returns>
        [Route("{employeeId}/{territoryId}")]
        public IHttpActionResult GetEmployeeTerritory([FromUri] int employeeId, [FromUri] string territoryId)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsSearch(operationResult))
                {
                    object[] ids = new object[] { employeeId, territoryId };
                    EmployeeTerritoryDTO employeeTerritoryDTO = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (employeeTerritoryDTO != null)
                        {
                            return Ok(employeeTerritoryDTO);
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
        /// GET: api/EmployeeTerritory/Where="null"/OrderBy="null"/Skip=0/Take=100
        /// </summary>
        /// <param name="where">WHERE</param>
        /// <param name="orderBy">ORDER BY</param>
        /// <param name="skip">SKIP</param>
        /// <param name="take">TAKE</param>
        /// <returns>List[EmployeeTerritoryDTO]</returns>
        [Route("{where}/{orderBy}/{skip}/{take}")]
        public IHttpActionResult GetEmployeeTerritories([FromUri] string where = null,
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

                    IEnumerable<EmployeeTerritoryDTO> result = Application.Search(operationResult,
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
        /// POST: api/EmployeeTerritory
        /// </summary>
        /// <param name="employeeTerritoryDTO">EmployeeTerritoryDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PostEmployeeTerritory([FromBody] EmployeeTerritoryDTO employeeTerritoryDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsCreate(operationResult))
                {
                    if (Application.Create(operationResult, employeeTerritoryDTO))
                    {
                        return Ok(employeeTerritoryDTO.ToData().GetId());
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
        /// PUT: api/EmployeeTerritory
        /// </summary>
        /// <param name="employeeTerritoryDTO">EmployeeTerritoryDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PutEmployeeTerritory([FromBody] EmployeeTerritoryDTO employeeTerritoryDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsUpdate(operationResult))
                {
                    object[] ids = employeeTerritoryDTO.ToData().GetId();
                    EmployeeTerritoryDTO dto = Application.GetById(operationResult, ids);
                    if (operationResult.Ok)
                    {
                        if (dto != null)
                        {
                            if (Application.Update(operationResult, employeeTerritoryDTO))
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

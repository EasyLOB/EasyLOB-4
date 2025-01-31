using EasyLOB.AuditTrail.Application;
using EasyLOB.AuditTrail.Data;
using EasyLOB.AuditTrail.Data.Resources;
using EasyLOB;
using EasyLOB.WebApi;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace EasyLOB.AuditTrail.WebApi
{
    [RoutePrefix("api/AuditTrailLog")]
    public class AuditTrailLogAPIController : BaseApiControllerApplicationDTO<AuditTrailLogDTO, AuditTrailLog>
    {
        #region Methods

        public AuditTrailLogAPIController(IAuditTrailGenericApplicationDTO<AuditTrailLogDTO, AuditTrailLog> application,
            IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
            Application = application;
        }

        #endregion Methods

        #region Methods CRUD

        /// <summary>
        /// DELETE: api/AuditTrailLog/1 
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>object[] Ids</returns>
        [Route("{id}")]
        public IHttpActionResult DeleteAuditTrailLog([FromUri] int id)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsDelete(operationResult))
                {
                    object[] ids = new object[] { id };
                    AuditTrailLogDTO auditTrailLogDTO = Application.GetById(operationResult, ids);
                    if (auditTrailLogDTO != null)
                    {
                        if (Application.Delete(operationResult, auditTrailLogDTO))
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
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ActionResultOperationResult(operationResult);
        }

        /// <summary>
        /// GET: api/AuditTrailLog/1
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>AuditTrailLogDTO</returns>
        [Route("{id}")]
        public IHttpActionResult GetAuditTrailLog([FromUri] int id)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsSearch(operationResult))
                {
                    object[] ids = new object[] { id };
                    AuditTrailLogDTO auditTrailLogDTO = Application.GetById(operationResult, ids);
                    if (auditTrailLogDTO != null)
                    {
                        return Ok(auditTrailLogDTO);
                    }
                    else
                    {
                        return Ok((object)null);
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
        /// GET: api/AuditTrailLog/Where="null"/OrderBy="null"/Skip=0/Take=100
        /// </summary>
        /// <param name="where">WHERE</param>
        /// <param name="orderBy">ORDER BY</param>
        /// <param name="skip">SKIP</param>
        /// <param name="take">TAKE</param>
        /// <returns>List[AuditTrailLogDTO]</returns>
        [Route("{where}/{orderBy}/{skip}/{take}")]
        public IHttpActionResult GetAuditTrailLogs([FromUri] string where = null,
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

                    IEnumerable<AuditTrailLogDTO> result = Application.Search(operationResult,
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
        /// POST: api/AuditTrailLog
        /// </summary>
        /// <param name="auditTrailLogDTO">AuditTrailLogDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PostAuditTrailLog([FromBody] AuditTrailLogDTO auditTrailLogDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsCreate(operationResult))
                {
                    if (Application.Create(operationResult, auditTrailLogDTO))
                    {
                        return Ok(auditTrailLogDTO.ToData().GetId());
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
        /// PUT: api/AuditTrailLog
        /// </summary>
        /// <param name="auditTrailLogDTO">AuditTrailLogDTO</param>
        /// <returns>object[] Ids</returns>
        [Route("")]
        public IHttpActionResult PutAuditTrailLog([FromBody] AuditTrailLogDTO auditTrailLogDTO)
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                if (IsUpdate(operationResult))
                {
                    object[] ids = auditTrailLogDTO.ToData().GetId();
                    AuditTrailLogDTO dto = Application.GetById(operationResult, ids);
                    if (dto != null)
                    {
                        if (Application.Update(operationResult, auditTrailLogDTO))
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
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ActionResultOperationResult(operationResult);
        }

        #endregion Methods REST
    }
}

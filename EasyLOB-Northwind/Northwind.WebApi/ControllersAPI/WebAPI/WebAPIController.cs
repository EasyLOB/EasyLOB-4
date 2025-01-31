using System;
using System.Web.Http;

namespace EasyLOB.WebApi
{
    [RoutePrefix("api/WebAPI")]
    public class WebAPIController : BaseApi
    {
        #region Methods

        public WebAPIController()
        {
        }

        // api/WebAPI/Echo/anonymous/VALUE
        [AllowAnonymous]
        [HttpGet]
        [Route("Echo/anonymous/{value}")]
        public string EchoAnonymous(string value)
        {
            return string.Format("{0} {1}", value, DateTime.Now);
        }

        // api/WebAPI/Echo/authorize/VALUE
        [Authorize]
        [HttpGet]
        [Route("Echo/authorize/{value}")]
        public string EchoAuthenticated(string value)
        {
            return string.Format("{0} {1}", value, DateTime.Now);
        }

        // api/WebAPI/Exception/anonymous
        [AllowAnonymous]
        [HttpGet]
        [Route("Exception/anonymous")]
        public IHttpActionResult ExceptionAnonymous()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                throw new Exception(string.Format("Northwind {0}", DateTime.Now));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            //return operationResult;
            return ActionResultOperationResult(operationResult);
        }

        // api/WebAPI/Exception/authorize
        [Authorize]
        [HttpGet]
        [Route("Exception/authorize")]
        public IHttpActionResult ExceptionAuthenticated()
        {
            ZOperationResult operationResult = new ZOperationResult();

            try
            {
                throw new Exception(string.Format("Northwind {0}", DateTime.Now));
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return ActionResultOperationResult(operationResult);
        }

        #endregion Methods
    }
}

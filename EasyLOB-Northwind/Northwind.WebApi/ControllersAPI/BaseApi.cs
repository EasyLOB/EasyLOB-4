using EasyLOB.Environment;
using System.Web.Http;

// !!! Web API

// \App_Start\Security.config

// <httpRuntime targetFramework="4.6" requestPathInvalidCharacters="" requestValidationMode="2.0" />
// <pages validateRequest="false" >

namespace EasyLOB.WebApi
{
    [Authorize]
    public class BaseApi : ApiController
    {
        #region Methods

        protected ZActionResultOperationResult ActionResultOperationResult(ZOperationResult operationResult)
        {
            AppHelper.Log(operationResult, Request.RequestUri.PathAndQuery);

            return new ZActionResultOperationResult(Request, operationResult);
        }

        #endregion Methods
    }
}
using System.Collections.Generic;
using System.Web.Mvc;

/*
ModelState.AddModelError(string.Empty, "Error");
ModelState.AddModelError("Property","Error");

ZOperationResult operationResult = new ZOperationResult();
operationResult.AddOperationError("", "Error");

operationResult.AddModelStateErrors(ModelState);
*/

namespace EasyLOB
{
    public static partial class ZOperationResultExtensions
    {
        public static void AddModelStateErrors(this ZOperationResult operationResult, ModelStateDictionary modelState)
        {
            foreach (KeyValuePair<string, ModelState> kv in modelState)
            {
                foreach (ModelError modelError in kv.Value.Errors)
                {
                    operationResult.AddOperationError("", modelError.ErrorMessage);
                }
            }
        }
    }
}






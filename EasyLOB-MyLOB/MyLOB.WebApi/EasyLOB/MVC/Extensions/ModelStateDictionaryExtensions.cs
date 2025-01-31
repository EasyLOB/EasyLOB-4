using System.Web.Mvc;

/*
ModelState.AddModelError(string.Empty, "Error");
ModelState.AddModelError("Property","Error");

ZOperationResult operationResult = new ZOperationResult();
operationResult.AddOperationError("Error");

ModelState.AddOperationResultErrors(operationResult, "Entity")
*/

namespace EasyLOB
{
    public static class ModelStateDictionaryExtensions
    {
        public static void AddOperationResults(this ModelStateDictionary modelStateDictionary,
            ZOperationResult operationResult, string entity)
        {
            entity = string.IsNullOrEmpty(entity) ? "" : entity + ".";

            if (!string.IsNullOrEmpty(operationResult.ErrorMessage))
            {
                modelStateDictionary.AddModelError(string.Empty, operationResult.ErrorMessage);
            }

            foreach (ZOperationError operationError in operationResult.OperationErrors)
            {
                if (operationError.ErrorMembers.Count > 0)
                {
                    foreach (string member in operationError.ErrorMembers)
                    {
                        modelStateDictionary.AddModelError(entity + member, operationError.ErrorMessage); // Entity.Member
                    }
                }
                else
                {
                    modelStateDictionary.AddModelError(string.Empty, operationError.ErrorMessage);
                }
            }
        }
    }
}
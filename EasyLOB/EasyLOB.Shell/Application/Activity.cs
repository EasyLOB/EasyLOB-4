using EasyLOB.Activity;
using EasyLOB.Activity.Data;
using EasyLOB.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void ApplicationActivityDemo()
        {
            Console.WriteLine("\nApplication Activity Demo\n");

            ApplicationActivityData<EasyLOB.Activity.Data.Activity>();
            ApplicationActivityDTO<ActivityDTO, EasyLOB.Activity.Data.Activity>();

            ApplicationActivityData<ActivityRole>();
            ApplicationActivityDTO<ActivityRoleDTO, ActivityRole>();
        }

        private static void ApplicationActivityData<TEntity>()
            where TEntity : ZDataModel
        {
            IActivityGenericApplication<TEntity> application =
                EasyLOBHelper.GetService<IActivityGenericApplication<TEntity>>();
            ZOperationResult operationResult = new ZOperationResult();
            List<TEntity> enumerable = application.SearchAll(operationResult);
            Console.WriteLine(typeof(TEntity).Name + ": {0}", enumerable.Count());
        }

        private static void ApplicationActivityDTO<TEntityDTO, TEntity>()
            where TEntityDTO : ZDTOModel<TEntityDTO, TEntity>
            where TEntity : ZDataModel
        {
            IActivityGenericApplicationDTO<TEntityDTO, TEntity> application =
                EasyLOBHelper.GetService<IActivityGenericApplicationDTO<TEntityDTO, TEntity>>();
            ZOperationResult operationResult = new ZOperationResult();
            List<TEntityDTO> enumerable = application.SearchAll(operationResult);
            Console.WriteLine(typeof(TEntity).Name + "DTO: {0}", enumerable.Count());
        }
    }
}
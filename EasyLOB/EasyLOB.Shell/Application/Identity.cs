using EasyLOB.Identity;
using EasyLOB.Identity.Data;
using EasyLOB.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void ApplicationIdentityDemo()
        {
            Console.WriteLine("\nApplication Identity Demo\n");

            ApplicationIdentityData<Role>();
            ApplicationIdentityDTO<RoleDTO, Role>();

            ApplicationIdentityData<UserClaim>();
            ApplicationIdentityDTO<UserClaimDTO, UserClaim>();

            ApplicationIdentityData<UserLogin>();
            ApplicationIdentityDTO<UserLoginDTO, UserLogin>();

            ApplicationIdentityData<UserRole>();
            ApplicationIdentityDTO<UserRoleDTO, UserRole>();

            ApplicationIdentityData<User>();
            ApplicationIdentityDTO<UserDTO, User>();
        }

        private static void ApplicationIdentityData<TEntity>()
            where TEntity : ZDataModel
        {
            IIdentityGenericApplication<TEntity> application =
                EasyLOBHelper.GetService<IIdentityGenericApplication<TEntity>>();
            ZOperationResult operationResult = new ZOperationResult();
            List<TEntity> enumerable = application.SearchAll(operationResult);
            Console.WriteLine(typeof(TEntity).Name + ": {0}", enumerable.Count());
        }

        private static void ApplicationIdentityDTO<TEntityDTO, TEntity>()
            where TEntityDTO : ZDTOModel<TEntityDTO, TEntity>
            where TEntity : ZDataModel
        {
            IIdentityGenericApplicationDTO<TEntityDTO, TEntity> application =
                EasyLOBHelper.GetService<IIdentityGenericApplicationDTO<TEntityDTO, TEntity>>();
            ZOperationResult operationResult = new ZOperationResult();
            IEnumerable<TEntityDTO> enumerable = application.SearchAll(operationResult);
            Console.WriteLine(typeof(TEntity).Name + "DTO: {0}", enumerable.Count());
        }
    }
}
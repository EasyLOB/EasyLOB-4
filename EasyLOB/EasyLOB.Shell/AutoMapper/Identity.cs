using EasyLOB.Identity.Data;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void AutoMapperIdentityDemo()
        {
            Console.WriteLine("\nApplication Identity DTO -> Data -> DTO\n");

            {
                Console.WriteLine("Role");
                Role data = new Role();
                RoleDTO dto = EasyLOBHelper.Mapper.Map<RoleDTO>(data);
                data = EasyLOBHelper.Mapper.Map<Role>(dto);
            }

            {
                Console.WriteLine("UserClaim");
                UserClaim data = new UserClaim();
                UserClaimDTO dto = EasyLOBHelper.Mapper.Map<UserClaimDTO>(data);
                data = EasyLOBHelper.Mapper.Map<UserClaim>(dto);
            }

            {
                Console.WriteLine("UserLogim");
                UserLogin data = new UserLogin();
                UserLoginDTO dto = EasyLOBHelper.Mapper.Map<UserLoginDTO>(data);
                data = EasyLOBHelper.Mapper.Map<UserLogin>(dto);
            }

            {
                Console.WriteLine("UserRole");
                UserRole data = new UserRole();
                UserRoleDTO dto = EasyLOBHelper.Mapper.Map<UserRoleDTO>(data);
                data = EasyLOBHelper.Mapper.Map<UserRole>(dto);
            }

            {
                Console.WriteLine("User");
                User data = new User();
                UserDTO dto = EasyLOBHelper.Mapper.Map<UserDTO>(data);
                data = EasyLOBHelper.Mapper.Map<User>(dto);
            }
        }
    }
}

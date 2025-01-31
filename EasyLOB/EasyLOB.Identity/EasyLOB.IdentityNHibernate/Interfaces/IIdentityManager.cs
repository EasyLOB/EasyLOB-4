using EasyLOB.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLOB
{
    public interface IIdentityManager
    {
        #region Properties

        //RoleManager<ApplicationRole> AppRoleManager { get; }

        //UserManager<ApplicationUser> AppUserManager { get; }

        ApplicationRoleManager AppRoleManager { get; }

        ApplicationUserManager AppUserManager { get; }

        ApplicationSignInManager AppSignInManager { get; }

        #endregion Properties

        #region Roles

        bool CreateRole(ZOperationResult operationResult,
            string name);

        Task<bool> CreateRoleAsync(ZOperationResult operationResult,
            string name);

        bool DeleteRole(ZOperationResult operationResult,
            string id);

        Task<bool> DeleteRoleAsync(ZOperationResult operationResult,
            string id);

        ApplicationRole GetRoleById(string id);

        Task<ApplicationRole> GetRoleByIdAsync(string id);

        ApplicationRole GetRoleByName(string name);

        Task<ApplicationRole> GetRoleByNameAsync(string name);

        IQueryable<ApplicationRole> GetRoles();

        bool UpdateRole(ZOperationResult operationResult,
            string id, string name);

        Task<bool> UpdateRoleAsync(ZOperationResult operationResult,
            string id, string name);

        #endregion Roles

        #region Users

        bool AddUserToRole(ZOperationResult operationResult,
            string id, string role);

        Task<bool> AddUserToRoleAsync(ZOperationResult operationResult,
            string id, string role);

        bool AddUserToRoles(ZOperationResult operationResult,
            string id, string[] roles);

        Task<bool> AddUserToRolesAsync(ZOperationResult operationResult,
            string id, string[] roles);

        bool CreateUser(ZOperationResult operationResult,
            string name, string email, string password, string[] roles);

        Task<bool> CreateUserAsync(ZOperationResult operationResult,
            string name, string email, string password, string[] roles);

        bool DeleteUser(ZOperationResult operationResult,
            string id);

        Task<bool> DeleteUserAsync(ZOperationResult operationResult,
            string id);

        ApplicationUser GetUserById(string id);

        Task<ApplicationUser> GetUserByIdAsync(string id);

        ApplicationUser GetUserByEmail(string email);

        Task<ApplicationUser> GetUserByEmailAsync(string email);

        ApplicationUser GetUserByName(string name);

        Task<ApplicationUser> GetUserByNameAsync(string name);

        IList<string> GetUserRoles(string name);

        Task<IList<string>> GetUserRolesAsync(string name);

        IQueryable<ApplicationUser> GetUsers();

        bool RemoveUserFromRole(ZOperationResult operationResult,
            string id, string role);

        Task<bool> RemoveUserFromRoleAsync(ZOperationResult operationResult,
            string id, string role);

        bool RemoveUserFromRoles(ZOperationResult operationResult,
            string id, string[] roles);

        Task<bool> RemoveUserFromRolesAsync(ZOperationResult operationResult,
            string id, string[] roles);

        bool UpdateUser(ZOperationResult operationResult,
            string id, string emaild, DateTime? lockoutEndDate, bool lockoutEnable);

        Task<bool> UpdateUserAsync(ZOperationResult operationResult,
            string id, string email, DateTime? lockoutEndDate, bool lockoutEnabled);

        #endregion Methods

        #region Roles X Users

        Dictionary<string, string> GetRolesUsers();

        Task<Dictionary<string, string>> GetRolesUsersAsync();

        #endregion Roles X Users
    }
}
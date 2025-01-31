using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EasyLOB.Identity
{
    public class IdentityManagerNH : IIdentityManager
    {
        #region Properties

        private ApplicationRoleManager _appRoleManager = null;

        public ApplicationRoleManager AppRoleManager
        {
            get
            {
                // System.ObjectDisposedException: Cannot access a disposed object
                // http://stackoverflow.com/questions/27337599/cannot-access-a-disposed-object-after-minor-code-modification
                //if (_appRoleManager == null) // ???
                //{
                IOwinContext owinContext = HttpContext.Current.GetOwinContext();
                _appRoleManager = owinContext.GetUserManager<ApplicationRoleManager>();
                //}

                return _appRoleManager;
            }
        }

        private ApplicationUserManager _appUserManager = null;

        public ApplicationUserManager AppUserManager
        {
            get
            {
                // System.ObjectDisposedException: Cannot access a disposed object
                // http://stackoverflow.com/questions/27337599/cannot-access-a-disposed-object-after-minor-code-modification
                //if (_appUserManager == null) // ???
                //{
                IOwinContext owinContext = HttpContext.Current.GetOwinContext();
                _appUserManager = owinContext.GetUserManager<ApplicationUserManager>();
                //}

                return _appUserManager;
            }
        }

        private ApplicationSignInManager _appSignInManager = null;

        public ApplicationSignInManager AppSignInManager
        {
            get
            {
                // System.ObjectDisposedException: Cannot access a disposed object
                // http://stackoverflow.com/questions/27337599/cannot-access-a-disposed-object-after-minor-code-modification
                //if (_appSignInManager == null) // ???
                //{
                IOwinContext owinContext = HttpContext.Current.GetOwinContext();
                _appSignInManager = owinContext.GetUserManager<ApplicationSignInManager>();
                //}

                return _appSignInManager;
            }
        }

        #endregion Properties

        #region Methods

        public IdentityManagerNH()
        {
        }

        #endregion Methods

        #region Roles

        public bool CreateRole(ZOperationResult operationResult,
            string name)
        {
            ApplicationRole role = new ApplicationRole
            {
                Name = name
            };
            IdentityResult identityResult = AppRoleManager.Create(role);
            if (!identityResult.Succeeded)
            {
                operationResult.ParseIdentityResult(identityResult);
            }

            return operationResult.Ok;
        }

        public async Task<bool> CreateRoleAsync(ZOperationResult operationResult,
            string name)
        {
            ApplicationRole role = new ApplicationRole
            {
                Name = name
            };
            IdentityResult identityResult = await AppRoleManager.CreateAsync(role);
            if (!identityResult.Succeeded)
            {
                operationResult.ParseIdentityResult(identityResult);
            }

            return operationResult.Ok;
        }

        public bool DeleteRole(ZOperationResult operationResult,
            string id)
        {
            ApplicationRole role = AppRoleManager.FindById(id);
            if (role != null)
            {
                IdentityResult identityResult = AppRoleManager.Delete(role);
                if (!identityResult.Succeeded)
                {
                    operationResult.ParseIdentityResult(identityResult);
                }
            }
            else
            {
                operationResult.AddOperationError("", "DeleteRole");
            }

            return operationResult.Ok;
        }

        public async Task<bool> DeleteRoleAsync(ZOperationResult operationResult,
            string id)
        {
            ApplicationRole role = await AppRoleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult identityResult = await AppRoleManager.DeleteAsync(role);
                if (!identityResult.Succeeded)
                {
                    operationResult.ParseIdentityResult(identityResult);
                }
            }
            else
            {
                operationResult.AddOperationError("", "DeleteRoleAsync");
            }

            return operationResult.Ok;
        }

        public ApplicationRole GetRoleById(string id)
        {
            return AppRoleManager.FindById(id);
        }

        public async Task<ApplicationRole> GetRoleByIdAsync(string id)
        {
            return await AppRoleManager.FindByIdAsync(id);
        }

        public ApplicationRole GetRoleByName(string name)
        {
            return AppRoleManager.FindByName(name);
        }

        public async Task<ApplicationRole> GetRoleByNameAsync(string name)
        {
            return await AppRoleManager.FindByNameAsync(name);
        }

        public IQueryable<ApplicationRole> GetRoles()
        {
            return AppRoleManager.Roles;
        }

        public bool UpdateRole(ZOperationResult operationResult,
            string id, string name)
        {
            ApplicationRole role = GetRoleById(id);
            if (role != null)
            {
                role.Name = name;
                IdentityResult result = AppRoleManager.Update(role);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "UpdateRole");
            }

            return operationResult.Ok;
        }

        public async Task<bool> UpdateRoleAsync(ZOperationResult operationResult,
            string id, string name)
        {
            ApplicationRole role = await GetRoleByIdAsync(id);
            if (role != null)
            {
                role.Name = name;
                IdentityResult result = await AppRoleManager.UpdateAsync(role);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "UpdateRoleAsync");
            }

            return operationResult.Ok;
        }

        #endregion Roles

        #region Users

        public bool AddUserToRole(ZOperationResult operationResult,
            string id, string role)
        {
            ApplicationUser user = GetUserById(id);
            if (user != null)
            {
                IdentityResult result = AppUserManager.AddToRole(user.Id, role);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "AddUserToRole");
            }

            return operationResult.Ok;
        }

        public async Task<bool> AddUserToRoleAsync(ZOperationResult operationResult,
            string id, string role)
        {
            ApplicationUser user = await GetUserByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await AppUserManager.AddToRoleAsync(user.Id, role);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "AddUserToRoleAsync");
            }

            return operationResult.Ok;
        }

        public bool AddUserToRoles(ZOperationResult operationResult,
            string id, string[] roles)
        {
            ApplicationUser user = GetUserById(id);
            if (user != null)
            {
                IdentityResult result = AppUserManager.AddToRoles(user.Id, roles);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "AddUserToRoles");
            }

            return operationResult.Ok;
        }

        public async Task<bool> AddUserToRolesAsync(ZOperationResult operationResult,
            string id, string[] roles)
        {
            ApplicationUser user = await GetUserByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await AppUserManager.AddToRolesAsync(user.Id, roles);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "AddUserToRolesAsync");
            }

            return operationResult.Ok;
        }

        public bool CreateUser(ZOperationResult operationResult,
            string name, string email, string password, string[] roles)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = name,
                Email = email
            };
            IdentityResult result = AppUserManager.Create(user, password);
            if (result.Succeeded)
            {
                foreach (string role in roles)
                {
                    result = AppUserManager.AddToRole(user.Id, role);
                    if (!result.Succeeded)
                    {
                        operationResult.ParseIdentityResult(result);

                        break;
                    }
                }
            }
            else
            {
                operationResult.ParseIdentityResult(result);
            }

            return operationResult.Ok;
        }

        public async Task<bool> CreateUserAsync(ZOperationResult operationResult,
            string name, string email, string password, string[] roles)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = name,
                Email = email
            };
            IdentityResult result = await AppUserManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                foreach (string role in roles)
                {
                    result = await AppUserManager.AddToRoleAsync(user.Id, role);
                    if (!result.Succeeded)
                    {
                        operationResult.ParseIdentityResult(result);

                        break;
                    }
                }
            }
            else
            {
                operationResult.ParseIdentityResult(result);
            }

            return operationResult.Ok;
        }

        public bool DeleteUser(ZOperationResult operationResult,
            string id)
        {
            ApplicationUser user = GetUserById(id);
            if (user != null)
            {
                IdentityResult result = AppUserManager.Delete(user);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "DeleteUser");
            }

            return operationResult.Ok;
        }

        public async Task<bool> DeleteUserAsync(ZOperationResult operationResult,
            string id)
        {
            ApplicationUser user = await GetUserByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await AppUserManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "DeleteUserAsync");
            }

            return operationResult.Ok;
        }

        public ApplicationUser GetUserById(string id)
        {
            return AppUserManager.FindById(id);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            return await AppUserManager.FindByIdAsync(id);
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            return AppUserManager.FindByEmail(email);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await AppUserManager.FindByEmailAsync(email);
        }

        public ApplicationUser GetUserByName(string name)
        {
            return AppUserManager.FindByName(name);
        }

        public async Task<ApplicationUser> GetUserByNameAsync(string name)
        {
            return await AppUserManager.FindByNameAsync(name);
        }

        public IList<string> GetUserRoles(string name)
        {
            IList<string> result = new List<string>();

            ApplicationUser user = GetUserByName(name);
            if (user != null)
            {
                result = AppUserManager.GetRoles(user.Id);
            }

            return result;
        }

        public async Task<IList<string>> GetUserRolesAsync(string name)
        {
            IList<string> result = new List<string>();

            ApplicationUser user = GetUserByName(name);
            if (user != null)
            {
                result = await AppUserManager.GetRolesAsync(user.Id);
            }

            return result;
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return AppUserManager.Users;
        }

        public bool RemoveUserFromRole(ZOperationResult operationResult,
            string id, string role)
        {
            ApplicationUser user = GetUserById(id);
            if (user != null)
            {
                IdentityResult result = AppUserManager.RemoveFromRole(user.Id, role);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "RemoveUserFromRole");
            }

            return operationResult.Ok;
        }

        public async Task<bool> RemoveUserFromRoleAsync(ZOperationResult operationResult,
            string id, string role)
        {
            ApplicationUser user = await GetUserByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await AppUserManager.RemoveFromRoleAsync(user.Id, role);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "RemoveUserFromRoleAsync");
            }

            return operationResult.Ok;
        }

        public bool RemoveUserFromRoles(ZOperationResult operationResult,
            string id, string[] roles)
        {
            ApplicationUser user = GetUserById(id);
            if (user != null)
            {
                IdentityResult result = AppUserManager.RemoveFromRoles(user.Id, roles);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "RemoveUserFromRoles");
            }

            return operationResult.Ok;
        }

        public async Task<bool> RemoveUserFromRolesAsync(ZOperationResult operationResult,
            string id, string[] roles)
        {
            ApplicationUser user = await GetUserByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await AppUserManager.RemoveFromRolesAsync(user.Id, roles);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "RemoveUserFromRolesAsync");
            }

            return operationResult.Ok;
        }

        public bool UpdateUser(ZOperationResult operationResult,
            string id, string email, DateTime? lockoutEndDate, bool lockoutEnabled)
        {
            ApplicationUser user = GetUserById(id);
            if (user != null)
            {
                DateTime? lockoutEndDateUtc;
                if (!lockoutEnabled)
                {
                    lockoutEndDateUtc = null;
                }
                else
                {
                    lockoutEndDateUtc = lockoutEndDate ?? DateTime.Now.AddYears(1);
                    //lockoutEndDateUtc = (lockoutEndDate ?? DateTime.Now.AddYears(1)).ToUniversalTime();
                }

                user.Email = email;
                user.LockoutEndDateUtc = lockoutEndDateUtc;
                user.LockoutEnabled = lockoutEnabled;
                IdentityResult result = AppUserManager.Update(user);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "UpdateUserAsync");
            }

            return operationResult.Ok;
        }

        public async Task<bool> UpdateUserAsync(ZOperationResult operationResult,
            string id, string email, DateTime? lockoutEndDate, bool lockoutEnabled)
        {
            ApplicationUser user = await GetUserByIdAsync(id);
            if (user != null)
            {
                DateTime? lockoutEndDateUtc;
                if (!lockoutEnabled)
                {
                    lockoutEndDateUtc = null;
                }
                else
                {
                    lockoutEndDateUtc = lockoutEndDate ?? DateTime.Now.AddYears(1);
                    //lockoutEndDateUtc = (lockoutEndDate ?? DateTime.Now.AddYears(1)).ToUniversalTime();
                }

                user.Email = email;
                user.LockoutEndDateUtc = lockoutEndDateUtc;
                user.LockoutEnabled = lockoutEnabled;
                IdentityResult result = await AppUserManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    operationResult.ParseIdentityResult(result);
                }
            }
            else
            {
                operationResult.AddOperationError("", "UpdateUserAsync");
            }

            return operationResult.Ok;
        }

        #endregion Methods

        #region Roles X Users

        public Dictionary<string, string> GetRolesUsers()
        {
            Dictionary<string, string> rolesUsers = new Dictionary<string, string>();

            foreach (ApplicationUser user in GetUsers())
            {
                foreach (string role in GetUserRoles(user.UserName))
                {
                    rolesUsers.Add(role, user.UserName);
                }
            }

            return rolesUsers;
        }

        public async Task<Dictionary<string, string>> GetRolesUsersAsync()
        {
            Dictionary<string, string> rolesUsers = new Dictionary<string, string>();

            foreach (ApplicationUser user in GetUsers())
            {
                foreach (string role in await GetUserRolesAsync(user.UserName))
                {
                    rolesUsers.Add(role, user.UserName);
                }
            }

            return rolesUsers;
        }

        #endregion Roles X Users
    }
}
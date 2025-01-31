using EasyLOB.Activity;
using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Identity;
using EasyLOB.Identity.Data;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DemoDI()
        {
            Console.WriteLine("\nDI Demo");

            try
            {
                {

                    // Activity

                    Console.WriteLine();

                    IActivityGenericApplication<EasyLOB.Activity.Data.Activity> application =
                        EasyLOBHelper.GetService<IActivityGenericApplication<EasyLOB.Activity.Data.Activity>>();
                    Console.WriteLine(application.ToString());

                    IActivityGenericApplicationDTO<EasyLOB.Activity.Data.ActivityDTO, EasyLOB.Activity.Data.Activity> applicationDTO =
                        EasyLOBHelper.GetService<IActivityGenericApplicationDTO<EasyLOB.Activity.Data.ActivityDTO, EasyLOB.Activity.Data.Activity>>();
                    Console.WriteLine(applicationDTO.ToString());

                    IUnitOfWork unitOfWork =
                        EasyLOBHelper.GetService<IActivityUnitOfWork>();
                    Console.WriteLine(unitOfWork.ToString());

                    IActivityGenericRepository<EasyLOB.Activity.Data.Activity> repository =
                        EasyLOBHelper.GetService<IActivityGenericRepository<EasyLOB.Activity.Data.Activity>>();
                    Console.WriteLine(repository.ToString());
                }

                {

                    // AuditTrail

                    Console.WriteLine();

                    IAuditTrailGenericApplication<AuditTrailConfiguration> application =
                        EasyLOBHelper.GetService<IAuditTrailGenericApplication<AuditTrailConfiguration>>();
                    Console.WriteLine(application.ToString());

                    IAuditTrailGenericApplicationDTO<AuditTrailConfigurationDTO, AuditTrailConfiguration> applicationDTO =
                        EasyLOBHelper.GetService<IAuditTrailGenericApplicationDTO<AuditTrailConfigurationDTO, AuditTrailConfiguration>>();
                    Console.WriteLine(applicationDTO.ToString());

                    IUnitOfWork unitOfWork =
                        EasyLOBHelper.GetService<IAuditTrailUnitOfWork>();
                    Console.WriteLine(unitOfWork.ToString());

                    IAuditTrailGenericRepository<AuditTrailConfiguration> repository =
                        EasyLOBHelper.GetService<IAuditTrailGenericRepository<AuditTrailConfiguration>>();
                    Console.WriteLine(repository.ToString());
                }


                {

                    // Identity

                    Console.WriteLine();

                    IIdentityGenericApplication<User> application =
                        EasyLOBHelper.GetService<IIdentityGenericApplication<User>>();
                    Console.WriteLine(application.ToString());

                    IIdentityGenericApplicationDTO<UserDTO, User> applicationDTO =
                        EasyLOBHelper.GetService<IIdentityGenericApplicationDTO<UserDTO, User>>();
                    Console.WriteLine(applicationDTO.ToString());

                    IUnitOfWork unitOfWork =
                        EasyLOBHelper.GetService<IIdentityUnitOfWork>();
                    Console.WriteLine(unitOfWork.ToString());

                    IIdentityGenericRepository<User> repository =
                        EasyLOBHelper.GetService<IIdentityGenericRepository<User>>();
                    Console.WriteLine(repository.ToString());

                    Console.WriteLine();

                    ZOperationResult operationResult = new ZOperationResult();
                    User user = application.Get(operationResult, x => x.UserName.ToLower() == "administrator");
                    Console.WriteLine(user.UserName);
                }
            }
            catch (Exception exception)
            {
                WriteHelper.WriteException(exception);
            }
        }
    }
}
using NHibernate.AdoNet;
using NHibernate.Driver;
using System.Data;

namespace EasyLOB.Identity
{
    public class SqlClientDriverEasyLOB : SqlClientDriver, IEmbeddedBatcherFactoryProvider // ???
    {
        // This method is similar to the OnBeforePrepare(IDbCommand) but, instead be called just before execute the command(that can be a batch) is executed before add each single command to the batcher and before OnBeforePrepare(IDbCommand).
        // If you have to adjust parameters values/type(when the command is full filled) this is a good place where do it.
        //public override void AdjustCommand(IDbCommand command)
        //{
        //    base.AdjustCommand(command);
        //}

        protected override void OnBeforePrepare(IDbCommand command)
        {
            command.CommandText = command.CommandText
                .Replace(" ApplicationUser", " AspNetUsers")
                .Replace(" ApplicationRole", " AspNetRoles");
            base.OnBeforePrepare(command);
        }
    }
}
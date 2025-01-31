using System;

namespace MyLOB
{
    public interface IMyLOBApplication : IDisposable
    {
        #region Properties

        IMyLOBUnitOfWork UnitOfWork { get; }

        #endregion Properties
    }
}
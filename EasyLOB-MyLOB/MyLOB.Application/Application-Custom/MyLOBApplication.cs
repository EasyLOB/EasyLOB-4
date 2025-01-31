using System;

namespace MyLOB.Application
{
    public partial class MyLOBApplication : IMyLOBApplication
    {
        #region Properties

        public IMyLOBUnitOfWork UnitOfWork { get; }

        #endregion Properties

        #region Methods

        public MyLOBApplication(IMyLOBUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion Methods

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose
    }
}
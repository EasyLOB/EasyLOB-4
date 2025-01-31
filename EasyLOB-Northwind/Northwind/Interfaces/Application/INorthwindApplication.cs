using System;

namespace Northwind
{
    public interface INorthwindApplication : IDisposable
    {
        #region Properties

        INorthwindUnitOfWork UnitOfWork { get; }

        #endregion Properties
    }
}
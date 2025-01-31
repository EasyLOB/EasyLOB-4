using Autofac;

namespace EasyLOB
{
    public partial class DIManagerAutofac : IDIManager
    {
        #region Properties

        private IContainer Container { get; set; }

        #endregion Properties

        #region Methods

        public DIManagerAutofac(IContainer container)
        {
            Container = container;
        }

        public T GetService<T>()
        {
            return Container.Resolve<T>();
        }

        #endregion
    }
}
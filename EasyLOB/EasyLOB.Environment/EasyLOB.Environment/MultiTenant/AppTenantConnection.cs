namespace EasyLOB.Environment
{
    public class AppTenantConnection
    {
        #region Properties

        public string Name { get; set; } = "";

        public string ConnectionName { get; set; } = "";

        #endregion Properties

        #region Methods

        public AppTenantConnection()
        {
            Name = "";
            ConnectionName = "";
        }

        #endregion Methods
    }
}
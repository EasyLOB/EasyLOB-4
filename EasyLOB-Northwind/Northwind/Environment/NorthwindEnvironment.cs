namespace Northwind
{
    public class NorthwindEnvironment
    {
        #region Properties

        public string Application { get; set; }

        #endregion Properties

        #region Methods

        public NorthwindEnvironment()
        {
            Application = "Northwind";
        }

        #endregion Methods
    }
}
using EasyLOB;

namespace Northwind
{
    public static class NorthwindEnvironmentHelper
    {
        #region Fields

        private static string _sessionName = "EasyLOB.NorthwindEnvironment";

        #endregion Fields

        #region Properties

        public static NorthwindEnvironment Environment
        {
            get
            {
                // ???
                // Unable to cast object of type 'Newtonsoft.Json.Linq.JObject' to type 'EasyLOB.Environment.AppEnvironment'.
                //AppEnvironment environment = (NorthwindEnvironment)EnvironmentManager.SessionRead(_sessionName);
                NorthwindEnvironment environment = EnvironmentManager.SessionRead<NorthwindEnvironment>(_sessionName);

                return environment ?? new NorthwindEnvironment();
            }
        }

        private static IEnvironmentManager EnvironmentManager { get; set; }

        #endregion Properties

        #region Methods

        public static void Setup(IEnvironmentManager environmentManager)
        {
            EnvironmentManager = environmentManager;
        }

        public static void Login(INorthwindUnitOfWork unitOfWork)
        {
            NorthwindEnvironment environment = Environment;
            if (environment == null)
            {
                environment = new NorthwindEnvironment();

                EnvironmentManager.SessionWrite(_sessionName, environment);
            }
        }

        #endregion Methods
    }
}
using EasyLOB;

namespace MyLOB
{
    public static class MyLOBEnvironmentHelper
    {
        #region Fields

        private static string _sessionName = "EasyLOB.MyLOBEnvironment";

        #endregion Fields

        #region Properties

        public static MyLOBEnvironment Environment
        {
            get
            {
                // ???
                // Unable to cast object of type 'Newtonsoft.Json.Linq.JObject' to type 'EasyLOB.Environment.AppEnvironment'.
                //AppEnvironment environment = (MyLOBEnvironment)EnvironmentManager.SessionRead(_sessionName);
                MyLOBEnvironment environment = EnvironmentManager.SessionRead<MyLOBEnvironment>(_sessionName);

                return environment ?? new MyLOBEnvironment();
            }
        }

        private static IEnvironmentManager EnvironmentManager { get; set; }

        #endregion Properties

        #region Methods

        public static void Setup(IEnvironmentManager environmentManager)
        {
            EnvironmentManager = environmentManager;
        }

        public static void Login(IMyLOBUnitOfWork unitOfWork)
        {
            MyLOBEnvironment environment = Environment;
            if (environment == null)
            {
                environment = new MyLOBEnvironment();

                EnvironmentManager.SessionWrite(_sessionName, environment);
            }
        }

        #endregion Methods
    }
}
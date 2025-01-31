namespace EasyLOB
{
    /// <summary>
    /// IEnvironmentManager.
    /// </summary>
    public interface IEnvironmentManager
    {
        #region Properties Application

        /// <summary>
        /// Application directory.
        /// </summary>
        string ApplicationDirectory { get; }

        /// <summary>
        /// Is Web ?
        /// </summary>
        bool IsWeb { get; }

        /// <summary>
        /// Web path.
        /// </summary>
        string WebPath { get; }

        /// <summary>
        /// Web URL.
        /// </summary>
        string WebUrl { get; }

        /// <summary>
        /// Web domain.
        /// </summary>
        string WebDomain { get; }

        /// <summary>
        /// Web sub-domain.
        /// </summary>
        string WebSubDomain { get; }

        #endregion Properties Application

        #region Methods Application

        /// <summary>
        /// Application path.
        /// </summary>
        /// <param name="path">Path</param>
        /// <returns></returns>
        string ApplicationPath(string path);

        #endregion Methods Application

        #region Methods Session

        /// <summary>
        /// Abandon session.
        /// </summary>
        void SessionAbandon();

        /// <summary>
        /// Clear session.
        /// </summary>
        void SessionClear();

        /// <summary>
        /// Clear session by name.
        /// </summary>
        /// <param name="sessionName">Session name</param>
        void SessionClear(string sessionName);

        /// <summary>
        /// Read session by name.
        /// </summary>
        /// <param name="sessionName">Session name</param>
        /// <returns></returns>
        object SessionRead(string sessionName);

        /// <summary>
        /// Read session by name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sessionName"></param>
        /// <returns></returns>
        T SessionRead<T>(string sessionName);

        /// <summary>
        /// Write session by name.
        /// </summary>
        /// <param name="sessionName"></param>
        /// <param name="value"></param>
        void SessionWrite(string sessionName, object value);

        /// <summary>
        /// Write session by name.
        /// </summary>
        /// <param name="sessionName"></param>
        /// <param name="value"></param>
        void SessionWrite<T>(string sessionName, T value);

        #endregion Methods Session
    }
}

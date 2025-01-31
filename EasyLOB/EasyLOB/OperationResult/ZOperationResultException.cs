using System;

namespace EasyLOB
{    
    /// <summary>
    /// Z Operation Result Exception.
    /// </summary>
    public class ZOperationResultException : Exception
    {
        #region Properties

        private string _stackTrace;

        /// <summary>
        /// Stack Trace.
        /// </summary>
        public override string StackTrace
        {
            get
            {
                return this._stackTrace;
            }
        }

        #endregion Properties

        #region Methods

        public ZOperationResultException(string message, string stackTrace)
            : base(message)
        {
            this._stackTrace = stackTrace;
        }

        #endregion Methods
    }
}
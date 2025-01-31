using System.Collections.Generic;

namespace EasyLOB.Mvc
{
    public class ProfileViewerViewModel : TaskViewModel
    {
        #region Properties

        public Dictionary<string, string> Entities { get; set; }

        #endregion Properties

        #region Methods

        public ProfileViewerViewModel()
        {
            OnConstructor();
        }

        public ProfileViewerViewModel(string controller, string action, string task)
            : this()
        {
            OnConstructor();

            Controller = controller;
            Action = action;
            Task = task;
        }

        private void OnConstructor()
        {
            Entities = new Dictionary<string, string>();
        }

        #endregion Methods
    }
}
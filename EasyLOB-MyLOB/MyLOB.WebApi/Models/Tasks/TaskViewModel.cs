using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EasyLOB.Mvc
{
    public class TaskViewModel : IValidatableObject, IZValidatableObject
    {
        #region Properties

        public ZOperationResult OperationResult { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Task { get; set; }

        #endregion Properties

        #region Methods

        public TaskViewModel()
        {
            OperationResult = new ZOperationResult();
            Controller = "";
            Action = "";
            Task = "";
        }

        public TaskViewModel(string controller, string action, string task)
            : this()
        {
            Controller = controller;
            Action = action;
            Task = task;
        }

        public virtual string EditCSSEditorFor(string property)
        {
            bool required = IsRequired(property);

            return required ? AppDefaults.CSSClassEditorRequired : AppDefaults.CSSClassEditor;
        }

        public virtual string EditCSSEditorDateFor(string property)
        {
            bool required = IsRequired(property);

            return required ? AppDefaults.CSSClassEditorDateRequired : AppDefaults.CSSClassEditorDate;
        }

        public virtual string EditCSSEditorDateTimeFor(string property)
        {
            bool required = IsRequired(property);

            return required ? AppDefaults.CSSClassEditorDateTimeRequired : AppDefaults.CSSClassEditorDateTime;
        }

        public virtual string EditCSSLabelFor(string property)
        {
            bool required = IsRequired(property);

            return required ? AppDefaults.CSSClassLabelRequired : AppDefaults.CSSClassLabel;
        }

        public virtual bool IsRequired(string property)
        {
            bool result = false;

            PropertyInfo propertyInfo = LibraryHelper.GetProperty(this.GetType(), property);
            if (Attribute.IsDefined(propertyInfo, typeof(RequiredAttribute)))
            {
                result = true;
            }

            return result;
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }

        public virtual bool Validate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        #endregion Methods
    }
}
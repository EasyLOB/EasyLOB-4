using EasyLOB.Library;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Threading;

namespace EasyLOB.Data
{
    public abstract class ZDataModel : IZDataModel, INotifyPropertyChanged
    {
        #region Properties

        private string _lookupText; // AutoMapper

        [JsonIgnore] // Newtonsoft.Json
        [NotMapped] // MongoDB
        public virtual string LookupText
        {
            get
            {
                string result = "";

                Type entityType = this.GetType();
                IZProfile profile = DataHelper.GetProfile(entityType);
                if (profile != null && !string.IsNullOrEmpty(profile.Lookup))
                {
                    try
                    {
                        var value = LibraryHelper.GetPropertyValue(this, profile.Lookup);
                        result = value == null ? "" : value.ToString();
                    }
                    catch { }
                }

                return result;
            }
            set
            {
                _lookupText = value; // AutoMapper
            }
        }

        #endregion Properties

        #region Methods

        private readonly static object _lock = new object();

        public virtual void ClearAssociations()
        {
            try
            {
                Monitor.Enter(_lock);

                const BindingFlags bindingFlags =
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
                PropertyInfo[] properties = GetType().GetProperties(bindingFlags);
                foreach (PropertyInfo property in properties)
                {
                    // Associations ZDataModel = null 
                    if (typeof(ZDataModel).IsAssignableFrom(property.PropertyType))
                    {
                        property.SetValue(this, null, null);
                    }
                }
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }

        public virtual void ClearCollections()
        {
        }
        /*
        public virtual void ClearCollections()
        {
            try
            {
                Monitor.Enter(_lock);

                const BindingFlags bindingFlags =
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
                PropertyInfo[] properties = GetType().GetProperties(bindingFlags);
                foreach (PropertyInfo property in properties)
                {
                    // Collections IList { get; } = ?
                    // Collections IList { get; protected set; } = null
                    if (property.PropertyType.IsGenericType && (property.PropertyType.GetGenericTypeDefinition() == typeof(IList<>)))
                    {
                        try
                        {
                            property.SetValue(this, null, null);
                        }
                        catch { }
                    }
                }
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
        */
        public virtual Object CloneShallow()
        {
            return this.MemberwiseClone();
        }

        public virtual object[] GetId()
        {
            throw new NotImplementedException();
        }

        public virtual string GetResource(string resource)
        {
            return DataHelper.GetResource(this.GetType(), resource);  
        }

        public virtual void OnConstructor()
        {
        }

        public virtual void SetId(object[] ids)
        {
            throw new NotImplementedException();
        }

        #endregion Methods

        #region Triggers

        public virtual bool BeforeCreate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterCreate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeDelete(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterDelete(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeUpdate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterUpdate(ZOperationResult operationResult)
        {
            return operationResult.Ok;
        }

        #endregion Triggers

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}
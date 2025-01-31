using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// ModelState.IsValid vs IValidateableObject in MVC3
// http://stackoverflow.com/questions/3744408/modelstate-isvalid-vs-ivalidateableobject-in-mvc3
// Validation using the DefaultModelBinder is a two stage process.
// First, Data Annotations are validated.
// Then (and only if the data annotations validation resulted in zero errors), IValidatableObject.Validate() is called.
// This all takes place automatically when your post action has a viewmodel parameter.ModelState.IsValid doesn't do anything as such.
// Rather it just reports whether any item in the ModelState collection has non-empty ModelErrorCollection.

namespace EasyLOB.Data
{
    public abstract class ZViewModel<TEntityView, TEntityDTO, TEntity> : IZViewModel<TEntityView, TEntityDTO, TEntity>, IValidatableObject, IZValidatableObject
        where TEntityView : class, IZViewModel<TEntityView, TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOModel<TEntityDTO, TEntity>
        where TEntity : class, IZDataModel
    {
        #region Properties

        public virtual string LookupText { get; set; }

        #endregion Properties

        #region Methods

        public virtual Object CloneShallow()
        {
            return this.MemberwiseClone();
        }

        public virtual void FromData(IZDataModel dataModel)
        {
            if (dataModel != null)
            {
                EasyLOBHelper.Mapper.Map<TEntity, TEntityView>(dataModel as TEntity, this as TEntityView);
            }
        }

        public virtual void FromDTO(IZDTOModel<TEntityDTO, TEntity> dto)
        {
            if (dto != null)
            {
                EasyLOBHelper.Mapper.Map<TEntityDTO, TEntityView>(dto as TEntityDTO, this as TEntityView);
            }
        }

        public virtual void FromDTO(TEntityDTO dto)
        {
            if (dto != null)
            {
                EasyLOBHelper.Mapper.Map<TEntityDTO, TEntityView>(dto as TEntityDTO, this as TEntityView);
            }
        }

        public virtual void OnConstructor()
        {
        }

        public virtual IZDataModel ToData()
        {
            return EasyLOBHelper.Mapper.Map<TEntity>(this);
        }

        public virtual TEntityDTO ToDTO()
        {
            return EasyLOBHelper.Mapper.Map<TEntityDTO>(this);
        }

        //public virtual IZDTOModel<TEntityDTO, TEntity> ToDTO()
        //{
        //    return EasyLOBHelper.Mapper.Map<ZDTOModel<TEntityDTO, TEntity>>(this);
        //}

        #endregion Methods

        #region Methods Validate

        public virtual IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext) // IValidatableObject
        {
            return new List<ValidationResult>();
        }

        public virtual bool Validate(ZOperationResult operationResult) // IZValidatableObject
        {
            return true;
        }      

        #endregion Methods Validate
    }
}
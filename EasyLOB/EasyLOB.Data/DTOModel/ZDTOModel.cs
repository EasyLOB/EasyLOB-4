using System;

namespace EasyLOB.Data
{
    public abstract class ZDTOModel<TEntityDTO, TEntity> : IZDTOModel<TEntityDTO, TEntity>
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
                EasyLOBHelper.Mapper.Map<TEntity, TEntityDTO>(dataModel as TEntity, this as TEntityDTO);
            }
        }

        public virtual void OnConstructor()
        {
        }

        public virtual IZDataModel ToData()
        {
            return EasyLOBHelper.Mapper.Map<TEntity>(this);
        }

        #endregion Methods
    }
}
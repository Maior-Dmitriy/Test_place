using Model.DL;
using Models.Dto;
using System;
using System.Collections.Generic;

namespace ServiceContracts
{
    public interface IBaseService<TDtoModel, TEntity>
        where TDtoModel : BaseDtoModel
        where TEntity : BaseEntity
    {
        ICollection<TDtoModel> GetAll();
        TDtoModel GetById(Guid id);
        Guid Add(TDtoModel model);
        void Update(TDtoModel model);
        void Delete(Guid id);
    }
}

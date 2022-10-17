using AutoMapper;
using DL;
using DL.RepositoryContracts;
using Model.DL;
using Models.Dto;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class BaseService<TDtoModel, TEntity> : IBaseService<TDtoModel, TEntity>
        where TDtoModel : BaseDtoModel
        where TEntity : BaseEntity
    {

        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public virtual ICollection<TDtoModel> GetAll()
        {
            var result = _repository.GetAll().Select(x => _mapper.Map<TEntity, TDtoModel>(x)).ToList();

            return result;
        }

        public virtual TDtoModel GetById(Guid id)
        {
            var entity = _repository.GetById(id);
            var model = _mapper.Map<TEntity, TDtoModel>(entity);

            return model;
        }

        public virtual Guid Add(TDtoModel model)
        {
            var entity = _mapper.Map<TDtoModel, TEntity>(model);
            _repository.Add(entity);

            return entity.Id;
        }

        public virtual void Update(TDtoModel model)
        {
            var entity = _mapper.Map<TDtoModel, TEntity>(model);
            _repository.Update(entity); 
        }

        public virtual void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}

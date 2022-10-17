using DL.Context;
using DL.RepositoryContracts;
using Model.DL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.RepositoriesImplementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MsSqlContext _msSqlContext;

        public BaseRepository(MsSqlContext msSqlContext)
        {
            _msSqlContext = msSqlContext;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _msSqlContext.Set<T>().ToArray();
        }

        public virtual T GetById(Guid? id)
        {
            var search= _msSqlContext.Set<T>().Find(id);

            if (search == null)
                throw new Exception($"Entity {id} is not found");

            return search;
        }

        public virtual void Add(T entity)
        {
            _msSqlContext.Set<T>().Add(entity);
            Save();
        }

        public virtual void Update(T entity)
        {
            var search = _msSqlContext.Set<T>().FirstOrDefault(x => x.Id.Equals(entity.Id));

            if (search == null)
                throw new Exception($"Entity {entity.Id} is not found");

            _msSqlContext.Set<T>().Update(entity);

            Save();
        }

        public virtual void Delete(Guid id)
        {
            var search = _msSqlContext.Set<T>().FirstOrDefault(x => x.Id.Equals(id));

            if (search == null)
                throw new Exception($"Entity {id} is not found");

            _msSqlContext.Set<T>().Remove(search);

            Save();
        }

        public virtual void Save()
        {
            _msSqlContext.SaveChanges();
        }
    }
}

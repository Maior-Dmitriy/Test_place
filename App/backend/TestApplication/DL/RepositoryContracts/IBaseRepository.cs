using System;
using System.Collections.Generic;

namespace DL.RepositoryContracts
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid? id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
        void Save();
    }
}

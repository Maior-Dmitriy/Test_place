using DL.Context;
using DL.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Model.DL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DL.RepositoriesImplementation
{
    public class TestRepository : BaseRepository<TestEntity>, ITestRepository
    {
        public TestRepository(MsSqlContext msSqlContext)
            :base(msSqlContext)
        {

        }

        public override IEnumerable<TestEntity> GetAll()
        {
            var result = _msSqlContext.Set<TestEntity>()
                .Include(test => test.Questions)     
                    .ThenInclude(question => question.Options)
                .ToList();

            return result;
        }

        public override TestEntity GetById(Guid? id)
        {
            var result = _msSqlContext.Set<TestEntity>().Where(test => test.Id.Equals(id))
                .Include(test => test.Questions)
                    .ThenInclude(question => question.Options)
                .FirstOrDefault();

            return result;
        }
    }
}

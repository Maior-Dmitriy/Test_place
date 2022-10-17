using DL.Context;
using DL.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Model.DL;
using System;
using System.Linq;

namespace DL.RepositoriesImplementation
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(MsSqlContext msSqlContext)
            :base(msSqlContext)
        {

        }

        public override UserEntity GetById(Guid? id)
        {
            var result = _msSqlContext.Set<UserEntity>().Where(u => u.Id.Equals(id))
                .Include(user => user.Roles)
                .Include(user => user.Tests)
                .FirstOrDefault();

            return result;
        }

        public UserEntity Authenticate(string login, string passwordHash)
        {
            var result = _msSqlContext.Set<UserEntity>()
                .Where(u => u.Email.ToLower().Equals(login) && u.Password.Equals(passwordHash))
                .Include(user => user.Roles)
                .Include(user => user.Tests)
                .FirstOrDefault();

            return result;
        }
    }
}

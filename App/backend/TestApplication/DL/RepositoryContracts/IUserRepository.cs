using Model.DL;

namespace DL.RepositoryContracts
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        UserEntity Authenticate(string login, string passwordHash);
    }
}

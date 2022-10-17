using Model.DL;
using Models.Dto;

namespace ServiceContracts
{
    public interface IUserService : IBaseService<UserDtoModel, UserEntity>
    {
        UserDtoModel Authenticate(string login, string password);
    }
}

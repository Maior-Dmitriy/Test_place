using Models.Dto;

namespace ServiceContracts
{
    public interface IAuthService
    {
        SignInDtoModel Authenticate(string login, string password);
    }
}

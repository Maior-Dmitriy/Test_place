using AuthorizationJwt;
using Models.Dto;

namespace Authorization
{
    public interface IAuthJwtManager
    {
        AuthJwtModel GenerateToken(UserDtoModel user);
    }
}

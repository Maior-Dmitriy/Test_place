using Authorization;
using Models.Dto;
using ServiceContracts;

namespace Services
{
    public class AuthService : IAuthService
    {
        IUserService _userService;
        IAuthJwtManager _authService;

        public AuthService(IUserService userService, IAuthJwtManager authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public SignInDtoModel Authenticate(string login, string password)
        {
            if(login == null || password == null)
            {
                return null;
            }    

            var userApiModel =  _userService.Authenticate(login, password);

            if (userApiModel == null)
            {
                return null;
            }

            var jwtTokenModel = _authService.GenerateToken(userApiModel);

            var signApiModel = new SignInDtoModel()
            {
                UserId = jwtTokenModel.UserId,
                AccessToken = jwtTokenModel.AccessToken,
                Expires = jwtTokenModel.Expires,
                User = userApiModel
            };

            return signApiModel;
        }
    }
}

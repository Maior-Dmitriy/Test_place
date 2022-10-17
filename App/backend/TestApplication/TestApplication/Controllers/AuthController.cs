using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using ServiceContracts;

namespace TestApplication.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginDtoModel model)
        {
            SignInDtoModel signDtoModel = _service.Authenticate(model.Login, model.Password);

            if (signDtoModel != null)
            {
                return Ok(signDtoModel);
            }

            return Unauthorized();
        }
    }
}

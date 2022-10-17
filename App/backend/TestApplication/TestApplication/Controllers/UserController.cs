using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.DL;
using Models.Dto;
using ServiceContracts;

namespace TestApplication.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    public class UserController : BaseController<UserDtoModel, UserEntity>
    {
        public UserController(IUserService userService, IMapper mapper)
            :base(userService, mapper)
        {

        }
    }
}

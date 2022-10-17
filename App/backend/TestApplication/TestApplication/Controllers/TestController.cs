using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DL;
using Models.Dto;
using ServiceContracts;

namespace TestApplication.Controllers
{
    [Authorize]
    [Route("api/test")]
    public class TestController : BaseController<TestDtoModel, TestEntity>
    {
        public TestController(ITestService testService, IMapper mapper)
               : base(testService, mapper)
        {

        }
    }
}

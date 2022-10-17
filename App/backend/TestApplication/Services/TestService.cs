using AutoMapper;
using DL.RepositoryContracts;
using Model.DL;
using Models.Dto;
using ServiceContracts;

namespace Services
{
    public class TestService : BaseService<TestDtoModel, TestEntity>, ITestService
    {
        public TestService(ITestRepository repository, IMapper mapper)
            :base(repository, mapper)
        {

        }
    }
}

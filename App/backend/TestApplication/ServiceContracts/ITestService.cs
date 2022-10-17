using Model.DL;
using Models.Dto;

namespace ServiceContracts
{
    public interface ITestService : IBaseService<TestDtoModel, TestEntity>
    {

    }
}

using AutoMapper;
using Model.DL;
using Models.Dto;

namespace MapperProvider
{
    public class DataMappingManager : Profile
    {
        public DataMappingManager()
        {
            CreateMap<UserEntity, UserDtoModel>();
            CreateMap<UserDtoModel, UserEntity>();

            CreateMap<RoleEntity, RoleDtoModel>();
            CreateMap<RoleDtoModel, RoleEntity>();

            CreateMap<TestEntity, TestDtoModel>();
            CreateMap<TestDtoModel, TestEntity>();

            CreateMap<OptionEntity, OptionDtoModel>();
            CreateMap<OptionDtoModel, OptionEntity>();

            CreateMap<QuestionEntity , QuestionDtoModel>();
            CreateMap<QuestionDtoModel, QuestionEntity >();
        }
    }
}

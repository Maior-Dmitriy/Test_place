using AutoMapper;
using DL.RepositoryContracts;
using Model.DL;
using Models.Dto;
using ServiceContracts;

namespace Services
{
    public class OptionService : BaseService<OptionDtoModel, OptionEntity>, IOptionService
    {
        public OptionService(IOptionRepository repository, IMapper mapper)
            :base(repository, mapper)
        {

        }
    }
}

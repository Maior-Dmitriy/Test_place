using AutoMapper;
using DL.RepositoryContracts;
using Model.DL;
using Models.Dto;
using ServiceContracts;

namespace Services
{
    public class RoleService : BaseService<RoleDtoModel, RoleEntity>, IRoleService
    {
        public RoleService(IRoleRepository repository, IMapper mapper)
            :base(repository, mapper)
        {

        }
    }
}

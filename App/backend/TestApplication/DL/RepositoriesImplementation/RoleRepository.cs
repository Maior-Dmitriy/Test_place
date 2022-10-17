using DL.Context;
using DL.RepositoryContracts;
using Model.DL;

namespace DL.RepositoriesImplementation
{
    public class RoleRepository : BaseRepository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(MsSqlContext msSqlContext)
            :base(msSqlContext)
        {

        }
    }
}

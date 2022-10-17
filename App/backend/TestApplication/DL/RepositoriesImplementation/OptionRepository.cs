using DL.Context;
using DL.RepositoryContracts;
using Model.DL;

namespace DL.RepositoriesImplementation
{
    public class OptionRepository : BaseRepository<OptionEntity>, IOptionRepository
    {
        public OptionRepository(MsSqlContext msSqlContext)
            :base(msSqlContext)
        {

        }
    }
}

using DL.Context;
using DL.RepositoryContracts;
using Model.DL;

namespace DL.RepositoriesImplementation
{
    public class QuestionRepository : BaseRepository<QuestionEntity >, IQuestionRepository
    {
        public QuestionRepository(MsSqlContext msSqlContext)
            : base(msSqlContext)
        {

        }
    }
}

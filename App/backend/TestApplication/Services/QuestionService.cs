using AutoMapper;
using DL.RepositoryContracts;
using Model.DL;
using Models.Dto;
using ServiceContracts;

namespace Services
{
    public class QuestionService : BaseService<QuestionDtoModel, QuestionEntity >, IQuestionService
    {
        public QuestionService(IQuestionRepository repository, IMapper mapper)
            :base(repository, mapper)
        {

        }
    }
}

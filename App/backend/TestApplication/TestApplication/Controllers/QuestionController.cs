using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.DL;
using Models.Dto;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    public class QuestionController : BaseController<QuestionDtoModel, QuestionEntity>
    {
        public QuestionController(IQuestionService questionService, IMapper mapper)
            : base(questionService, mapper)
        {

        }
    }
}

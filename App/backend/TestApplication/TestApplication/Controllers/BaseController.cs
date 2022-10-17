using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Model.DL;
using Models.Dto;
using ServiceContracts;
using System;
using System.Linq;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TDtoModel, TEntity> : ControllerBase
         where TDtoModel : BaseDtoModel
         where TEntity : BaseEntity
    {
        protected IBaseService<TDtoModel, TEntity> _baseService;
        protected IMapper _mapper;

        public BaseController(IBaseService<TDtoModel, TEntity> service, IMapper mapper)
        {
            _baseService = service;
            _mapper = mapper;
        }

        [Route("get_all")]
        [HttpGet]
        public virtual IActionResult GetAll()
        {
            try
            {
                var result = _baseService.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error");
            }
        }

        [Route("get")]
        [HttpGet]
        public virtual IActionResult Get(Guid id)
        {
            try
            {
                var model = _baseService.GetById(id);

                if (model != null)
                {
                    return Ok(model);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error");
            }
        }

        [Route("add")]
        [HttpPost]
        public virtual IActionResult Add([FromBody] TDtoModel model)
        {
            try
            {
                Guid id = _baseService.Add(model);

                if (id != Guid.Empty)
                {
                    return Ok(model);
                }

                return StatusCode(400);
            }
            catch (Exception)
            {
               return StatusCode(500, "Server error");
            }
        }

        [Route("update")]
        [HttpPut]
        public virtual IActionResult Update([FromBody] TDtoModel model)
        {
            try
            {
                _baseService.Update(model);
                return Ok(model.Id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error");
            }
        }

        [Route("delete")]
        [HttpDelete]
        public virtual IActionResult Delete(Guid id)
        {
            try
            {
                _baseService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
               return StatusCode(500, "Server error");
            }
        }
    }
}

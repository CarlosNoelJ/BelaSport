using BelaSport.Models;
using BelaSport.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BelaSport.WebApi.Controllers
{
    [Route("api/host")]
    [ApiController]
    public class HostController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IValidator<Host> _validator;

        public HostController(IUnitOfWork unit, IValidator<Host> validator)
        {
            _unit = unit;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unit.Host.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Host.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(Host Host)
        {
            var validationResult = _validator.Validate(Host);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
                return Ok(_unit.Host.Add(Host));
        }

        [HttpPut]
        public IActionResult Put(Host Host)
        {
            return Ok(_unit.Host.Update(Host));
        }

        [HttpDelete]
        public IActionResult Delete(Host Host)
        {
            return Ok(_unit.Host.Delete(Host));
        }
    }
}

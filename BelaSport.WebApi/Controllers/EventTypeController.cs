using BelaSport.Models;
using BelaSport.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BelaSport.WebApi.Controllers
{
    [Route("api/eventType")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IValidator<EventType> _validator;

        public EventTypeController(IUnitOfWork unit, IValidator<EventType> validator)
        {
            _unit = unit;
            _validator = validator;
        }

        // GET api/eventType
        [HttpGet]
        public IActionResult Get()
        {
            return Ok( _unit.EventType.GetList());
        }

        // GET api/eventType/5
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.EventType.GetById(id));
        }

        // POST api/eventType
        [HttpPost]
        public IActionResult Post(EventType EventType)
        {
            var validationResult = _validator.Validate(EventType);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            return Ok(_unit.EventType.Add(EventType));
        }

        // PUT api/eventType/5
        [HttpPut]
        public IActionResult Put(EventType EventType)
        {
            var validationResult = _validator.Validate(EventType);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            return Ok(_unit.EventType.Update(EventType));
        }

        // DELETE api/eventType/5
        [HttpDelete()]
        public IActionResult Delete(EventType EventType)
        {
            return Ok(_unit.EventType.Delete(EventType));
        }
    }
}

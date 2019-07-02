using BelaSport.Models;
using BelaSport.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BelaSport.WebApi.Controllers
{
    [Route("api/eventType")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unit;

        public EventTypeController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok( _unit.EventType.GetList());
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public IActionResult Post(EventType EventType)
        {
            return Ok(_unit.EventType.Add(EventType));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put(EventType EventType)
        {
            return Ok(_unit.EventType.Update(EventType));
        }

        // DELETE api/values/5
        [HttpDelete()]
        public IActionResult Delete(EventType EventType)
        {
            return Ok(_unit.EventType.Delete(EventType));
        }
    }
}

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

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

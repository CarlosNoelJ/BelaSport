using BelaSport.Models;
using BelaSport.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BelaSport.WebApi.Controllers
{
    [Route("api/eventTitle")]
    [ApiController]
    public class EventTitleController : ControllerBase
    {
        private readonly IUnitOfWork _unit;

        public EventTitleController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unit.EventTitle.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.EventTitle.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(EventTitle EventTitle)
        {
            return Ok(_unit.EventTitle.Add(EventTitle));
        }

        [HttpPut]
        public IActionResult Put(EventTitle EventTitle)
        {
            return Ok(_unit.EventTitle.Update(EventTitle));
        }

        [HttpDelete]
        public IActionResult Delete(EventTitle EventTitle)
        {
            return Ok(_unit.EventTitle.Delete(EventTitle));
        }
    }
}

using BelaSport.Models;
using BelaSport.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BelaSport.WebApi.Controllers
{
    [Route("api/host")]
    [ApiController]
    public class HostController : ControllerBase
    {
        private readonly IUnitOfWork _unit;

        public HostController(IUnitOfWork unit)
        {
            _unit = unit;
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

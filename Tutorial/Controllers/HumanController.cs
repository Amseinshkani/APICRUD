using Core.Domain;
using Core.Interface;
using Infrastructure.Data.DBContext;
using Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tutorial.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HumanController : ControllerBase
    {

        private readonly IPerson _IP;
        public HumanController(IPerson Person) 
        {
            _IP = Person;
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> Adding(Person person) 
        {
            if (person == null)
                return BadRequest("Your Model is Null");

            return Ok(_IP.AddPerson(person));

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Person>> findingOut(int Id)
        {
            if (_IP.findingOut(Id) == null)
                return BadRequest("Not Found!");

            return Ok(_IP.findingOut(Id));
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Updating(Person person)
        {
            if (_IP.Updating(person) == null)
                return BadRequest("Your Model is Null");

            return Ok(_IP.Updating(person));
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> presentation()
        {
            if (_IP.presentation() == null)
                return BadRequest("You Dont Have data");

            return Ok(_IP.presentation());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Person>>> Deleted(int Id)
        {
            if (_IP.Deleted(Id) == null)
                return BadRequest("Not Found!");

            return Ok(_IP.Deleted(Id));
        }

    }
}

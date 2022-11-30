using Core.Domain;
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
        //private static List<Person> people = new List<Person>
        //{
        //    new Person
        //    {
        //      Id= 1,
        //      FirstName = "Amir",
        //      LastName = "Ashkani",
        //      City = "Norway"
        //    },
        //    new Person
        //    {
        //      Id= 2,
        //      FirstName = "Saghar",
        //      LastName = "Ashkani",
        //      City = "Norway"
        //    }
        //};

        private readonly DataConnection _Connection;
        public HumanController(DataConnection connection) 
        {
        _Connection= connection;
        }


        [HttpPost]
        public async Task<ActionResult<List<Person>>> Adding(TPerson person) 
        {
            _Connection.People.Add(person);
           await _Connection.SaveChangesAsync();

            var AddShowing = await _Connection.People.ToListAsync();
            return Ok(AddShowing);

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Person>> findingOut(int Id)
        {
            var Select = await _Connection.People.FindAsync(Id);

            if (Select == null)
                return BadRequest("not found!");

            return Ok(Select);
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Updating(Person person)
        {
            var changePerson = await _Connection.People.FindAsync(person.Id);

            if (changePerson == null)
                return BadRequest("not found!");

            changePerson.FirstName = person.FirstName;
            changePerson.LastName = person.LastName;
            changePerson.City = person.City;

            _Connection.People.Update(changePerson);
            await _Connection.SaveChangesAsync();

            return Ok(changePerson);
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> presentation()
        {
            var Showing = await _Connection.People.ToListAsync();
            return Ok(Showing);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<Person>>> Deleted(int Id)
        {
            var Select = await _Connection.People.FindAsync(Id);

            if (Select == null)
                return BadRequest("not found!");

            _Connection.People.Remove(Select);
            await _Connection.SaveChangesAsync();

            var Showing = await _Connection.People.ToListAsync();
            return Ok(Showing);
        }

    }
}

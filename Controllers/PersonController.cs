using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickStartIdentityServer.Models;
using QuickStartIdentityServer.Data;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkId=397860

namespace QuickStartIdentityServer.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class PersonController : Controller
    {
        public ApplicationDbContext dbContext;

        public PersonController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: Person
        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            return dbContext.People;
        }

        // GET: Person/id
        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetPerson(Guid id)
        {
            var person = dbContext.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            return new ObjectResult(person);
        }

        // POST: Person
        [HttpPost]
        public IActionResult AddPerson([FromBody]Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            dbContext.People.Add(person);
            dbContext.SaveChanges();
            return CreatedAtRoute("GetPerson", new { id = person.Id }, person);
        }

        // PUT: Person/id
        [HttpPut("{id}")]
        public IActionResult UpdatePerson(Guid id, [FromBody]Person newPerson)
        {
            if (newPerson == null || newPerson.Id != id)
            {
                return BadRequest();
            }

            var person = dbContext.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            dbContext.People.Update(newPerson);
            dbContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE: Person/5
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(Guid id)
        {
            var person = dbContext.People.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.People.Remove(person);
                dbContext.SaveChanges();
                return new NoContentResult();
            }
        }
    }
}

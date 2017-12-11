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
    [Authorize(Roles = "Admin")]
    [Route("[controller]/[action]")]
    public class SpecialController : Controller
    {
        public ApplicationDbContext dbContext;

        public SpecialController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: Special
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Special> GetSpecials()
        {
            return dbContext.Specials;
        }
        // GET: Special
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Special> GetActiveSpecials()
        {
            return dbContext.Specials.Where(s =>s.IsActive == true);
        }

        // GET: Special/id
        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetSpecial")]
        public IActionResult GetSpecial(Guid id)
        {
            var special = dbContext.Specials.Find(id);
            if (special == null)
            {
                return NotFound();
            }
            return new ObjectResult(special);
        }

        // POST: Special
        [HttpPost]
        public IActionResult AddSpecial([FromBody]Special special)
        {
            if (special == null)
            {
                return BadRequest();
            }

            dbContext.Specials.Add(special);
            dbContext.SaveChanges();
            return CreatedAtRoute("GetSpecial", new { id = special.Id }, special);
        }

        // PUT: Special/id
        [HttpPut("{id}")]
        public IActionResult PutSpecial(Guid id, [FromBody]Special newSpecial)
        {
            if (newSpecial == null || newSpecial.Id != id)
            {
                return BadRequest();
            }

            var special = dbContext.Specials.Where(t => id == t.Id);
            if (special == null)
            {
                return NotFound();
            }

            dbContext.Specials.Update(newSpecial);
            dbContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE: Special/id
        [HttpDelete("{id}")]
        public IActionResult DeleteSpecial(Guid id)
        {
            var special = dbContext.Specials.Find(id);
            if (special == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Specials.Remove(special);
                dbContext.SaveChanges();
                return new NoContentResult();
            }
        }
    }
}

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
    public class LicenseController : Controller
    {
        public ApplicationDbContext dbContext;

        public LicenseController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: User
        [HttpGet]
        public IEnumerable<License> GetLicenses()
        {
            return dbContext.Licenses;
        }

        // GET: License
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<License> GetExpiredLicenses()
        {
            return dbContext.Licenses.Where(p => p.EndDate <= DateTime.Now);
        }

        // GET: License/id
        [HttpGet("{id}", Name = "GetLicense")]
        public IActionResult GetLicense(Guid id)
        {
            var license = dbContext.Licenses.Find(id);
            if (license == null)
            {
                return NotFound();
            }
            return new ObjectResult(license);
        }

        // POST: license
        [HttpPost]
        public IActionResult AddLicense([FromBody]License license)
        {
            if (license == null)
            {
                return BadRequest();
            }

            dbContext.Licenses.Add(license);
            dbContext.SaveChanges();
            return CreatedAtRoute("GetLicense", new { id = license.Id }, license);
        }

        // PUT: license/id
        [HttpPut("{id}")]
        public IActionResult PutLicense(Guid id, [FromBody]License newLicense)
        {
            if (newLicense == null || newLicense.Id != id)
            {
                return BadRequest();
            }

            var license = dbContext.Licenses.Where(t => id == t.Id);
            if (license == null)
            {
                return NotFound();
            }

            dbContext.Licenses.Update(newLicense);
            dbContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE: license/id
        [HttpDelete("{id}")]
        public IActionResult DeleteLicense(Guid id)
        {
            var license = dbContext.Licenses.Find(id);
            if (license == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Licenses.Remove(license);
                dbContext.SaveChanges();
                return new NoContentResult();
            }
        }
    }
}

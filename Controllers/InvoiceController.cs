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
    public class InvoiceController : Controller
    {
        public ApplicationDbContext dbContext;

        public InvoiceController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: Invoice
        [HttpGet]
        public IEnumerable<Invoice> GetInvoices()
        {
            return dbContext.Invoices;
        }

        // GET: Invoice
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Invoice> GetUnpaidInvoices()
        {
            return dbContext.Invoices.Where(p => p.Paid == false);
        }

        // GET: Invoice/id
        [HttpGet("{id}", Name = "GetInvoice")]
        public IActionResult GetInvoice(Guid id)
        {
            var invoice = dbContext.Invoices.Find(id);
            if (invoice == null)
            {
                return NotFound();
            }
            return new ObjectResult(invoice);
        }

        // POST: invoice
        [HttpPost]
        public IActionResult AddInvoice([FromBody]Invoice invoice)
        {
            if (invoice == null)
            {
                return BadRequest();
            }

            dbContext.Invoices.Add(invoice);
            dbContext.SaveChanges();
            return CreatedAtRoute("GetInvoice", new { id = invoice.Id }, invoice);
        }

        // PUT: invoice/id
        [HttpPut("{id}")]
        public IActionResult PutInvoice(Guid id, [FromBody]Invoice newInvoice)
        {
            if (newInvoice == null || newInvoice.Id != id)
            {
                return BadRequest();
            }

            var invoice = dbContext.Invoices.Where(t => id == t.Id);
            if (invoice == null)
            {
                return NotFound();
            }

            dbContext.Invoices.Update(newInvoice);
            dbContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE: invoice/id
        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(Guid id)
        {
            var invoice = dbContext.Invoices.Find(id);
            if (invoice == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Invoices.Remove(invoice);
                dbContext.SaveChanges();
                return new NoContentResult();
            }
        }
    }
}

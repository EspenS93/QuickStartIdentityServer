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
    public class ProductController : Controller
    {
        public ApplicationDbContext dbContext;

        public ProductController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: Product
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return dbContext.Products;
        }

        // GET: Product
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Product> GetActiveProducts()
        {
            return dbContext.Products.Where(p => p.IsActive == true);
        }

        // GET: Product/id
        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(Guid id)
        {
            var product = dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

        // POST: product
        [HttpPost]
        public IActionResult AddProduct([FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        // PUT: product/id
        [HttpPut("{id}")]
        public IActionResult PutProduct(Guid id, [FromBody]Product newProduct)
        {
            if (newProduct == null || newProduct.Id != id)
            {
                return BadRequest();
            }

            var product = dbContext.Products.Where(t => id == t.Id);
            if (product == null)
            {
                return NotFound();
            }

            dbContext.Products.Update(newProduct);
            dbContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE: product/id
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = dbContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                dbContext.Products.Remove(product);
                dbContext.SaveChanges();
                return new NoContentResult();
            }
        }
    }
}

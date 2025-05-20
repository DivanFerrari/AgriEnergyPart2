using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Model;
using ProductAPI.Models;
using System;
using static System.Net.WebRequestMethods;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly FarmDbContext _context;
        public ProductController(FarmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            return product;
        }

        //𝐂𝐨𝐝𝐞𝐖𝐢𝐭𝐡𝐆𝐨𝐩𝐢 (2024). 🔄 Create and Consume Web API in ASP.NET Core MVC |
        //Full CRUD Operations & API Consumption. [online] YouTube.Available at:
        //https://www.youtube.com/watch?v=knTcwvFWOQM [Accessed 18 May 2025].

        [HttpPost]
        public IActionResult Post(Product model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Product created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //𝐂𝐨𝐝𝐞𝐖𝐢𝐭𝐡𝐆𝐨𝐩𝐢 (2024). 🔄 Create and Consume Web API in ASP.NET Core MVC |
        //Full CRUD Operations & API Consumption. [online] YouTube.Available at:
        //https://www.youtube.com/watch?v=knTcwvFWOQM [Accessed 18 May 2025].



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.ProductID)
                return BadRequest();

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.ProductID == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

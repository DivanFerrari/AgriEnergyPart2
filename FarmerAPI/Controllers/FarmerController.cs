using FarmerAPI.Model;
using FarmerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly FarmDbContext _context;
        public FarmerController(FarmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farmer>>> GetAll()
        {
            return await _context.Farmers.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Farmer>> GetById(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
                return NotFound();

            return farmer;
        }

        //𝐂𝐨𝐝𝐞𝐖𝐢𝐭𝐡𝐆𝐨𝐩𝐢 (2024). 🔄 Create and Consume Web API in ASP.NET Core MVC |
        //Full CRUD Operations & API Consumption. [online] YouTube.Available at:
        //https://www.youtube.com/watch?v=knTcwvFWOQM [Accessed 18 May 2025].


        [HttpPost]
        public IActionResult Post(Farmer model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Farmer Profile created.");
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
        public async Task<IActionResult> Update(int id, Farmer farmer)
        {
            if (id != farmer.FarmerID)
                return BadRequest();

            _context.Entry(farmer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Farmers.Any(e => e.FarmerID == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
                return NotFound();

            _context.Farmers.Remove(farmer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

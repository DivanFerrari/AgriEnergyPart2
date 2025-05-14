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

        [HttpPost]
        public async Task<ActionResult<Farmer>> Create(Farmer farmer)
        {
            _context.Farmers.Add(farmer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = farmer.FarmerID }, farmer);
        }

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

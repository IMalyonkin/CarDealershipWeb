using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CarsContext _context;

        public BrandsController(CarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Brand> GetAll()
        {
            return _context.Brand.Include(m => m.Model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var brand = await _context.Brand.SingleOrDefaultAsync(b => b.Id == id);

            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Brand.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = brand.Name;

            _context.Brand.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Brand.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Brand.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

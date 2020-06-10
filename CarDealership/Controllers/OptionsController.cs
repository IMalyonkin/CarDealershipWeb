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
    public class OptionsController : ControllerBase
    {
        private readonly CarsContext _context;

        public OptionsController(CarsContext context)
        {
            _context = context;
        }

        [HttpGet("{modId}/{typeId}")]
        public async Task<IActionResult> GetOptions([FromRoute] int modId, int typeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Option> options;

            if (typeId != 11)
            {
                options = await _context.Option
                                        .Where(i => i.ModelFK == modId)
                                        .Where(i => i.OptionTypeFK == typeId)
                                        .ToListAsync();
            }
            else
            {
                options = await _context.Option
                                        .Where(i => i.ModelFK == modId)
                                        .Where(i => i.OptionTypeFK == typeId)
                                        .Where(i => i.Price > 0)
                                        .ToListAsync();
            }

            if (options == null)
            {
                return NotFound();
            }

            return Ok(options);
        }

    }
}

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
    public class ModelsController : ControllerBase
    {
        private readonly CarsContext _context;

        public ModelsController(CarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Model> GetAll()
        {
            return _context.Model;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _context.Model.SingleOrDefaultAsync(m => m.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpGet("{id}/kits")]
        public async Task<IActionResult> GetKits([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Kit> kits = await _context.Kit.Where(i => i.ModelFK == id).ToListAsync();

            if (kits == null)
            {
                return NotFound();
            }

            return Ok(kits);
        }

        [HttpGet("{modelId}/kits/{kitId}")]
        public async Task<IActionResult> GetOptions([FromRoute] int modelId, [FromRoute] int kitId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Option> options = await _context.Kit
                                                        .Where(i => i.ModelFK == modelId)
                                                        .Join(_context.Kit_Option, k => k.Id, ko => ko.KitFK, (k, ko) => ko)
                                                        .Join(_context.Option, ko => ko.OptionFK, o => o.Id, (ko, o) => o)
                                                        .ToListAsync();

            if (options == null)
            {
                return NotFound();
            }

            return Ok(options);
        }

        [HttpGet("{id}/engines")]
        public async Task<IActionResult> GetEngines([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Engine> engines = await _context.Model_Engine
                                                        .Where(i => i.ModelFK == id)
                                                        .Join(_context.Engine, me => me.EngineFK, e => e.Id, (me, e) => e)
                                                        .ToListAsync();

            if (engines == null)
            {
                return NotFound();
            }

            return Ok(engines);
        }

        [HttpGet("{id}/colors")]
        public async Task<IActionResult> GetColors([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Color> colors = await _context.Model_Color
                                                        .Where(i => i.ModelFK == id)
                                                        .Join(_context.Color, mc => mc.ColorFK, c => c.Id, (mc, c) => c)
                                                        .ToListAsync();

            if (colors == null)
            {
                return NotFound();
            }

            return Ok(colors);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Model model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Model.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = model.Name;
            item.Price = model.Price;

            _context.Model.Update(item);
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
            var item = _context.Model.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Model.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

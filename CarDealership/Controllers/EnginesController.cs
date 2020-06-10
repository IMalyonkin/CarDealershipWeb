using CarDealership.Models;
using CarDealership.viewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class EnginesController : ControllerBase
    //{
    //    private readonly CarsContext _context;

    //    public EnginesController(CarsContext context)
    //    {
    //        _context = context;
    //    }

    //    [HttpGet]
    //    public IEnumerable<Engine> GetAll()
    //    {
    //        IEnumerable<VehicleModel> allVehicles = _context.Vehicle
    //                                                    .Where(i => i.StatusFK == 1)
    //                                                    .Select(i => new VehicleModel()
    //                                                    {
    //                                                        vehicle = new Vehicle() { Id = i.Id, EngineFK = i.EngineFK, StatusFK = i.StatusFK, KitFK = i.KitFK, ColorFK = i.ColorFK },
    //                                                        model = i.Kit.Model.Name,
    //                                                        engineName = i.Engine.Name,
    //                                                        engineType = i.Engine.Type,
    //                                                        enginePower = i.Engine.Power,
    //                                                        kit = i.Kit.Name,
    //                                                        color = i.Color.Name,
    //                                                        //image = i.Kit.Model.Model_Color.ToList()
    //                                                        //        .Where(j => j.ColorFK == i.ColorFK)
    //                                                        //        .Select(j => j.Image)
    //                                                        //        .FirstOrDefault(),
    //                                                        totalPrice = (i.Kit.Model.Price).ToString(),
    //                                                        options = i.Kit.Kit_Option
    //                                                                .Where(j => j.KitFK == i.KitFK)
    //                                                                .Join(_context.Option, ko => ko.OptionFK, o => o.Id, (ko, o) => o)
    //                                                                .ToList()
    //                                                    });

    //        return allVehicles;
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GetVehicle([FromRoute] int id)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        var vehicle = await _context.Vehicle.SingleOrDefaultAsync(v => v.Id == id);

    //        if (vehicle == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(vehicle);
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        _context.Vehicle.Add(vehicle);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
    //    }

    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Vehicle vehicle)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }
    //        var item = _context.Vehicle.Find(id);
    //        if (item == null)
    //        {
    //            return NotFound();
    //        }

    //        item.StatusFK = vehicle.StatusFK;
    //        item.ColorFK = vehicle.ColorFK;
    //        item.EngineFK = vehicle.EngineFK;
    //        item.KitFK = vehicle.KitFK;

    //        _context.Vehicle.Update(item);
    //        await _context.SaveChangesAsync();
    //        return NoContent();
    //    }

    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> Delete([FromRoute] int id)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }
    //        var item = _context.Vehicle.Find(id);
    //        if (item == null)
    //        {
    //            return NotFound();
    //        }
    //        _context.Vehicle.Remove(item);
    //        await _context.SaveChangesAsync();
    //        return NoContent();
    //    }
    //}
}
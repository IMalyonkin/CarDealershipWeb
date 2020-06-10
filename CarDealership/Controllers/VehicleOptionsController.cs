using CarDealership.Models;
using CarDealership.viewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleOptionsController : ControllerBase
    {
        private readonly CarsContext _context;

        public class Option
        {
            public int[] options;
            public int vId;
        }

        public VehicleOptionsController(CarsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            for (int i = 0; i < option.options.Length; i++)
                _context.Vehicle_Option.Add(new Vehicle_Option { OptionFK = option.options[i], VehicleFK = option.vId, Price = 0 });

            await _context.SaveChangesAsync();

            return null;
        }
    }
}

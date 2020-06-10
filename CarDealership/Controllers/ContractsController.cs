using CarDealership.DAL.Repositories;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private ContractRepository db;

        private readonly ILogger logger;

        public ContractsController(ContractRepository db, ILogger<ContractsController> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Contract> GetAll()
        {
            return db.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContract([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contract = db.GetByID(id);

            if (contract == null)
            {
                return NotFound();
            }

            return Ok(contract);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contract contract)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Create(contract);
                db.Save();

                logger.LogInformation("Contract is created");
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");

                logger.LogError("Contract creation error");
            }

            return CreatedAtAction("GetContract", new { id = contract.Id }, contract);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Contract contract)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var item = db.GetByID(id);
                if (item == null)
                {
                    return NotFound();
                }

                item.Date = contract.Date;
                item.Total_Price = contract.Total_Price;

                db.Update(item);
                db.Save();

                logger.LogInformation("Contract is updated");
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");

                logger.LogError("Contract updating error");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Contract item = db.GetByID(id);
                db.Delete(id);
                db.Save();

                logger.LogInformation("Contract is deleted");
            }
            catch (DataException)
            {
                logger.LogError("Contract deletion error");

                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return NoContent();
        }
    }
}

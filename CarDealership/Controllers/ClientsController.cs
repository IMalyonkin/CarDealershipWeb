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
    public class ClientsController : ControllerBase
    {
        private ClientRepository db;

        private readonly ILogger logger;

        public ClientsController(ClientRepository db, ILogger<ClientsController> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Client> GetAll()
        {
            return db.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = db.GetByID(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Create(client);
                db.Save();

                logger.LogInformation("Client is created");
            }
            catch (DataException)
            {
                
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");

                logger.LogError("Client creation error");
            }

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Client client)
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

                item.Name = client.Name;
                item.Email = client.Email;
                item.PhoneNumber = client.PhoneNumber;

                db.Update(item);
                db.Save();

                logger.LogInformation("Client is updated");
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");

                logger.LogError("Client updating error");
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

                Client item = db.GetByID(id);
                db.Delete(id);
                db.Save();

                logger.LogInformation("Client is deleted");
            }
            catch (DataException)
            {
                logger.LogError("Client deletion error");

                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return NoContent();
        }
    }
}

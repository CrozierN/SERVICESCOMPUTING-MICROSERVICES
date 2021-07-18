using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Procurement.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Procurement.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProcurementController : ControllerBase
    {
        private readonly IProcurementRepository _repository;
        private readonly ILogger<ProcurementController> _logger;

        public ProcurementController(IProcurementRepository repository, ILogger<ProcurementController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Procurement>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Procurement>>> GetProcurements(){
            var procurements = await _repository.GetProcurements();
            return Ok(procurements);
        
        }

        [HttpGet("{id:length(24)}", Name = "GetProcurement")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Procurement), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Procurement>> GetProcurement(string id) {
            var procurement = await _repository.GetProcurement(id);
            if(procurement == null) {
                _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }
            return Ok(procurement);
        }

        [HttpPost]
        public async Task<ActionResult<Entities.Procurement>> CreateProcurement([FromBody] Entities.Procurement procurement)
        {
            await _repository.CreateProcurement(procurement);
            return CreatedAtRoute("GetProcurement", new { id = procurement.Id}, procurement);

        }

        [HttpPut]
        [ProducesResponseType(typeof(Entities.Procurement), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProcurement([FromBody] Entities.Procurement procurement) {
            return Ok(await _repository.UpdateProcurement(procurement));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProcurement")]
        [ProducesResponseType(typeof(Entities.Procurement), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProcurementById(string id) {
            return Ok(await _repository.DeleteProcurement(id));
        }

    }
}

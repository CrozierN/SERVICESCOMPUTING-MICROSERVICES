using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Production.API.Entities;
using Production.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Production.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductionController : ControllerBase
    {
        private readonly IProductionRepository _repository;
        private readonly ILogger<ProductionController> _logger;

        public ProductionController(IProductionRepository repository, ILogger<ProductionController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Entities.Production>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Entities.Production>>> GetProductions()
        {
            var productions = await _repository.GetProductions();
            return Ok(productions);

        }

        [HttpGet("{id:length(24)}", Name = "GetProduction")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.Production), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.Production>> GetProduction(string id)
        {
            var production = await _repository.GetProduction(id);
            if (production == null)
            {
                _logger.LogError($"Production with id: {id}, not found.");
                return NotFound();
            }
            return Ok(production);
        }

        [HttpPost]
        public async Task<ActionResult<Entities.Production>> CreateProduction([FromBody] Entities.Production production)
        {
            await _repository.CreateProduction(production);
            return base.CreatedAtRoute("GetProduction", new { id = production.Id }, production);

        }

        [HttpPut]
        [ProducesResponseType(typeof(Entities.Production), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduction([FromBody] Entities.Production production)
        {
            return Ok(await _repository.UpdateProduction(production));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduction")]
        [ProducesResponseType(typeof(Entities.Production), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduction(string id)
        {
            return Ok(await _repository.DeleteProduction(id));
        }

    }
}

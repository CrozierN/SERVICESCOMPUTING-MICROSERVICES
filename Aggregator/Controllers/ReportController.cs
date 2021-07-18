using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aggregator.Models;
using Aggregator.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aggregator.Controllers
{
    [Route("api/v1/Aggregation/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IProcurementService _procurementService;
        private readonly IMaterialInventoryService _materialInventoryService;

        public ReportController(IProcurementService procurementService, IMaterialInventoryService materialInventoryService)
        {
            _procurementService = procurementService;
            _materialInventoryService = materialInventoryService;
        }

        [HttpGet("{id}", Name = "GetProcurementReport")]
        [ProducesResponseType(typeof(ProcurementInventoryReport), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProcurementInventoryReport>> GetProcurementReport(string id)
        {
            
            var procurement = await _procurementService.GetProcurement(id);

            if(procurement == null){
                return NotFound();
            }

            foreach (var item in procurement.Parts)
            {
                var material = await _materialInventoryService.GetMaterial(item.PartId);

                // set additional product fields
                item.PartModel = material.part_model;
                item.Fit = material.fit;
                if (material.quantity <= 5)
                {
                    item.Recommend = "Low on Stock, Recommended Purchase";
                }
                else
                {
                    item.Recommend = "Enough Stock";
                }
            }
            


            var procurementInventory = new ProcurementInventoryReport
            {
                Id = id,
                TotalPrice = procurement.TotalPrice,
                RequestDate = procurement.RequestDate,
                Parts = procurement.Parts
            };

            //public string Id { get; set; }
            //public double TotalPrice { get; set; }
            //public string RequestDate { get; set; }
            //public IEnumerable<Part> Parts { get; set; }

            return Ok(procurementInventory);
        }
    }
}

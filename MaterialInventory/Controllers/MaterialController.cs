using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MaterialInventory.Data;
using MaterialInventory.DTOs;
using MaterialInventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaterialInventory.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        private readonly IManageMaterialRepo _repository;
        private IMapper _mapper;
        private readonly ILogger<MaterialController> _logger;

        public MaterialController(IManageMaterialRepo repository, IMapper mapper, ILogger<MaterialController> logger)
        {
            _repository = repository; // Dependency Injection
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]  // api/Material
        public ActionResult<IEnumerable<ReadMaterialDTO>> GetMaterials()
        {
            var materialItems = _repository.Materials();

            return Ok(_mapper.Map<IEnumerable<ReadMaterialDTO>>(materialItems));
        }

        [HttpGet("{id}", Name = "GetMaterialById")]
        public ActionResult<ReadMaterialDTO> GetMaterialById(string id)
        {
            var materialItem = _repository.GetMaterial(id);

            if (materialItem != null)
            {
                return Ok(_mapper.Map<ReadMaterialDTO>(materialItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Material> CreateAMaterial(CreateMaterialDTO createMaterialDTO)
        {
            var newMaterialModel = _mapper.Map<Material>(createMaterialDTO);

            _repository.CreateNewMaterial(newMaterialModel);
            _repository.SaveChanges();

            var readMaterialDTO = _mapper.Map<ReadMaterialDTO>(newMaterialModel);
            return CreatedAtRoute(nameof(GetMaterialById), new { id = readMaterialDTO.Id }, readMaterialDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(string id, UpdateMaterialDTO updateMaterialDTO)
        {
            var materialModelFromRepo = _repository.GetMaterial(id);
            if (materialModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(updateMaterialDTO, materialModelFromRepo);
            _repository.UpdateMaterial(materialModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteConfiguration(string id)
        {
            //Mak sure the resource is there
            var materialModelFromRepo = _repository.GetMaterial(id);
            if (materialModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteMaterial(materialModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}

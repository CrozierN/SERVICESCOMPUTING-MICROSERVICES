using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventoryStorage.Data;
using InventoryStorage.DTOs;
using InventoryStorage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryStorage.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IManageProductRepo _repository;
        private IMapper _mapper;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IManageProductRepo repository, IMapper mapper, ILogger<ProductController> logger)
        {
            _repository = repository; // Dependency Injection
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]  // api/Material
        public ActionResult<IEnumerable<ReadProductDTO>> GetMaterials()
        {
            var productItems = _repository.GetProducts();

            return Ok(_mapper.Map<IEnumerable<ReadProductDTO>>(productItems));
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ReadProductDTO> GetProductById(string id)
        {
            var productItems = _repository.GetProductById(id);

            if (productItems != null)
            {
                return Ok(_mapper.Map<ReadProductDTO>(productItems));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Product> CreateAMaterial(CreateProductDTO createProductDTO)
        {
            var newProductModel = _mapper.Map<Product>(createProductDTO);

            _repository.CreateProduct(newProductModel);
            _repository.SaveChanges();

            var readProductDTO = _mapper.Map<ReadProductDTO>(newProductModel);
            return CreatedAtRoute(nameof(GetProductById), new { id = readProductDTO.productId }, readProductDTO);
        }

        [HttpPut]
        public ActionResult UpdateCommand(string id, UpdateProductDTO updateProductDTO)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(updateProductDTO, productModelFromRepo);
            _repository.UpdateProduct(productModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteConfiguration(string id)
        {
            //Mak sure the resource is there
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteProduct(productModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}

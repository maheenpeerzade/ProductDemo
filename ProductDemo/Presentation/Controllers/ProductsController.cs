using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductDemo.Domain.Models;
using ProductDemo.Infrastructure.Repository;
using ProductDemo.Presentation.DTO;

namespace ProductDemo.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        public ProductsController(ProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProductsAsync()
        {
            var products = await _productsRepository.GetAllProductsAsync();

            if (products?.Count() > 0)
            {
                var result = _mapper.Map<IEnumerable<ProductDTO>>(products);
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}", Name = "GetProductByIdAsync")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Invalid id.");

            var product = await _productsRepository.GetProductByIdAsync(id);
            if (product != null)
            {
                var result = _mapper.Map<ProductDTO>(product);
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProductAsync([FromBody] CreateProductDTO product)
        {
            if (product == null)
            {
                return BadRequest("Invalid request.");
            }

            var request = _mapper.Map<Product>(product);

            await _productsRepository.CreateProductAsync(request);
            return CreatedAtRoute(nameof(GetProductByIdAsync), new { id = request.Id }, product);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProductAsync(int id, CreateProductDTO product)
        {
            if (id <= 0)
                return BadRequest("Invalid id.");

            if (product == null)
                return BadRequest("Invalid request.");

            var request = _mapper.Map<Product>(product);

            var result = await _productsRepository.UpdateProductAsync(id, request);
            if (result)
            {
                return Ok(new { Success = result, Message = "Successfully updated." });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProductAsync(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid id.");

            var result = await _productsRepository.DeleteProductAsync(id);
            if (result)
            {
                return Ok(new { Success = result, Message = "Successfully deleted." });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

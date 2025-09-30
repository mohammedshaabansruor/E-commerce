using Microsoft.AspNetCore.Mvc;
using Services_Abstraction;
using Shared;
using Shared.DTOS;
using Shared.ErrorModels;
using System.Net;

namespace Presentation
{
    [ApiController]
    [Route("/api/[Controller]")]// baseUrl/api/Product
    public class ProductController(IServiceManager serviceManager) : ControllerBase
    {
        //Get /baseyrl/api/Product
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductResult_DTO>>> GetAllProduct([FromQuery]ProductParameterSpecifications parameters)
        {
            var products = await serviceManager.ProductService.GetAllProductAsync(parameters);
            return Ok(products);
        }
        //get /baseyrl/api/Product/brands
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandRsult_DTO>>> GetallBrands()
        {
            var brands = await serviceManager.ProductService.GetAllBrandAsync();
            return Ok(brands);
        }
        //get /baseyrl/api/Product/types
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<ProductResult_DTO>>> GetAllTypes()
        {
            var types = await serviceManager.ProductService.GetAllTypeAsync();
            return Ok(types);
        }
        //get /baseyrl/api/Product/id
        [ProducesResponseType(typeof (ErrorDetails), (int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ValidationErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProductResult_DTO), (int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResult_DTO>> GetProduct(int id)
        {
            var product = await serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
    }
}

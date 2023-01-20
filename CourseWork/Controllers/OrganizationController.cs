using CourseWork.Application.Dtos.Organization;
using CourseWork.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _productService;
        public OrganizationController(IOrganizationService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ResponseService<List<GetOrganizationDto>>>> Get()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseService<GetOrganizationDto>>> GetSingle(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ResponseService<List<GetOrganizationDto>>>> AddProduct(AddOrganizationDto newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }

        [HttpPut]
        public async Task<ActionResult<ResponseService<GetOrganizationDto>>> UpdateProduct(UpdateOrganizationDto updateProduct)
        {
            var response = await _productService.UpdateProduct(updateProduct);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseService<List<GetOrganizationDto>>>> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProduct(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}

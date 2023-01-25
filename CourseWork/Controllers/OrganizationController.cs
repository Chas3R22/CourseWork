using CourseWork.Application.Dtos.OrganizationDto;
using CourseWork.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            return Ok(await _organizationService.GetPage(page, size));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _organizationService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrudOrganizationDto addDto)
        {
            return Ok(await _organizationService.AddAsync(addDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CrudOrganizationDto updateDto)
        {
            return Ok(await _organizationService.UpdateAsync(updateDto, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _organizationService.DeleteAsync(id);
            return NoContent();
        }
    }
}

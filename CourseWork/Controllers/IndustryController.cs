using CourseWork.Application.Dtos.Industry;
using CourseWork.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        private readonly IIndustryService _industryService;
        public IndustryController(IIndustryService industryService)
        {
            _industryService = industryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _industryService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrudIndustryDto createDto)
        {
            return Ok(await _industryService.AddAsync(createDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CrudIndustryDto updateDto)
        {
            return Ok(await _industryService.UpdateAsync(updateDto, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _industryService.DeleteAsync(id);
            return NoContent();
        }
    }
}

using CourseWork.Application.Dtos.CountryDto;
using CourseWork.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _countryService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            return Ok(await _countryService.GetPage(page, size));
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([FromBody] CrudCountryDto createDto)
        {
            return Ok(await _countryService.AddAsync(createDto));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CrudCountryDto updateDto)
        {
            return Ok(await _countryService.UpdateAsync(updateDto, id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _countryService.DeleteAsync(id);
            return NoContent();
        }
    }
}

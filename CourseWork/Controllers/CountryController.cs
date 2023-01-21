using CourseWork.Application.Dtos.Country;
using CourseWork.Application.Services.Interfaces;
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
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(_countryService.GetByIdAsync(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CrudCountryDto createDto)
        {
            return Ok(_countryService.AddAsync(createDto));
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CrudCountryDto updateDto)
        {
            return Ok(_countryService.UpdateAsync(updateDto, id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _countryService.DeleteAsync(id);
            return NoContent();
        }
    }
}

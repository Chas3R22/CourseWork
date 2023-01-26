using CourseWork.Application.Dtos.AuthDto;
using CourseWork.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateAdmin([FromBody] RegisterUserDto register)
        {
            return Ok(await _userService.CreateAdmin(register));
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            return Ok(await _userService.GetPage(page, size));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _userService.GetById(id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}

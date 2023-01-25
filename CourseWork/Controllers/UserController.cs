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
        public IActionResult CreateAdmin([FromBody] RegisterUserDto register)
        {
            return Ok(_userService.CreateAdmin(register));
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            return Ok(_userService.GetPage(page, size));
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete([FromRoute] int id)
        {
            _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}

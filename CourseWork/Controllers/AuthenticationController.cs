using CourseWork.Application.Dtos.AuthDto;
using CourseWork.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserDto register)
        {
            return Ok(_authService.Register(register));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDto login)
        {
            return Ok(_authService.Login(login));
        }

    }
}

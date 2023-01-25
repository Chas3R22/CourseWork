using AutoMapper;
using CourseWork.Application.Dtos.AuthDto;
using CourseWork.Application.Services.Interfaces;
using CourseWork.Domain.Models;
using CourseWork.Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string WrongUserNameOrPass = "Wrong username or password.";

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
        }


        public ResponseUserDto Register(RegisterUserDto register)
        {
            if (_userService.ExistsByUserName(register.Username))
            {
                throw new ConflictException("This username is taken!");
            }

            var user = _mapper.Map<RegisterUserDto, User>(register);

            _userService.AddAsync(user);

            return _mapper.Map<User, ResponseUserDto>(user);
        }

        public ResponseLoginDto Login(LoginUserDto login)
        {
            if (!_userService.ExistsByUserName(login.UserName))
            {
                throw new AuthException(WrongUserNameOrPass, HttpStatusCode.Unauthorized);
            }

            var user = _userService.GetByUserName(login.UserName);

            if (!BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                throw new AuthException(WrongUserNameOrPass, HttpStatusCode.Unauthorized);
            }

            return new ResponseLoginDto(CreateJwtToken(user));
        }

        private string CreateJwtToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:TokenSecret").Value
                    )
                );

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddHours(1)
                );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}

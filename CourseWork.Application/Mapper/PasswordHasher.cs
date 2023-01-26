using AutoMapper;
using CourseWork.Application.Dtos.AuthDto;
using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Mapper
{
    public class PasswordHasher : ITypeConverter<RegisterUserDto, User>
    {
        public User Convert(RegisterUserDto source, User destination, ResolutionContext context)
        {
            return new User
            {
                UserName = source.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(source.Password)
            };
        }
    }
}

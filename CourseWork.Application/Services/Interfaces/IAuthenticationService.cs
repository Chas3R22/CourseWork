using CourseWork.Application.Dtos.AuthDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        ResponseUserDto Register(RegisterUserDto register);

        ResponseLoginDto Login(LoginUserDto login);
    }
}

using CourseWork.Application.Dtos.AuthDto;
using CourseWork.Application.Dtos;
using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Interfaces
{
    public interface IUserService : IGenericService<User>
    {
        ResponseUserDto CreateAdmin(RegisterUserDto register);
        new ResponseUserDto GetById(int id);
        bool ExistsByUserName(string username);
        User GetByUserName(string username);
        new Task<PagingDto<ResponseUserDto>> GetPage(int page, int size);
    }
}

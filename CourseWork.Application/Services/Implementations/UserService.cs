using AutoMapper;
using CourseWork.Application.Dtos;
using CourseWork.Application.Dtos.AuthDto;
using CourseWork.Application.Services.Interfaces;
using CourseWork.Domain.Models;
using CourseWork.Infrastructure.Exceptions;
using CourseWork.Persistence.Repositories.Interfaces;
using LazyCache;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Implementations
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private new readonly IUserRepository _repository;
        public UserService(IUserRepository repository, IAppCache cache, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(repository, cache, mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        public async Task<ResponseUserDto> CreateAdmin(RegisterUserDto register)
        {
            if (ExistsByUserName(register.UserName))
            {
                throw new ConflictException("Username already taken.");
            }

            var user = _mapper.Map<RegisterUserDto, User>(register);
            user.Role = Role.ADMIN;

            await AddAsync(user);

            return _mapper.Map<ResponseUserDto>(user);
        }

        public async new Task<ResponseUserDto> GetById(int id)
        {
            var user = await base.GetByIdAsync(id);

            return _mapper.Map<ResponseUserDto>(user);
        }

        public new async Task<PagingDto<ResponseUserDto>> GetPage(int page, int size)
        {
            var decimalSize = Convert.ToDecimal(size);
            var totalElements = GetCount();

            var entities = await base.GetPage(page, size);
            var paging = new PagingDto<ResponseUserDto>
            {
                Page = page,
                Size = size,
                Content = entities.Select(_mapper.Map<ResponseUserDto>),
                PageCount = Math.Ceiling(totalElements / decimalSize),
                TotalElements = totalElements,
            };

            return paging;
        }

        public bool ExistsByUserName(string username)
        {
            return _repository.ExistsByUserName(username);
        }

        public User GetByUserName(string username)
        {
            if (!ExistsByUserName(username))
            {
                throw new DataNotFoundException("No user exists with this username.");
            }

            var user = _repository.GetByUserName(username);

            return user;
        }
    }
}

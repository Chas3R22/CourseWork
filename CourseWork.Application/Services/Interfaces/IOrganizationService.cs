using CourseWork.Application.Dtos;
using CourseWork.Application.Dtos.OrganizationDto;
using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Interfaces
{
    public interface IOrganizationService : IGenericService<Organization>
    {
        Task<Organization> GetEntityByIdAsync(int id);
        new Task<ResponseOrganizationDto> GetByIdAsync(int id);
        Task<ResponseOrganizationDto> AddAsync(CrudOrganizationDto addDto);
        Task<ResponseOrganizationDto> UpdateAsync(CrudOrganizationDto updateDto, int id);
        new Task<PagingDto<ResponseOrganizationDto>> GetPage(int page, int size);
    }
}

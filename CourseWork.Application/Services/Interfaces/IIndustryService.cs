using CourseWork.Application.Dtos;
using CourseWork.Application.Dtos.IndustryDto;
using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Interfaces
{
    public interface IIndustryService : IGenericService<Industry>
    {
        Task<Industry> GetEntityByIdAsync(int id);
        new Task<ResponseIndustryDto> GetByIdAsync(int id);
        Task<ResponseIndustryDto> AddAsync(CrudIndustryDto addDto);
        Task<ResponseIndustryDto> UpdateAsync(CrudIndustryDto updateDto, int id);
        new Task<PagingDto<ResponseIndustryDto>> GetPage(int page, int size);
    }
}

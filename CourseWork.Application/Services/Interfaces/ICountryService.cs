using CourseWork.Application.Dtos;
using CourseWork.Application.Dtos.CountryDto;
using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Interfaces
{
    public interface ICountryService : IGenericService<Country>
    {
        Task <Country> GetEntityByIdAsync(int id);
        new Task <ResponseCountryDto> GetByIdAsync(int id);
        Task <ResponseCountryDto> AddAsync(CrudCountryDto addDto);
        Task <ResponseCountryDto> UpdateAsync(CrudCountryDto updateDto, int id);
        new Task<PagingDto<ResponseCountryDto>> GetPage(int page, int size);
    }
}

using AutoMapper;
using CourseWork.Application.Dtos.Country;
using CourseWork.Application.Services.Interfaces;
using CourseWork.Domain.Models;
using CourseWork.Persistence.Repositories.Implementations;
using CourseWork.Persistence.Repositories.Interfaces;
using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Implementations
{
    public class CountryService : GenericService<Country>, ICountryService
    {
        
        public CountryService(IGenericRepository<Country> repository, IAppCache cache, IMapper mapper) : base(repository, cache, mapper)
        {
        }

        public async new Task<ResponseCountryDto> GetByIdAsync(int id)
        {
            return _mapper.Map<ResponseCountryDto>(base.GetByIdAsync(id));
        }

        public async Task<Country> GetEntityByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<ResponseCountryDto> AddAsync(CrudCountryDto addDto)
        {
            Country country = _mapper.Map<Country>(addDto);
            await base.AddAsync(country);
            return _mapper.Map<ResponseCountryDto>(country);
        }

        public async Task<ResponseCountryDto> UpdateAsync(CrudCountryDto updateDto, int id)
        {
            Country country = await base.GetByIdAsync(id);
            _mapper.Map(updateDto, country);
            await base.UpdateAsync(country);
            return _mapper.Map<ResponseCountryDto>(country);
        }
    }
}

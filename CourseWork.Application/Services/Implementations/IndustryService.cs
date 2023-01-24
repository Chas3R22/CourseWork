using AutoMapper;
using CourseWork.Application.Dtos.Industry;
using CourseWork.Application.Services.Interfaces;
using CourseWork.Domain.Models;
using CourseWork.Persistence.Repositories.Interfaces;
using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Services.Implementations
{
    public class IndustryService : GenericService<Industry>, IIndustryService
    {

        public IndustryService(IIndustryRepository repository, IAppCache cache, IMapper mapper) : base(repository, cache, mapper)
        {
        }

        public async new Task<ResponseIndustryDto> GetByIdAsync(int id)
        {
            return _mapper.Map<ResponseIndustryDto>(await base.GetByIdAsync(id));
        }

        public async Task<Industry> GetEntityByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<ResponseIndustryDto> AddAsync(CrudIndustryDto addDto)
        {
            var industry = _mapper.Map<Industry>(addDto);
            await base.AddAsync(industry);
            return _mapper.Map<ResponseIndustryDto>(industry);
        }

        public async Task<ResponseIndustryDto> UpdateAsync(CrudIndustryDto updateDto, int id)
        {
            var industry = await base.GetByIdAsync(id);
            _mapper.Map(updateDto, industry);
            await base.UpdateAsync(industry);
            return _mapper.Map<ResponseIndustryDto>(industry);
        }
    }
}

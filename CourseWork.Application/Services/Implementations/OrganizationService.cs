using CourseWork.Application.Services.Interfaces;
using CourseWork.Domain.Models;
using LazyCache;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.Persistence.Repositories.Interfaces;
using CourseWork.Application.Dtos.OrganizationDto;

namespace CourseWork.Application.Services.Implementations
{
    public class OrganizationService : GenericService<Organization>, IOrganizationService
    {
        private readonly ICountryService _countryService;
        private readonly IIndustryService _industryService;

        public OrganizationService(ICountryService countryService, IIndustryService industryService, IOrganizationRepository repository, IAppCache cache, IMapper mapper) : base(repository, cache, mapper)
        {
            _countryService = countryService;
            _industryService = industryService;
        }

        public async new Task<ResponseOrganizationDto> GetByIdAsync(int id)
        {
            return _mapper.Map<ResponseOrganizationDto>(await base.GetByIdAsync(id));
        }

        public async Task<Organization> GetEntityByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<ResponseOrganizationDto> AddAsync(CrudOrganizationDto addDto)
        {
            var organization = _mapper.Map<Organization>(addDto);

            await SetOrganizationCountry(addDto.CountryId, organization);

            await SetOrganizationIndustry(addDto.IndustryId, organization);

            await base.AddAsync(organization);
            return _mapper.Map<ResponseOrganizationDto>(organization);
        }

        public async Task<ResponseOrganizationDto> UpdateAsync(CrudOrganizationDto updateDto, int id)
        {
            var organization = await base.GetByIdAsync(id);
            _mapper.Map(updateDto, organization);

            await SetOrganizationCountry(updateDto.CountryId, organization);

            await SetOrganizationIndustry(updateDto.IndustryId, organization);

            await base.UpdateAsync(organization);
            return _mapper.Map<ResponseOrganizationDto>(organization);
        }

        private async Task SetOrganizationCountry(int countryId, Organization organization)
        {
            organization.Country = await _countryService.GetEntityByIdAsync(countryId);
        }

        private async Task SetOrganizationIndustry(int industryId, Organization organization)
        {
            organization.Industry = await _industryService.GetEntityByIdAsync(industryId);
        }

    }
}

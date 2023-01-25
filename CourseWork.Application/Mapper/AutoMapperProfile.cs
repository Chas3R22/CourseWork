using AutoMapper;
using CourseWork.Application.Dtos.CountryDto;
using CourseWork.Application.Dtos.IndustryDto;
using CourseWork.Application.Dtos.OrganizationDto;
using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CrudCountryDto, Country>();
            CreateMap<Country, ResponseCountryDto>();

            CreateMap<CrudIndustryDto, Industry>();
            CreateMap<Industry, ResponseIndustryDto>();

            CreateMap<CrudOrganizationDto, Organization>();
            CreateMap<Organization, ResponseOrganizationDto>();
        }
    }
}

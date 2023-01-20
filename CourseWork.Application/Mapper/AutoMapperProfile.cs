using AutoMapper;
using CourseWork.Application.Dtos.Organization;
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
            CreateMap<Organization, GetOrganizationDto>();
            CreateMap<AddOrganizationDto, Organization>();
            CreateMap<UpdateOrganizationDto, Organization>();
        }
    }
}

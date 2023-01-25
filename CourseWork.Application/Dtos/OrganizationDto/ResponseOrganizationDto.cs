using CourseWork.Application.Dtos.IndustryDto;
using CourseWork.Application.Dtos.CountryDto;
using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Dtos.OrganizationDto
{
    public class ResponseOrganizationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public ResponseCountryDto Country { get; set; }
        public string Description { get; set; }
        public int Founded { get; set; }
        public ResponseIndustryDto Industry { get; set; }
        public int EmployeeAmounts { get; set; }
    }
}

using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Dtos.Organization
{
    public class UpdateOrganizationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Industry Category { get; set; }
        public decimal Price { get; set; }
    }
}

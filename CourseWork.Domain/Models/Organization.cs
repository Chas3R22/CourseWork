using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Domain.Models
{
    public class Organization
    {
        public Organization()
        {

        }

        public Organization(string organizationName)
        {
            Name = organizationName;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public Country Country { get; set; }
        public string Description { get; set; }
        public int Founded { get; set; }
        public Industry Industry { get; set; }
        public int EmployeeAmounts { get; set; }
    }
}

using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Dtos.OrganizationDto
{
    public class CrudOrganizationDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name is too short. Must be minimum 3 characters.")]
        [MaxLength(128, ErrorMessage = "Name is too long. Must be maximum 128 characters.")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Website address is too short. Must be minimum 3 characters.")]
        [MaxLength(256, ErrorMessage = "Website address is too long. Must be maximum 256 characters.")]
        public string Website { get; set; }
        [Required]
        public int CountryId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Description is too short. Must be minimum 3 characters.")]
        [MaxLength(256, ErrorMessage = "Description is too long. Must be maximum 256 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(1700, 2023)]
        public int Founded { get; set; }
        [Required]
        public int IndustryId { get; set; }
        [Required]
        public int EmployeeAmounts { get; set; }
    }
}

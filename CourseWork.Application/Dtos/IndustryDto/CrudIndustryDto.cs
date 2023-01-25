using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Dtos.IndustryDto
{
    public class CrudIndustryDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name is too short. Must be minimum 3 characters.")]
        [MaxLength(50, ErrorMessage = "Name is too long. Must be maximum 50 characters.")]
        public string Name { get; set; }
    }
}

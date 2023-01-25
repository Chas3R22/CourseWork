using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Dtos.AuthDto
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Username required.")]
        [MinLength(3, ErrorMessage = "Username cannot be less than 3 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#+\-=^_()/\\.,<>""':;])[A-Za-z\d@$!%*?&#+\-=^_()/\\.,<>""':;]{8,}$",
            ErrorMessage = "Password cannot be less than 8 characters. " +
            "It must contain one uppercase letter, one lowercase letter, " +
            "one number and one special character at least.")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}

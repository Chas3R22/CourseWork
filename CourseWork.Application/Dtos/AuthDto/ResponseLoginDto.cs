using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Dtos.AuthDto
{
    public class ResponseLoginDto
    {
        public string JwtToken { get; }

        public ResponseLoginDto(string jwtToken)
        {
            JwtToken = jwtToken;
        }
    }
}

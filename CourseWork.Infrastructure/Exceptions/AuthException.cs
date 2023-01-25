using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Infrastructure.Exceptions
{
    public class AuthException : CustomHttpException
    {
        public AuthException(string? message, HttpStatusCode statusCode) : base(message, statusCode)
        {
        }
    }
}

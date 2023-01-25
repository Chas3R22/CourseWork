using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Infrastructure.Exceptions
{
    public class ConflictException : CustomHttpException
    {
        public ConflictException(string? message) : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}

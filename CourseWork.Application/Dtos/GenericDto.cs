using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Dtos
{
    public class GenericDto<T>
    {
        public T Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Application.Dtos
{
    public class PagingDto<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public IEnumerable<T> Content { get; set; } = new List<T>();
        public decimal PageCount { get; set; }
        public int TotalElements { get; set; }
    }
}

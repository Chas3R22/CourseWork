using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Domain.Models
{
    public class Industry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Organization> Products { get; set; }
    }
}


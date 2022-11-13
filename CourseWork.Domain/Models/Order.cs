using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Domain.Models
{
    public class Order : BaseModel
    {
        public string ProductName { get; set; }
        public string ClientName { get; set; }
        public string Location { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
    }
}

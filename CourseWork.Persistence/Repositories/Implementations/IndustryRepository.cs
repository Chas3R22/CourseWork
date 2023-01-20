using CourseWork.Domain.Models;
using CourseWork.Persistence.Data;
using CourseWork.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Persistence.Repositories.Implementations
{
    public class IndustryRepository : GenericRepository<Industry>,IIndustryRepository
    {
        public IndustryRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}

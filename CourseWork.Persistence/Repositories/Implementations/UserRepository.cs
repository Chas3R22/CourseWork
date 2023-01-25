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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public bool ExistsByUserName(string username)
        {
            return _dbContext.Set<User>().Any(u => u.UserName == username);
        }

        public User GetByUserName(string username)
        {
            return _dbContext.Set<User>().First(u => u.UserName == username);
        }
    }
}

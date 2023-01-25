using CourseWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Persistence.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool ExistsByUserName(string username);
        User GetByUserName(string username);
    }
}

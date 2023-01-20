using CourseWork.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Country> Countries { get; set; }



    }
}

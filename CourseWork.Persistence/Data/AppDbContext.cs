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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    UserName = "AppAdminDefault",
                    Password = "$2a$12$9fy1u.cHyuRvkQ48zHBfJ.H0aQJRm5EJ2aKS7Ag3tROqVcWpjyp7m",
                    Role = Role.ADMIN
                });

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion<string>()
                .HasColumnType("nvarchar(max)");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<Organization>()
                .Navigation(o => o.Country)
                .AutoInclude();

            modelBuilder.Entity<Organization>()
                .Navigation(o => o.Industry)
                .AutoInclude();
        }
    }
}

using Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Configuration;

namespace Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        DbSet<Employee> employees { get; set; }
        DbSet<Company> companies { get; set; }
    }
}

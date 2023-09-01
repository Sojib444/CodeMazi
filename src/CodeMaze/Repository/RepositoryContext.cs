using Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext :DbContext, IRepositoryContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company>? companies { get; set; }
        public DbSet<Employee>? employees { get; set; }
    }
}

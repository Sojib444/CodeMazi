using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext :DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company>? companies { get; set; }
        public DbSet<Employee>? employees { get; set; }
    }
}

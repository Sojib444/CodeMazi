using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository.Context;
using System.Reflection;

namespace CodeMaze.ContextFactories
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("connectionstring"),
                m=>m.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));

            return new ApplicationDbContext(builder.Options);

        }
    }
}

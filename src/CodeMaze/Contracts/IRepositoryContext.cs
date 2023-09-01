using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Contracts
{
    public interface IRepositoryContext
    {
         DbSet<Company>? companies { get; set; }
         DbSet<Employee>? employees { get; set; }
    }
}

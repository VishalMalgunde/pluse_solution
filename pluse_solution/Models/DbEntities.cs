using Microsoft.EntityFrameworkCore;
using pluse_solution.Models;

namespace pluse_solution.Models
{
    public class DbEntities : DbContext
    {
        public DbEntities(DbContextOptions<DbEntities> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}


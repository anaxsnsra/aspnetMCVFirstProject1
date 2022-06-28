using aspneMVCProject1.Models;
using Microsoft.EntityFrameworkCore;

namespace aspneMVCProject1.Data
{
    public class applicationDBContext : DbContext
    {
        private readonly DbContext dbContext;
        public applicationDBContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }

    }
}

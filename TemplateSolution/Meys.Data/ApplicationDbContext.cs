using Meys.Data.Mappings;
using Meys.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meys.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping()); 
        }
    }
}

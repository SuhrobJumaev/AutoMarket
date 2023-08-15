
using AutoMarket.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> car { get; set; } 
    }
}

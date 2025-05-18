// src/YurttaYe.Infrastructure/Persistence/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using YurttaYe.Domain.Entities;

namespace YurttaYe.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
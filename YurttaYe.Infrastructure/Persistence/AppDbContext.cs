// src/YurttaYe.Infrastructure/Persistence/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using YurttaYe.Domain.Entities;
using YurttaYe.Infrastructure.Persistence.Configurations;

namespace YurttaYe.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MenuItemConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
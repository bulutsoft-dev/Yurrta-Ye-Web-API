// src/YurttaYe.Infrastructure/Persistence/Configurations/MenuItemConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurttaYe.Domain.Entities;

namespace YurttaYe.Infrastructure.Persistence.Configurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Category).IsRequired().HasMaxLength(50);
            builder.OwnsOne(m => m.Gramaj, g =>
            {
                g.Property(x => x.Value).IsRequired();
                g.Property(x => x.Unit).IsRequired().HasMaxLength(10);
            });
            builder.OwnsOne(m => m.Price, p =>
            {
                p.Property(x => x.Value);
                p.Property(x => x.Currency).HasMaxLength(3);
            });
            builder.OwnsOne(m => m.Calorie, c =>
            {
                c.Property(x => x.Value);
            });
            builder.Property(m => m.Date).IsRequired();
            builder.HasOne(m => m.Menu).WithMany(m => m.Items).HasForeignKey(m => m.MenuId);
        }
    }
}
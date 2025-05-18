// src/YurttaYe.Infrastructure/Persistence/Configurations/MenuItemConfiguration.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurttaYe.Domain.Entities;
using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Infrastructure.Persistence.Configurations
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Category).IsRequired().HasMaxLength(50);

            // Gramaj: Owned Type
            builder.OwnsOne(m => m.Gramaj, g =>
            {
                g.Property(x => x.Value).IsRequired().HasColumnName("GramajValue");
                g.Property(x => x.Unit).IsRequired().HasMaxLength(10).HasColumnName("GramajUnit");
            });

            // Price: Owned Type (Opsiyonel)
            builder.OwnsOne(m => m.Price, p =>
            {
                p.Property(x => x.Value).HasColumnName("PriceValue").HasColumnType("decimal(18,2)");
                p.Property(x => x.Currency).HasMaxLength(3).HasColumnName("PriceCurrency");
            });

            // Calorie: Owned Type (Opsiyonel)
            builder.OwnsOne(m => m.Calorie, c =>
            {
                c.Property(x => x.Value).HasColumnName("CalorieValue").HasColumnType("decimal(18,2)");
            });
        }
    }

    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Date).IsRequired();
            builder.Property(m => m.DayOfWeek).IsRequired().HasMaxLength(20);

            // TotalCalorie: Owned Type
            builder.OwnsOne(m => m.TotalCalorie, tc =>
            {
                tc.OwnsOne(x => x.Min, min => min.Property(c => c.Value).HasColumnName("MinCalorie").HasColumnType("decimal(18,2)"));
                tc.OwnsOne(x => x.Max, max => max.Property(c => c.Value).HasColumnName("MaxCalorie").HasColumnType("decimal(18,2)"));
            });

            // MenuItem ile bir-çok ilişki
            builder.HasMany(m => m.Items).WithOne().HasForeignKey("MenuId").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurttaYe.Domain.Entities;

namespace YurttaYe.Infrastructure.Persistence.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Date).IsRequired();
            builder.Property(m => m.DayOfWeek).IsRequired().HasMaxLength(20);
            builder.OwnsOne(m => m.TotalCalorie, tc =>
            {
                tc.OwnsOne(x => x.Min, c => c.Property(y => y.Value).IsRequired());
                tc.OwnsOne(x => x.Max, c => c.Property(y => y.Value).IsRequired());
            });
        }
    }
}
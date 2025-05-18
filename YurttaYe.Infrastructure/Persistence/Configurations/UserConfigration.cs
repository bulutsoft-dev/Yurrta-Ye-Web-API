using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YurttaYe.Domain.Entities;

namespace YurttaYe.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(100); // Hash'lenmeli
            builder.Property(u => u.Role).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.Username).IsUnique();
        }
    }
}
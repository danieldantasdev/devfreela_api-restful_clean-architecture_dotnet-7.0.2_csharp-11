using DevFreela.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("user").HasKey(p => p.Id);
        
        entityTypeBuilder
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(u => u.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
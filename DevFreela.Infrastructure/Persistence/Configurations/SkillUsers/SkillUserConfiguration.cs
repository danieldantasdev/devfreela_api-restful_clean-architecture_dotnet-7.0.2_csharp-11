using DevFreela.Core.Entities.Skills;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations.UserSkills;

public class SkillUserConfiguration : IEntityTypeConfiguration<SkillUser>
{
    public void Configure(EntityTypeBuilder<SkillUser> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("skill_user").HasKey(s => s.Id);
    }
}
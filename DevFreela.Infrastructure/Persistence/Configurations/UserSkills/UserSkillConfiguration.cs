using DevFreela.Core.Entities.Skills;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations.UserSkills;

public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
{
    public void Configure(EntityTypeBuilder<UserSkill> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("user_skill").HasKey(p => p.Id);
    }
}
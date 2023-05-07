using DevFreela.Core.Entities.Skills;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations.Skills;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("skill").HasKey(p => p.Id);
    }
}
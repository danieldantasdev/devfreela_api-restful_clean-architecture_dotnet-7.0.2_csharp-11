using DevFreela.Core.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations.Projects;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("project").HasKey(p => p.Id);

        entityTypeBuilder
            .HasOne(p => p.Freelancer)
            .WithMany(f => f.FreelanceProjects)
            .HasForeignKey(p => p.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);

        entityTypeBuilder
            .HasOne(p => p.Client)
            .WithMany(c => c.OwnedProjects)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
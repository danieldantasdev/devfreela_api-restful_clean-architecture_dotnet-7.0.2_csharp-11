using DevFreela.Core.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations.ProjectComments;

public class ProjectCommentsConfiguration : IEntityTypeConfiguration<ProjectComment>
{
    public void Configure(EntityTypeBuilder<ProjectComment> entityTypeBuilder)
    {
        entityTypeBuilder.ToTable("project_comment").HasKey(p => p.Id);
        entityTypeBuilder
            .HasOne(p => p.User)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
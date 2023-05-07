using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Entities.Skills;
using DevFreela.Core.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext : DbContext
{
    public DbSet<Project> Projects { get; private set; }
    public DbSet<ProjectComment> ProjectComments { get; private set; }
    public DbSet<User> Users { get; private set; }
    public DbSet<UserSkill> UserSkills { get; private set; }
    public DbSet<Skill> Skills { get; private set; }

    public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
}
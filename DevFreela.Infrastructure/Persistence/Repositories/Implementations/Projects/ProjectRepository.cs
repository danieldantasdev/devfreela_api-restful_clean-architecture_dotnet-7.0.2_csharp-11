using Dapper;
using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistence.Context;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Projects;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories.Implementations.Projects;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaDbContext _devFreelaDbContext;
    private readonly string _connectionString;
    
    public ProjectRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
    {
        _devFreelaDbContext = dbContext;
        _connectionString = configuration.GetConnectionString("DevFreelaConnectionString");
    }

    public async Task<List<Project>> GetAllAsync()
    {
        return await _devFreelaDbContext.Projects.ToListAsync();
    }

    public async Task<Project> GetDetailsByIdAsync(int id)
    {
        return await _devFreelaDbContext.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Project project)
    {
        await _devFreelaDbContext.Projects.AddAsync(project);
        await _devFreelaDbContext.SaveChangesAsync();
    }

    public async Task StartAsync(Project project)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();

            var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE Id = @id";

            await sqlConnection.ExecuteAsync(script, new { status = project.Status, startedat = project.StartedAt, project.Id });
        }
    }

    public async Task SaveChangesAsync()
    {
        await _devFreelaDbContext.SaveChangesAsync();
    }

    public async Task<Project> GetByIdAsync(int id)
    {
        return await _devFreelaDbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddCommentAsync(ProjectComment projectComment)
    {
        await _devFreelaDbContext.ProjectComments.AddAsync(projectComment);
        await _devFreelaDbContext.SaveChangesAsync();
    }
}
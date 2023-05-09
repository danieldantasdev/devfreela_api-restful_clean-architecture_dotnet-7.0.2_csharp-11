using DevFreela.Core.Entities.Projects;

namespace DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Projects;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
    Task<Project> GetDetailsByIdAsync(int id);
    Task<Project> GetByIdAsync(int id);
    Task AddAsync(Project project);
    Task StartAsync(Project project);
    Task AddCommentAsync(ProjectComment projectComment);
    Task SaveChangesAsync();
}
using DevFreela.Core.Dtos.Paginations;
using DevFreela.Core.Entities.Projects;

namespace DevFreela.Core.Repositories.Interfaces.Projects;

public interface IProjectRepository
{
    Task<PaginationResultDto<Project>> GetAllAsync(string query, int page, int pageSize);
    Task<Project> GetDetailsByIdAsync(int id);
    Task<Project> GetByIdAsync(int id);
    Task AddAsync(Project project);
    Task StartAsync(Project project);
    Task AddCommentAsync(ProjectComment projectComment);
    Task SaveChangesAsync();
    Task UpdateAsync(Project project);
}
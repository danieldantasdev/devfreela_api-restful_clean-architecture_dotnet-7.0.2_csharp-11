using DevFreela.Core.Repositories.Interfaces.Projects;
using DevFreela.Core.Repositories.Interfaces.Skills;
using DevFreela.Core.Repositories.Interfaces.Users;

namespace DevFreela.Core.Services.Interfaces.UnitOfWorks;

public interface IUnitOfWorkService
{
    IProjectRepository ProjectRepository { get; }
    IUserRepository UserRepository { get; }
    ISkillRepository SkillRepository { get; }
    Task BeginTransactionAsync();
    Task<int> CompleteTransactionAsync();
    Task CommmitTransactionAsync();
}
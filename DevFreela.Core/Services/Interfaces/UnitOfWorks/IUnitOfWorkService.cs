using DevFreela.Core.Repositories.Interfaces.Projects;
using DevFreela.Core.Repositories.Interfaces.Users;

namespace DevFreela.Core.Services.Interfaces.UnitOfWorks;

public interface IUnitOfWorkService
{
    IProjectRepository ProjectRepository { get; }
    IUserRepository UserRepository { get; }
    Task<int> CompleteAsync();
}
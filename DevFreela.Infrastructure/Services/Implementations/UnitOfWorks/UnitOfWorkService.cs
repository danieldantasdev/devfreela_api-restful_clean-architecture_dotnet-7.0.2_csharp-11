using DevFreela.Core.Repositories.Interfaces.Projects;
using DevFreela.Core.Repositories.Interfaces.Users;
using DevFreela.Core.Services.Interfaces.UnitOfWorks;
using DevFreela.Infrastructure.Persistence.Context;

namespace DevFreela.Infrastructure.Services.Implementations.UnitOfWorks;

public class UnitOfWorkService : IUnitOfWorkService
{
    public IProjectRepository ProjectRepository { get; }
    public IUserRepository UserRepository { get; }
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public UnitOfWorkService(IProjectRepository projectRepository, IUserRepository userRepository,
        DevFreelaDbContext devFreelaDbContext)
    {
        ProjectRepository = projectRepository;
        UserRepository = userRepository;
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<int> CompleteAsync()
    {
        return await _devFreelaDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _devFreelaDbContext.Dispose();
        }
    }
}
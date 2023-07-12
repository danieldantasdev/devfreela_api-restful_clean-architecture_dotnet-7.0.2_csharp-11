using DevFreela.Core.Repositories.Interfaces.Projects;
using DevFreela.Core.Repositories.Interfaces.Skills;
using DevFreela.Core.Repositories.Interfaces.Users;
using DevFreela.Core.Services.Interfaces.UnitOfWorks;
using DevFreela.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace DevFreela.Infrastructure.Services.Implementations.UnitOfWorks;

public class UnitOfWorkService : IUnitOfWorkService
{
    public IProjectRepository ProjectRepository { get; }
    public IUserRepository UserRepository { get; }
    public ISkillRepository SkillRepository { get; }
    private IDbContextTransaction _dbContextTransaction;
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public UnitOfWorkService(IProjectRepository projectRepository, IUserRepository userRepository,
        ISkillRepository skillRepository, IDbContextTransaction dbContextTransaction,
        DevFreelaDbContext devFreelaDbContext)
    {
        ProjectRepository = projectRepository;
        UserRepository = userRepository;
        SkillRepository = skillRepository;
        _dbContextTransaction = dbContextTransaction;
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task BeginTransactionAsync()
    {
        _dbContextTransaction = await _devFreelaDbContext.Database.BeginTransactionAsync();
    }

    public async Task<int> CompleteTransactionAsync()
    {
        return await _devFreelaDbContext.SaveChangesAsync();
    }

    public async Task CommmitTransactionAsync()
    {
        try
        {
            await _dbContextTransaction.CommitAsync();
        }
        catch (Exception e)
        {
            await _dbContextTransaction.RollbackAsync();
            throw;
        }
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
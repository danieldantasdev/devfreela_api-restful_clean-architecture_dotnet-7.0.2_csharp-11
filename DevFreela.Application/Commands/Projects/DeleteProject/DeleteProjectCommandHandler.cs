using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;

namespace DevFreela.Application.Commands.Projects.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public DeleteProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<Unit> Handle(DeleteProjectCommand deleteProjectCommand, CancellationToken cancellationToken)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == deleteProjectCommand.Id);
        project?.Cancel();
        await _devFreelaDbContext.SaveChangesAsync();
        
        return Unit.Value;
    }
}
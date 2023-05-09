using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;

namespace DevFreela.Application.Commands.Projects.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public FinishProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<Unit> Handle(FinishProjectCommand finishProjectCommand, CancellationToken cancellationToken)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == finishProjectCommand.Id);
        project.Finish();
        await _devFreelaDbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
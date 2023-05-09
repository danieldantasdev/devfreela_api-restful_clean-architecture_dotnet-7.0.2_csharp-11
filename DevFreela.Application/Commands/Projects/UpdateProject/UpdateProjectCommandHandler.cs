using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;

namespace DevFreela.Application.Commands.Projects.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public UpdateProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<Unit> Handle(UpdateProjectCommand updateProjectCommand, CancellationToken cancellationToken)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == updateProjectCommand.Id);
        project.Update(updateProjectCommand.Title, updateProjectCommand.Description,
            updateProjectCommand.TotalCost);
        await _devFreelaDbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
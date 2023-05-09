using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public CreateProjectCommandHandler(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<int> Handle(CreateProjectCommand createProjectCommand, CancellationToken cancellationToken)
    {
        var project = new Project(createProjectCommand.Title, createProjectCommand.Description,
            createProjectCommand.IdClient, createProjectCommand.IdFreelance, createProjectCommand.TotalCost);
        await _devFreelaDbContext.Projects.AddAsync(project);
        await _devFreelaDbContext.SaveChangesAsync();

        return project.Id;
    }
}
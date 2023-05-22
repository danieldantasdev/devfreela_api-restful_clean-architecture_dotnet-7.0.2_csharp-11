using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.StartProject;

public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public StartProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<Unit> Handle(StartProjectCommand startProjectCommand, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(startProjectCommand.Id);

        project.Start();

        await _projectRepository.StartAsync(project);

        return Unit.Value;
    }
}
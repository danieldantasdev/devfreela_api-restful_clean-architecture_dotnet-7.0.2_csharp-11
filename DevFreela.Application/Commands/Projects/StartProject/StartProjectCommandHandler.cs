using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.StartProject;

public class StartProjectCommandHandler : IRequestHandler<StartProjectCommandInputModel, StartProjectCommandViewModel>
{
    private readonly IProjectRepository _projectRepository;

    public StartProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task<StartProjectCommandViewModel> Handle(StartProjectCommandInputModel startProjectCommandInputModel, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(startProjectCommandInputModel.Id);

        project.Start();

        await _projectRepository.StartAsync(project);

        return new StartProjectCommandViewModel();
    }
}
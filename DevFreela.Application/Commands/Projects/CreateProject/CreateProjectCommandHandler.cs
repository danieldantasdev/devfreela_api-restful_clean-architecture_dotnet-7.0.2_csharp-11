using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<int> Handle(CreateProjectCommand createProjectCommand, CancellationToken cancellationToken)
    {
        var project = new Project(createProjectCommand.Title, createProjectCommand.Description, createProjectCommand.IdClient, createProjectCommand.IdFreelancer, createProjectCommand.TotalCost);

        await _projectRepository.AddAsync(project);

        return project.Id;
    }
}
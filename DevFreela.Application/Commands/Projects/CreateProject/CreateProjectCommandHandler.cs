using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommandInputModel, CreateProjectCommandViewModel>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<CreateProjectCommandViewModel> Handle(CreateProjectCommandInputModel createProjectCommandInputModel, CancellationToken cancellationToken)
    {
        var project = new Project(createProjectCommandInputModel.Title, createProjectCommandInputModel.Description, createProjectCommandInputModel.IdClient, createProjectCommandInputModel.IdFreelancer, createProjectCommandInputModel.TotalCost);

        await _projectRepository.AddAsync(project);

        return new CreateProjectCommandViewModel(project.Id);
    }
}
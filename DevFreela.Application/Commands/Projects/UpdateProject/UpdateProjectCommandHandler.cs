using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(UpdateProjectCommand updateProjectCommand, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(updateProjectCommand.Id);

        project.Update(updateProjectCommand.Title, updateProjectCommand.Description, updateProjectCommand.TotalCost);

        await _projectRepository.SaveChangesAsync();

        return Unit.Value;
    }
}
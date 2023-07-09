using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.UpdateProject;

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommandInputModel, UpdateProjectCommandViewModel>
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<UpdateProjectCommandViewModel> Handle(UpdateProjectCommandInputModel updateProjectCommandInputModel, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(updateProjectCommandInputModel.Id);

        project.Update(updateProjectCommandInputModel.Title, updateProjectCommandInputModel.Description, updateProjectCommandInputModel.TotalCost);

        await _projectRepository.SaveChangesAsync();

        return new UpdateProjectCommandViewModel();
    }
}
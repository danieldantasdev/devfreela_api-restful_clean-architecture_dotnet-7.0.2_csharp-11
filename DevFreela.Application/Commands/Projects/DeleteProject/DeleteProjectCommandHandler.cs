using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommandInputModel, DeleteProjectCommandViewModel>
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }


    public async Task<DeleteProjectCommandViewModel> Handle(DeleteProjectCommandInputModel deleteProjectCommandInputModel, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(deleteProjectCommandInputModel.Id);

        project.Cancel();

        await _projectRepository.SaveChangesAsync();

        return new DeleteProjectCommandViewModel();
    }
}
using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.DeleteProject;

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }


    public async Task<Unit> Handle(DeleteProjectCommand deleteProjectCommand, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(deleteProjectCommand.Id);

        project.Cancel();

        await _projectRepository.SaveChangesAsync();

        return Unit.Value;
    }
}
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public FinishProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }


    public async Task<Unit> Handle(FinishProjectCommand finishProjectCommand, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(finishProjectCommand.Id);

        project.Finish();

        await _projectRepository.SaveChangesAsync();

        return Unit.Value;
    }
}
using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public CreateCommentCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(CreateCommentCommand createCommentCommand, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(createCommentCommand.Content, createCommentCommand.IdProject, createCommentCommand.IdUser);

        await _projectRepository.AddCommentAsync(comment);

        return Unit.Value;
    }
}
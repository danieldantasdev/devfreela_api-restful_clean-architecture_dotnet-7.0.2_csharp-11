using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
{
    private DevFreelaDbContext _devFreelaDbContext;

    public CreateCommentCommandHandler(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<Unit> Handle(CreateCommentCommand createCommentCommand, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(createCommentCommand.Content,
            createCommentCommand.IdProject, createCommentCommand.IdUser);
        await _devFreelaDbContext.ProjectComments.AddAsync(comment);
        await _devFreelaDbContext.SaveChangesAsync();

        return Unit.Value;
    }
}
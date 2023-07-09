using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandInputModel, CreateCommentCommandViewModel>
{
    private readonly IProjectRepository _projectRepository;

    public CreateCommentCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<CreateCommentCommandViewModel> Handle(CreateCommentCommandInputModel createCommentCommandInputModel, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(createCommentCommandInputModel.Content, createCommentCommandInputModel.IdProject, createCommentCommandInputModel.IdUser);

        await _projectRepository.AddCommentAsync(comment);

        return new CreateCommentCommandViewModel();
    }
}
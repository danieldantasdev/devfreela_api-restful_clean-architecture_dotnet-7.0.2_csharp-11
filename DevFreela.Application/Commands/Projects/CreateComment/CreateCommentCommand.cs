using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateComment;

public class CreateCommentCommand : IRequest<Unit>
{
    public string Content { get; set; }
    public int IdProject { get; set; }
    public int IdUser { get; set; }
}
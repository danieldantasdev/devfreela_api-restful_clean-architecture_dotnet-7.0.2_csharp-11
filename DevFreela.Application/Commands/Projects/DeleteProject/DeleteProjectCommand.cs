using MediatR;

namespace DevFreela.Application.Commands.Projects.DeleteProject;

public class DeleteProjectCommand : IRequest<Unit>
{
    public int Id { get; private set; }

    public DeleteProjectCommand(int id)
    {
        Id = id;
    }
}
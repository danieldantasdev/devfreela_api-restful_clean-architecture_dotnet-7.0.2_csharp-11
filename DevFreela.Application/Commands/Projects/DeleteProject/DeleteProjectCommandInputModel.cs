using MediatR;

namespace DevFreela.Application.Commands.Projects.DeleteProject;

public class DeleteProjectCommandInputModel : IRequest<DeleteProjectCommandViewModel>
{
    public int Id { get; private set; }

    public DeleteProjectCommandInputModel(int id)
    {
        Id = id;
    }
}
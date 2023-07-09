using MediatR;

namespace DevFreela.Application.Commands.Projects.StartProject;

public class StartProjectCommandInputModel : IRequest<StartProjectCommandViewModel>
{
    public int Id { get; private set; }

    public StartProjectCommandInputModel(int id)
    {
        Id = id;
    }
}
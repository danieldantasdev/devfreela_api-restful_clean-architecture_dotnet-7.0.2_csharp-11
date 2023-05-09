using DevFreela.Application.ViewModels.Projects;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetProjectById;

public class GetProjectByIdQuery : IRequest<GetProjectByIdViewModel>
{
    public GetProjectByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
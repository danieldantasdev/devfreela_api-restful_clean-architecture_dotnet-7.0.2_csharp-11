using DevFreela.Application.ViewModels.Projects;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetProjectById;

public class GetProjectByIdQueryInputModel : IRequest<GetProjectByIdQueryViewModel>
{
    public GetProjectByIdQueryInputModel(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
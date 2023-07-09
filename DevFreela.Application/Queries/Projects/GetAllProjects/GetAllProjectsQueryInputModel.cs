using MediatR;

namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectsQueryInputModel : IRequest<List<GetAllProjectsQueryViewModel>>
{
    public GetAllProjectsQueryInputModel(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}
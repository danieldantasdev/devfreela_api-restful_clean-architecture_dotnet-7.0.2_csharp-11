using DevFreela.Application.ViewModels.Projects;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectsQuery : IRequest<List<GetAllProjectsViewModel>>
{
    public GetAllProjectsQuery(string query)
    {
        Query = query;
    }

    public string Query { get; private set; }
}
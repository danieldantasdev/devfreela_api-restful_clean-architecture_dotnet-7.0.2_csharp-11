using DevFreela.Core.Dtos.Paginations;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectsQueryInputModel : IRequest<PaginationResultDto<GetAllProjectsQueryViewModel>>
{
    public string? Query { get; set; }
    public int Page { get; set; } = 1;
}
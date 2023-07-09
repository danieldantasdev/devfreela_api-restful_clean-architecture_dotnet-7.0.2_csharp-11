using DevFreela.Core.Dtos.Paginations;
using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQueryInputModel,
    PaginationResultDto<GetAllProjectsQueryViewModel>>
{
    private readonly IProjectRepository _projectRepository;

    public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<PaginationResultDto<GetAllProjectsQueryViewModel>> Handle(
        GetAllProjectsQueryInputModel getAllSkillsQueryInputModel,
        CancellationToken cancellationToken)
    {
        var paginationProjects =
            await _projectRepository.GetAllAsync(getAllSkillsQueryInputModel.Query, getAllSkillsQueryInputModel.Page);

        var getAllProjectViewModel = paginationProjects.Data
            .Select(p => new GetAllProjectsQueryViewModel(p.Id, p.Title, p.Description, p.CreatedAt))
            .ToList();

        var paginationProjectsViewModel = new PaginationResultDto<GetAllProjectsQueryViewModel>(
            paginationProjects.Page,
            paginationProjects.TotalPages,
            paginationProjects.PageSize,
            paginationProjects.ItemsCount,
            getAllProjectViewModel
        );

        return paginationProjectsViewModel;
    }
}
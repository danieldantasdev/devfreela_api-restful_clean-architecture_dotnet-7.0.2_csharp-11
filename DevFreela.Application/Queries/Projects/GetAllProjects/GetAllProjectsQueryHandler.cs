using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQueryInputModel, List<GetAllProjectsQueryViewModel>>
{
    private readonly IProjectRepository _projectRepository;

    public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<GetAllProjectsQueryViewModel>> Handle(GetAllProjectsQueryInputModel getAllSkillsQueryInputModel,
        CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetAllAsync();

        var getAllProjectViewModel = projects.Select(p => new GetAllProjectsQueryViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

        return getAllProjectViewModel;
    }
}
using DevFreela.Application.ViewModels.Projects;
using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<GetAllProjectsViewModel>>
{
    private readonly IProjectRepository _projectRepository;

    public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<List<GetAllProjectsViewModel>> Handle(GetAllProjectsQuery getAllSkillsQuery,
        CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetAllAsync();

        var getAllProjectViewModel = projects.Select(p => new GetAllProjectsViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();

        return getAllProjectViewModel;
    }
}
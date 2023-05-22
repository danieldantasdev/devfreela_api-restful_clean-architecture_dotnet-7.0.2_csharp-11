using DevFreela.Application.ViewModels.Projects;
using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, GetProjectByIdViewModel>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<GetProjectByIdViewModel> Handle(GetProjectByIdQuery getProjectByIdQuery,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetDetailsByIdAsync(getProjectByIdQuery.Id);

        if (project == null) return null;

        var projectDetailsViewModel = new GetProjectByIdViewModel(
            project.Id,
            project.Title,
            project.Description,
            project.TotalCost,
            project.StartedAt,
            project.FinishedAt,
            project.Client.FullName,
            project.Freelancer.FullName
        );

        return projectDetailsViewModel;
    }
}
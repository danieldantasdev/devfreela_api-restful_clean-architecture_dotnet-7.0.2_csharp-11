using DevFreela.Application.ViewModels.Projects;
using DevFreela.Core.Repositories.Interfaces.Projects;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQueryInputModel, GetProjectByIdQueryViewModel>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<GetProjectByIdQueryViewModel> Handle(GetProjectByIdQueryInputModel getProjectByIdQueryInputModel,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetDetailsByIdAsync(getProjectByIdQueryInputModel.Id);

        if (project == null) return null;

        var projectDetailsViewModel = new GetProjectByIdQueryViewModel(
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
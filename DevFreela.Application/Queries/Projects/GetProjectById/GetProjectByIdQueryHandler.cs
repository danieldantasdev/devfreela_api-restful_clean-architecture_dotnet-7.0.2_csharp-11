using DevFreela.Application.ViewModels.Projects;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.Projects.GetProjectById;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, GetProjectByIdViewModel>
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public GetProjectByIdQueryHandler(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<GetProjectByIdViewModel> Handle(GetProjectByIdQuery getProjectByIdQuery,
        CancellationToken cancellationToken)
    {
        var project = await _devFreelaDbContext.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .SingleOrDefaultAsync(p => p.Id == getProjectByIdQuery.Id);

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
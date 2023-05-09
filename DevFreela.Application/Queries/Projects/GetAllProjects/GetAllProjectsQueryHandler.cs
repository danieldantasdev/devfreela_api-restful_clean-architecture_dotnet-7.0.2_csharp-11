using DevFreela.Application.ViewModels.Projects;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<GetAllProjectsViewModel>>
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public GetAllProjectsQueryHandler(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<List<GetAllProjectsViewModel>> Handle(GetAllProjectsQuery getAllSkillsQuery,
        CancellationToken cancellationToken)
    {
        var projects = _devFreelaDbContext.Projects;

        var getAllProjectViewModel = await projects
            .Select(p => new GetAllProjectsViewModel(p.Id, p.Title, p.CreatedAt))
            .ToListAsync();

        return getAllProjectViewModel;
    }
}
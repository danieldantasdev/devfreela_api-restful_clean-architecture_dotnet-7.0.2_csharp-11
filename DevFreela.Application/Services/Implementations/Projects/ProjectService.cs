using DevFreela.Application.InputModels.Projects;
using DevFreela.Application.Services.Interfaces.Projects;
using DevFreela.Application.ViewModels.Projects;
using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations.Projects;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public ProjectService(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }


    public int Create(CreateProjectInputModel createProjectInputModel)
    {
        var project = new Project(createProjectInputModel.Title, createProjectInputModel.Description,
            createProjectInputModel.IdClient, createProjectInputModel.IdFreelance, createProjectInputModel.TotalCost);
        _devFreelaDbContext.Projects.Add(project);

        return project.Id;
    }

    public void CreateComment(CreateCommentProjectInputModel createCommentProjectInputModel)
    {
        var comment = new ProjectComment(createCommentProjectInputModel.Content,
            createCommentProjectInputModel.IdProject, createCommentProjectInputModel.IdUser);
        _devFreelaDbContext.ProjectComments.Add(comment);
    }

    public List<GetAllProjectViewModel> GetAll(string query)
    {
        var projects = _devFreelaDbContext.Projects;
        var getAllProjectViewModel =
            projects.Select(p => new GetAllProjectViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
        return getAllProjectViewModel;
    }

    public GetByIdProjectViewModel GetById(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id) ?? null;
        var getByIdProjectViewModel = new GetByIdProjectViewModel(
            project.Id, project.Title, project.Description, project.TotalCost, project.StartedAt, project.FinishedAt
        );
        return getByIdProjectViewModel;
    }

    public void Update(UpdateProjectInputModel updateProjectInputModel)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == updateProjectInputModel.Id);
        project.Update(updateProjectInputModel.Title, updateProjectInputModel.Description,
            updateProjectInputModel.TotalCost);
    }

    public void Delete(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project.Cancel();
    }

    public void Start(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project.Start();
    }

    public void Finish(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project.Finish();
    }
}
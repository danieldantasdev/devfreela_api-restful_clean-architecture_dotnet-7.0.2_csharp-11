using Dapper;
using DevFreela.Application.InputModels.Projects;
using DevFreela.Application.Services.Interfaces.Projects;
using DevFreela.Application.ViewModels.Projects;
using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations.Projects;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _devFreelaDbContext;
    private readonly string _connectionString;

    public ProjectService(DevFreelaDbContext devFreelaDbContext, IConfiguration connectionString)
    {
        _devFreelaDbContext = devFreelaDbContext;
        _connectionString = connectionString.GetConnectionString("DevFreelaConnectionString");
    }


    public int Create(CreateProjectInputModel createProjectInputModel)
    {
        var project = new Project(createProjectInputModel.Title, createProjectInputModel.Description,
            createProjectInputModel.IdClient, createProjectInputModel.IdFreelance, createProjectInputModel.TotalCost);
        _devFreelaDbContext.Projects.Add(project);
        _devFreelaDbContext.SaveChanges();

        return project.Id;
    }

    public void CreateComment(CreateCommentProjectInputModel createCommentProjectInputModel)
    {
        var comment = new ProjectComment(createCommentProjectInputModel.Content,
            createCommentProjectInputModel.IdProject, createCommentProjectInputModel.IdUser);
        _devFreelaDbContext.ProjectComments.Add(comment);
        _devFreelaDbContext.SaveChanges();
    }

    public List<GetAllProjectsViewModel> GetAll(string query)
    {
        var projects = _devFreelaDbContext.Projects;
        var getAllProjectViewModel =
            projects.Select(p => new GetAllProjectsViewModel(p.Id, p.Title, p.CreatedAt)).ToList();
        return getAllProjectViewModel;
    }

    public GetProjectByIdViewModel GetById(int id)
    {
        var project = _devFreelaDbContext.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .SingleOrDefault(p => p.Id == id) ?? null;
        var getByIdProjectViewModel = new GetProjectByIdViewModel(
            project.Id, project.Title, project.Description, project.TotalCost, project.StartedAt, project.FinishedAt,
            project.Client.FullName, project.Freelancer.FullName
        );
        return getByIdProjectViewModel;
    }

    public void Update(UpdateProjectInputModel updateProjectInputModel)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == updateProjectInputModel.Id);
        project.Update(updateProjectInputModel.Title, updateProjectInputModel.Description,
            updateProjectInputModel.TotalCost);
        _devFreelaDbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project.Cancel();
        _devFreelaDbContext.SaveChanges();
    }

    public void Start(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project.Start();
        _devFreelaDbContext.SaveChanges();

        // using (var sqlConnection = new SqlConnection(_connectionString))
        // {
        //     sqlConnection.Open(); 
        //     var script = "UPDATE project SET Status = @status, StartedAt = @startedat WHERE Id = @id";
        //     sqlConnection.Execute(script, new { project.Status, project.StartedAt, project.Id });
        // }
    }

    public void Finish(int id)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);
        project.Finish();
        _devFreelaDbContext.SaveChanges();
    }
}
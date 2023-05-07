using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.InputModels.Projects;
using DevFreela.Application.Services.Interfaces.Projects;

namespace DevFreela.API.Controllers.Projects;

[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    // api/projects?query=net core
    [HttpGet]
    public IActionResult Get(string query)
    {
        var projects = _projectService.GetAll(query);

        return Ok(projects);
    }

    // api/projects/2
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _projectService.GetById(id);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectInputModel createProjectInputModel)
    {
        if (createProjectInputModel.Title.Length > 50)
        {
            return BadRequest();
        }

        var id = _projectService.Create(createProjectInputModel);

        return CreatedAtAction(nameof(GetById), new { id = id }, createProjectInputModel);
    }

    // api/projects/2
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
    {
        if (inputModel.Description.Length > 200)
        {
            return BadRequest();
        }

        _projectService.Update(inputModel);

        return NoContent();
    }

    // api/projects/3 DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _projectService.Delete(id);

        return NoContent();
    }

    // api/projects/1/comments POST
    [HttpPost("{id}/comments")]
    public IActionResult PostComment(int id,
        [FromBody] CreateCommentProjectInputModel createCommentProjectInputModel)
    {
        _projectService.CreateComment(createCommentProjectInputModel);

        return NoContent();
    }

    // api/projects/1/start
    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        _projectService.Start(id);

        return NoContent();
    }

    // api/projects/1/finish
    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id)
    {
        _projectService.Finish(id);

        return NoContent();
    }
}
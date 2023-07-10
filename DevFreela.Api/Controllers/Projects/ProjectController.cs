using DevFreela.Application.Commands.Projects.CreateComment;
using DevFreela.Application.Commands.Projects.CreateProject;
using DevFreela.Application.Commands.Projects.DeleteProject;
using DevFreela.Application.Commands.Projects.FinishProject;
using DevFreela.Application.Commands.Projects.StartProject;
using DevFreela.Application.Commands.Projects.UpdateProject;
using DevFreela.Application.Queries.Projects.GetAllProjects;
using DevFreela.Application.Queries.Projects.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers.Projects;

[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT")]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommandInputModel commandInputModel)
    {
        var id = await _mediator.Send(commandInputModel);

        return CreatedAtAction(nameof(GetById), new { id = id }, commandInputModel);
    }

    // api/projects/1/comments POST
    [HttpPost("{id}/comments")]
    [Authorize(Roles = "ADMINISTRATOR, FREELANCER, CLIENT")]
    public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommandInputModel commandInputModel)
    {
        await _mediator.Send(commandInputModel);
        return NoContent();
    }

    // api/projects?query=net core
    [HttpGet("get-all")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT, FREELANCER")]
    public async Task<IActionResult> Get([FromQuery] GetAllProjectsQueryInputModel getAllProjectsQueryInputModel)
    {
        var projects = await _mediator.Send(getAllProjectsQueryInputModel);
        return Ok(projects);
    }

    // api/projects/2
    [HttpGet("get-by-id/{id}")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT, FREELANCER")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetProjectByIdQueryInputModel(id);

        var project = await _mediator.Send(query);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    // api/projects/2
    [HttpPut("update/{id}")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommandInputModel commandInputModel)
    {
        await _mediator.Send(commandInputModel);

        return NoContent();
    }

    // api/projects/1/start
    [HttpPut("{id}/start")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT")]
    public async Task<IActionResult> Start(int id)
    {
        var command = new StartProjectCommandInputModel(id);
        await _mediator.Send(command);

        return NoContent();
    }

    // api/projects/1/finish
    [HttpPut("{id}/finish")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT")]
    public async Task<IActionResult> Finish(int id,
        [FromBody] FinishProjectCommandInputModel finishProjectCommandInputModel)
    {
        finishProjectCommandInputModel.Id = id;
        var result = await _mediator.Send(finishProjectCommandInputModel);

        if (!result.IsFinished)
        {
            return BadRequest("O pagamento não pode ser processado.");
        }

        return Accepted();
    }

    // api/projects/3 DELETE
    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProjectCommandInputModel(id);

        await _mediator.Send(command);

        return NoContent();
    }
}
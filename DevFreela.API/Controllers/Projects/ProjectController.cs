﻿using DevFreela.Application.Commands.Projects.CreateComment;
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

namespace DevFreela.API.Controllers.Projects;

[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT")]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    // api/projects/1/comments POST
    [HttpPost("{id}/comments")]
    [Authorize(Roles = "ADMINISTRATOR, FREELANCER, CLIENT")]
    public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    // api/projects?query=net core
    [HttpGet]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT, FREELANCER")]
    public async Task<IActionResult> Get(string? queryUrl)
    {
        var query = new GetAllProjectsQuery(queryUrl);
        var projects = await _mediator.Send(query);
        return Ok(projects);
    }

    // api/projects/2
    [HttpGet("{id}")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT, FREELANCER")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetProjectByIdQuery(id);

        var project = await _mediator.Send(query);

        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    // api/projects/2
    [HttpPut("{id}")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    // api/projects/1/start
    [HttpPut("{id}/start")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT")]
    public async Task<IActionResult> Start(int id)
    {
        var command = new StartProjectCommand(id);
        await _mediator.Send(command);

        return NoContent();
    }

    // api/projects/1/finish
    [HttpPut("{id}/finish")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT")]
    public async Task<IActionResult> Finish(int id)
    {
        var command = new FinishProjectCommand(id);
        await _mediator.Send(command);

        return NoContent();
    }

    // api/projects/3 DELETE
    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMINISTRATOR, CLIENT")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProjectCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}
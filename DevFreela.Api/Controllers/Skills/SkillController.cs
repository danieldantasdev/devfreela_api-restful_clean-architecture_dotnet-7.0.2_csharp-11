using DevFreela.Application.Queries.Skills.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers.Skills;

[Route("api/skills")]
[Authorize]
public class SkillController : ControllerBase
{
    private readonly IMediator _mediator;

    public SkillController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllSkillsQueryInputModel();
        var skills = await _mediator.Send(query);
        return Ok(skills);
    }
}
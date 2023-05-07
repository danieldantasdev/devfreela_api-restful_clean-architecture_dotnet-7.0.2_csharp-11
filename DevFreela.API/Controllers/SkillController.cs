using DevFreela.Application.Services.Interfaces.Skills;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/skills")]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var skills = _skillService.GetAll();

        return Ok(skills);
    }
}
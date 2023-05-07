using DevFreela.Application.Services.Interfaces.Skills;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

public class SkillController
{
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
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
}
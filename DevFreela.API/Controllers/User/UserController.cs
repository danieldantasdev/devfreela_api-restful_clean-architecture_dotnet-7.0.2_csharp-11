using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/[controller]")]
public class UserController: ControllerBase
{
    [HttpGet]
    [Route("[action]")]
    public IActionResult Get()
    {
        return Ok();
    }
}
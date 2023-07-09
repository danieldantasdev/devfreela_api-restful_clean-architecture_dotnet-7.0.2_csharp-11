using DevFreela.Application.Commands.Users.SignIn;
using DevFreela.Application.Commands.Users.SignUp;
using DevFreela.Application.Queries.Users.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers.Users;

[Route("api/users")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // api/users/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetUserByIdQueryInputModel(id);
        var user = await _mediator.Send(query);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] SignUpUserCommandInputModel commandInputModel)
    {
        var id = await _mediator.Send(commandInputModel);

        return CreatedAtAction(nameof(GetById), new { id = id }, commandInputModel);
    }

    // api/users

    // api/users/1/login
    [HttpPut("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] SignInUserCommandInputModel signInUserCommandInputModel)
    {
        var signInUserViewModel = await _mediator.Send(signInUserCommandInputModel);

        if (signInUserViewModel == null)
        {
            return BadRequest();
        }

        return Ok(signInUserViewModel);
    }
}
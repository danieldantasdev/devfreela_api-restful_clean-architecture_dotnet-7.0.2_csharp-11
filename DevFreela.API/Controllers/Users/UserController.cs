using DevFreela.API.Models.Users;
using DevFreela.Application.Commands.Users.CreateUser;
using DevFreela.Application.Commands.Users.SignInUser;
using DevFreela.Application.Queries.Users.GetUserById;
using DevFreela.Application.ViewModels.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers.Users;

[Route("api/users")]
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
        var query = new GetUserByIdQuery(id);
        var user = await _mediator.Send(query);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    // api/users

    // api/users/1/login
    [HttpPut("login")]
    public async Task<IActionResult> Login([FromBody] SignInUserCommand signInUserCommand)
    {
        var signInUserViewModel = await _mediator.Send(signInUserCommand);

        if (signInUserViewModel == null)
        {
            return BadRequest();
        }

        return Ok(signInUserViewModel);
    }
}
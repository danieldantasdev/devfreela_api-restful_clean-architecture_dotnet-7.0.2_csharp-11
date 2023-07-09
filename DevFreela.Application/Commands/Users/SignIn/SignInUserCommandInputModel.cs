using MediatR;

namespace DevFreela.Application.Commands.Users.SignIn;

public class SignInUserCommandInputModel : IRequest<SignInUserCommandViewModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
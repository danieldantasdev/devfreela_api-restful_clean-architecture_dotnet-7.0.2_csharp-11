using DevFreela.Application.ViewModels.Users;
using MediatR;

namespace DevFreela.Application.Commands.Users.SignInUser;

public class SignInUserCommand : IRequest<SignInUserViewModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
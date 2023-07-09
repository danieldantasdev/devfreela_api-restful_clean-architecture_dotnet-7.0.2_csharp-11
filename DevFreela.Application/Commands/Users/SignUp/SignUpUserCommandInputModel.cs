using DevFreela.Core.Enums.Users;
using MediatR;

namespace DevFreela.Application.Commands.Users.SignUp;

public class SignUpUserCommandInputModel : IRequest<SignUpUserCommandViewModel>
{
    public string FullName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public UserRoleEnum Role { get; set; }
}
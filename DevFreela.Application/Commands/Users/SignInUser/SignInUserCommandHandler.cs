using DevFreela.Application.ViewModels.Users;
using DevFreela.Core.Repositories.Interfaces.Users;
using DevFreela.Core.Services.Interfaces.Auth;
using MediatR;

namespace DevFreela.Application.Commands.Users.SignInUser;

public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, SignInUserViewModel>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public SignInUserCommandHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    public async Task<SignInUserViewModel> Handle(SignInUserCommand signInUserCommand,
        CancellationToken cancellationToken)
    {
        //Utilizar o mesmo algoritmo para criar o Hash da senha
        var passwordHash = _authService.ComputeSha256Hash(signInUserCommand.Password);

        //Buscar no banco um user que tenha e-mail e senha no formato Hash
        var user = await _userRepository.GetUserByEmailAndPasswordHashAsync(signInUserCommand.Email,
            passwordHash);

        //se não existir, erro no login
        if (user == null)
        {
            return null;
        }

        //se existir, gerar token do usuário
        var token = _authService.GenerateJwtToken(user.Email, user.Role.ToString());
        var signInUserViewModel = new SignInUserViewModel(signInUserCommand.Email, token);

        return signInUserViewModel;
    }
}
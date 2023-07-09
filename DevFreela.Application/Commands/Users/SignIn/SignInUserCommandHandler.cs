using DevFreela.Core.Repositories.Interfaces.Users;
using DevFreela.Core.Services.Interfaces.Auth;
using MediatR;

namespace DevFreela.Application.Commands.Users.SignIn;

public class SignInUserCommandHandler : IRequestHandler<SignInUserCommandInputModel, SignInUserCommandViewModel>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public SignInUserCommandHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    public async Task<SignInUserCommandViewModel> Handle(SignInUserCommandInputModel signInUserCommandInputModel,
        CancellationToken cancellationToken)
    {
        //Utilizar o mesmo algoritmo para criar o Hash da senha
        var passwordHash = _authService.ComputeSha256Hash(signInUserCommandInputModel.Password);

        //Buscar no banco um user que tenha e-mail e senha no formato Hash
        var user = await _userRepository.GetUserByEmailAndPasswordHashAsync(signInUserCommandInputModel.Email,
            passwordHash);

        //se não existir, erro no login
        if (user == null)
        {
            return null;
        }

        //se existir, gerar token do usuário
        var token = _authService.GenerateJwtToken(user.Email, user.Role.ToString());
        var signInUserViewModel = new SignInUserCommandViewModel(signInUserCommandInputModel.Email, token);

        return signInUserViewModel;
    }
}
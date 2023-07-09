using DevFreela.Core.Entities.Users;
using DevFreela.Core.Repositories.Interfaces.Users;
using DevFreela.Core.Services.Interfaces.Auth;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;

namespace DevFreela.Application.Commands.Users.SignUp;

public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommandInputModel, SignUpUserCommandViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public SignUpUserCommandHandler(IUserRepository projectRepository, IAuthService authService, DevFreelaDbContext devFreelaDbContext)
    {
        _userRepository = projectRepository;
        _authService = authService;
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<SignUpUserCommandViewModel> Handle(SignUpUserCommandInputModel signUpUserCommandInputModel, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(signUpUserCommandInputModel.Password);
        
        var user = new User(signUpUserCommandInputModel.FullName, signUpUserCommandInputModel.Email, signUpUserCommandInputModel.BirthDate,
            passwordHash, signUpUserCommandInputModel.Role);

        // await _userRepository.AddAsync(user);
        await _devFreelaDbContext.AddAsync(user);
        await _devFreelaDbContext.SaveChangesAsync();

        return new SignUpUserCommandViewModel(user.Id);
    }
}
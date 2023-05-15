using DevFreela.Core.Entities.Users;
using DevFreela.Core.Services.Interfaces.Auth;
using DevFreela.Infrastructure.Persistence.Context;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Users;
using MediatR;

namespace DevFreela.Application.Commands.Users.SignUpUser;

public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, int>
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

    public async Task<int> Handle(SignUpUserCommand signUpUserCommand, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(signUpUserCommand.Password);
        
        var user = new User(signUpUserCommand.FullName, signUpUserCommand.Email, signUpUserCommand.BirthDate,
            passwordHash, signUpUserCommand.Role);

        // await _userRepository.AddAsync(user);
        await _devFreelaDbContext.AddAsync(user);
        await _devFreelaDbContext.SaveChangesAsync();
            
        return user.Id;
    }
}
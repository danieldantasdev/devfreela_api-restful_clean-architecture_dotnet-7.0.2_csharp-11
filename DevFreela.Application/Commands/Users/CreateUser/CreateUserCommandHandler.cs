using DevFreela.Core.Entities.Users;
using DevFreela.Core.Services.Interfaces.Auth;
using DevFreela.Infrastructure.Persistence.Context;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Users;
using MediatR;

namespace DevFreela.Application.Commands.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public CreateUserCommandHandler(IUserRepository projectRepository, IAuthService authService, DevFreelaDbContext devFreelaDbContext)
    {
        _userRepository = projectRepository;
        _authService = authService;
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<int> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(createUserCommand.Password);
        
        var user = new User(createUserCommand.FullName, createUserCommand.Email, createUserCommand.BirthDate,
            passwordHash, createUserCommand.Role);

        // await _userRepository.AddAsync(user);
        await _devFreelaDbContext.AddAsync(user);
        await _devFreelaDbContext.SaveChangesAsync();
            
        return user.Id;
    }
}
using DevFreela.Core.Entities.Users;
using DevFreela.Core.Services.Interfaces.Auth;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Users;
using MediatR;

namespace DevFreela.Application.Commands.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUserRepository projectRepository, IAuthService authService)
    {
        _userRepository = projectRepository;
        _authService = authService;
    }

    public async Task<int> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.computeSha256Hash(createUserCommand.Password);
        
        var user = new User(createUserCommand.FullName, createUserCommand.Email, createUserCommand.BirthDate,
            passwordHash, createUserCommand.Role);

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}
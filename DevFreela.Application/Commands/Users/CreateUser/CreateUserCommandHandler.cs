using DevFreela.Core.Entities.Users;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Projects;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Users;
using MediatR;

namespace DevFreela.Application.Commands.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository projectRepository)
    {
        _userRepository = projectRepository;
    }

    public async Task<int> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        var user = new User(createUserCommand.FullName, createUserCommand.Email, createUserCommand.BirthDate);

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}
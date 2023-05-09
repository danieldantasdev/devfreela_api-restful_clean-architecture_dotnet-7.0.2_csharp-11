using DevFreela.Core.Entities.Users;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;

namespace DevFreela.Application.Commands.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public CreateUserCommandHandler(DevFreelaDbContext dbContext)
    {
        _devFreelaDbContext = dbContext;
    }

    public async Task<int> Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        var user = new User(createUserCommand.FullName, createUserCommand.Email, createUserCommand.BirthDate);

        await _devFreelaDbContext.Users.AddAsync(user);
        await _devFreelaDbContext.SaveChangesAsync();

        return user.Id;
    }
}
using DevFreela.Application.ViewModels.Users;
using DevFreela.Core.Repositories.Interfaces.Users;
using MediatR;

namespace DevFreela.Application.Queries.Users.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdViewModel>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserByIdViewModel> Handle(GetUserByIdQuery getUserByIdQuery,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(getUserByIdQuery.Id);

        if (user == null)
        {
            return null;
        }

        return new GetUserByIdViewModel(user.FullName, user.Email);
    }
}
using DevFreela.Core.Repositories.Interfaces.Users;
using MediatR;

namespace DevFreela.Application.Queries.Users.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryInputModel, GetUserByIdQueryViewModel>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserByIdQueryViewModel> Handle(GetUserByIdQueryInputModel getUserByIdQueryInputModel,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(getUserByIdQueryInputModel.Id);

        if (user == null)
        {
            return null;
        }

        return new GetUserByIdQueryViewModel(user.FullName, user.Email);
    }
}
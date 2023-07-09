using MediatR;

namespace DevFreela.Application.Queries.Users.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryInputModel,List<GetAllUsersQueryViewModel>>
{
    public async Task<List<GetAllUsersQueryViewModel>> Handle(GetAllUsersQueryInputModel request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
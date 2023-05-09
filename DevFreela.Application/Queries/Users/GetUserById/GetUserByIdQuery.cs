using DevFreela.Application.ViewModels.Users;
using MediatR;

namespace DevFreela.Application.Queries.Users.GetUserById;

public class GetUserByIdQuery : IRequest<GetUserByIdViewModel>
{
    public GetUserByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
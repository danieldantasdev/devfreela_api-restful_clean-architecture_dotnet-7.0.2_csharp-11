using MediatR;

namespace DevFreela.Application.Queries.Users.GetUserById;

public class GetUserByIdQueryInputModel : IRequest<GetUserByIdQueryViewModel>
{
    public GetUserByIdQueryInputModel(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
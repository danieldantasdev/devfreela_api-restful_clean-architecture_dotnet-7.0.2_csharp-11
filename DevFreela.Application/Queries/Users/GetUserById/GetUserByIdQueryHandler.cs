using DevFreela.Application.ViewModels.Users;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.Users.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdViewModel>
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public GetUserByIdQueryHandler(DevFreelaDbContext dbContext)
    {
        _devFreelaDbContext = dbContext;
    }

    public async Task<GetUserByIdViewModel> Handle(GetUserByIdQuery getUserByIdQuery,
        CancellationToken cancellationToken)
    {
        var user = await _devFreelaDbContext.Users.SingleOrDefaultAsync(u => u.Id == getUserByIdQuery.Id);

        if (user == null)
        {
            return null;
        }

        return new GetUserByIdViewModel(user.FullName, user.Email);
    }
}
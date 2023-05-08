using DevFreela.Application.InputModels.Users;
using DevFreela.Application.Services.Interfaces.Users;
using DevFreela.Application.ViewModels.Users;
using DevFreela.Core.Entities.Users;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations.Users;

public class UserService : IUserService
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public UserService(DevFreelaDbContext dbContext)
    {
        _devFreelaDbContext = dbContext;
    }
    
    public int Create(CreateUserInputModel createUserInputModel)
    {
        var user = new User(createUserInputModel.FullName, createUserInputModel.Email, createUserInputModel.BirthDate);

        _devFreelaDbContext.Users.Add(user);
        _devFreelaDbContext.SaveChanges();

        return user.Id;
    }

    public GetUserByIdViewModel GetUserById(int id)
    {
        var user = _devFreelaDbContext.Users.SingleOrDefault(u => u.Id == id);

        if (user == null)
        {
            return null;
        }

        return new GetUserByIdViewModel(user.FullName, user.Email);
    }
}
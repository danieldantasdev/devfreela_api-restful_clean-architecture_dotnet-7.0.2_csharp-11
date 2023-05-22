using DevFreela.Core.Entities.Users;
using DevFreela.Core.Repositories.Interfaces.Users;
using DevFreela.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories.Implementations.Users;

public class UserRepository : IUserRepository
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public UserRepository(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _devFreelaDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }


    public Task<User> AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByEmailAndPasswordHashAsync(string email, string passwordHash)
    {
        return await _devFreelaDbContext.Users.SingleOrDefaultAsync(u =>
            u.Email == email && u.Password == passwordHash);
    }
}
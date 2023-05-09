using DevFreela.Core.Entities.Users;

namespace DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Users;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<User> AddAsync(User user);
}
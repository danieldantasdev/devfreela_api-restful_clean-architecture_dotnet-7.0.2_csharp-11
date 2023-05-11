using DevFreela.Core.Entities.Users;

namespace DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Users;

public interface IUserRepository

{
    Task<User> AddAsync(User user);
    Task<User> GetByIdAsync(int id);
    Task<User> GetUserByEmailAndPasswordHashAsync(string email, string passwordHash);
}
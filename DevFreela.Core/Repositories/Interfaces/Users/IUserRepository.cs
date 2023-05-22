using DevFreela.Core.Entities.Users;

namespace DevFreela.Core.Repositories.Interfaces.Users;

public interface IUserRepository

{
    Task<User> AddAsync(User user);
    Task<User> GetByIdAsync(int id);
    Task<User> GetUserByEmailAndPasswordHashAsync(string email, string passwordHash);
}
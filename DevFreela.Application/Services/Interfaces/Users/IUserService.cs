using DevFreela.Application.InputModels.Users;
using DevFreela.Application.ViewModels.Users;

namespace DevFreela.Application.Services.Interfaces.Users;

public interface IUserService
{
    GetUserByIdViewModel GetUserById(int id);
    int Create(CreateUserInputModel createUserInputModel);
}
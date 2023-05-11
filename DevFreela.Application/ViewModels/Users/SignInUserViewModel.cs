namespace DevFreela.Application.ViewModels.Users;

public class SignInUserViewModel
{
    public string Email { get; private set; }
    public string Token { get; private set; }

    public SignInUserViewModel(string email, string token)
    {
        Email = email;
        Token = token;
    }
}
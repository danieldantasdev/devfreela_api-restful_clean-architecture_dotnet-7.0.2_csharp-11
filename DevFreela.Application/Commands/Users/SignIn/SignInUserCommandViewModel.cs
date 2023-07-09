namespace DevFreela.Application.Commands.Users.SignIn;

public class SignInUserCommandViewModel
{
    public string Email { get; private set; }
    public string Token { get; private set; }

    public SignInUserCommandViewModel(string email, string token)
    {
        Email = email;
        Token = token;
    }
}
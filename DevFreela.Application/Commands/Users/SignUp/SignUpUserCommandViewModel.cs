namespace DevFreela.Application.Commands.Users.SignUp;

public class SignUpUserCommandViewModel
{
    public SignUpUserCommandViewModel(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
namespace DevFreela.Application.Commands.Users.SignUpUser;

public class SignUpUserCommandViewModel
{
    public SignUpUserCommandViewModel(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
namespace DevFreela.Application.ViewModels.Users;

public class GetUserByIdViewModel
{
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }

    public GetUserByIdViewModel(int id, string fullName, string email)
    {
        Id = id;
        FullName = fullName;
        Email = email;
    }
}
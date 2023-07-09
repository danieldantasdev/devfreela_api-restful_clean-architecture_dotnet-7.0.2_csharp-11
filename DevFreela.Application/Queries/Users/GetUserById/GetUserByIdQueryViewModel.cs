namespace DevFreela.Application.Queries.Users.GetUserById;

public class GetUserByIdQueryViewModel
{
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }

    public GetUserByIdQueryViewModel(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }
}
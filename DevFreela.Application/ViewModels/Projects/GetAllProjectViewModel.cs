namespace DevFreela.Application.ViewModels.Projects;

public class GetAllProjectViewModel
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public GetAllProjectViewModel(int id, string title, DateTime createdAt)
    {
        Id = id;
        Title = title;
        CreatedAt = createdAt;
    }
}
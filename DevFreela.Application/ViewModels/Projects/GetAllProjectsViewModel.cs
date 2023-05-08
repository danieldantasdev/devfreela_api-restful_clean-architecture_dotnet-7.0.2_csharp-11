namespace DevFreela.Application.ViewModels.Projects;

public class GetAllProjectsViewModel
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public GetAllProjectsViewModel(int id, string title, DateTime createdAt)
    {
        Id = id;
        Title = title;
        CreatedAt = createdAt;
    }
}
namespace DevFreela.Application.ViewModels.Projects;

public class GetAllProjectsQueryViewModel
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public GetAllProjectsQueryViewModel(int id, string title, DateTime createdAt)
    {
        Id = id;
        Title = title;
        CreatedAt = createdAt;
    }
}
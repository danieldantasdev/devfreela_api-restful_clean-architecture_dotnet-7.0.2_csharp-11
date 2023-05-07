namespace DevFreela.Application.ViewModels.Projects;

public class GetAllProjectViewModel
{
    public string Title { get; private set; }
    public DateTime CreatedAt  { get; private set; }

    public GetAllProjectViewModel(string title, DateTime createdAt)
    {
        Title = title;
        CreatedAt = createdAt;
    }
}
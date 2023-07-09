namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectsQueryViewModel
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public GetAllProjectsQueryViewModel(int id, string title,string description, DateTime createdAt)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedAt = createdAt;
    }
}
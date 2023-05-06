using DevFreela.Core.Enums.Projects;

namespace DevFreela.Core.Entities.Projects;

public class Project : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string IdClient { get; private set; }
    public string IdFreelancer { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime FinishedAt { get; private set; }
    public ProjectStatus Status { get; private set; }
    public List<ProjectComments> Comments { get; private set; }
    
    public Project(string title, string description, string idClient, string idFreelancer, decimal totalCost)
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;
        CreatedAt = DateTime.Now;
        Status = ProjectStatus.CREATED;
        Comments = new List<ProjectComments>();
    }
}
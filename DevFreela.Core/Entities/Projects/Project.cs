using DevFreela.Core.Enums.Projects;

namespace DevFreela.Core.Entities.Projects;

public class Project : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int IdClient { get; private set; }
    public int IdFreelancer { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime FinishedAt { get; private set; }
    public ProjectStatusEnum StatusEnum { get; private set; }
    public List<ProjectComment> Comments { get; private set; }

    public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;
        CreatedAt = DateTime.Now;
        StatusEnum = ProjectStatusEnum.CREATED;
        Comments = new List<ProjectComment>();
    }

    public void Cancel()
    {
        if (StatusEnum == ProjectStatusEnum.INPROGRESS || StatusEnum == ProjectStatusEnum.CREATED)
        {
            StatusEnum = ProjectStatusEnum.CANCELLED;
        }
    }

    public void Start()
    {
        if (StatusEnum == ProjectStatusEnum.CREATED)
        {
            StatusEnum = ProjectStatusEnum.INPROGRESS;
            FinishedAt = DateTime.Now;
        }
    }

    public void Finish()
    {
        if (StatusEnum == ProjectStatusEnum.INPROGRESS)
        {
            StatusEnum = ProjectStatusEnum.FINISHED;
            FinishedAt = DateTime.Now;
        }
    }

    public void Update(string title, string description, decimal totalCost)
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}
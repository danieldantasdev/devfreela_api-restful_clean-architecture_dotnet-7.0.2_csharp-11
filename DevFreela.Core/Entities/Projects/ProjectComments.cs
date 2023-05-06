namespace DevFreela.Core.Entities.Projects;

public class ProjectComments : BaseEntity
{
    public ProjectComments(string content, int idProject, int idUser, DateTime createdAt)
    {
        Content = content;
        IdProject = idProject;
        IdUser = idUser;
        CreatedAt = DateTime.Now;
    }

    public string Content { get; private set; }
    public int IdProject { get; private set; }
    public int IdUser { get; private set; }
    public DateTime CreatedAt { get; private set; }
}
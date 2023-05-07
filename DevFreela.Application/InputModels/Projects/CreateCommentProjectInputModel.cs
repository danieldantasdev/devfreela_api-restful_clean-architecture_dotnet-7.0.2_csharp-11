namespace DevFreela.Application.InputModels.Projects;

public class CreateCommentProjectInputModel
{
    public string Content { get; set; }
    public int IdProject { get; set; }
    public int IdUser { get; set; }
}
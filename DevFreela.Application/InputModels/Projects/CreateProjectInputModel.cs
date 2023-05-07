namespace DevFreela.Application.InputModels.Projects;

public class CreateProjectInputModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int IdClient { get; set; }
    public int IdFreelance { get; set; }
    public decimal TotalCost { get; set; }
}
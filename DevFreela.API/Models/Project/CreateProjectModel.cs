namespace DevFreela.API.Models;

public class CreateProjectModel
{
    public int Id { get; set; } = int.MinValue;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateProject;

public class CreateProjectCommand:IRequest<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int IdClient { get; set; }
    public int IdFreelance { get; set; }
    public decimal TotalCost { get; set; }
}
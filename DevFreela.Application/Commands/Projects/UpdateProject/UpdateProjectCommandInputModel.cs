using MediatR;

namespace DevFreela.Application.Commands.Projects.UpdateProject;

public class UpdateProjectCommandInputModel : IRequest<UpdateProjectCommandViewModel>
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal TotalCost { get; private set; }
}
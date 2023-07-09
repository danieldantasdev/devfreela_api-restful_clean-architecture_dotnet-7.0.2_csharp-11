namespace DevFreela.Application.Commands.Projects.CreateProject;

public class CreateProjectCommandViewModel
{
    public CreateProjectCommandViewModel(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
namespace DevFreela.Application.Commands.Projects.FinishProject;

public class FinishProjectCommandViewModel
{
    public FinishProjectCommandViewModel(bool isFinished)
    {
        IsFinished = isFinished;
    }

    public bool IsFinished { get; private set; }
}
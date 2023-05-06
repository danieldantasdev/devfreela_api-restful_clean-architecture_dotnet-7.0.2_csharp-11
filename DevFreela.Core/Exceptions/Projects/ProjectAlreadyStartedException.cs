namespace DevFreela.Core.Exceptions.Projects;

public class ProjectAlreadyStartedException : Exception
{
    public ProjectAlreadyStartedException() : base("Project is already in Started Status!")
    {
    }
}
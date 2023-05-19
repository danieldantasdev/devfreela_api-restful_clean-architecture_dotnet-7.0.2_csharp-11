using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Enums.Projects;

namespace DevFreela.UnitTests.Core.Entities.Projects;

public class ProjectTest
{
    [Fact]
    public void TestIfProjectStartWorks()
    {
        var project = new Project("Projeto 1", "Descrição 1", 1, 1, 10);
        
        Assert.Equal(ProjectStatusEnum.CREATED, project.Status);
        Assert.Null(project.StartedAt);
        
        Assert.NotEmpty(project.Title);
        Assert.NotNull(project.Title);
        
        Assert.NotEmpty(project.Description);
        Assert.NotNull(project.Description);
        
        project.Start();

        Assert.Equal(ProjectStatusEnum.INPROGRESS, project.Status);
        Assert.NotNull(project.StartedAt);
    }
}
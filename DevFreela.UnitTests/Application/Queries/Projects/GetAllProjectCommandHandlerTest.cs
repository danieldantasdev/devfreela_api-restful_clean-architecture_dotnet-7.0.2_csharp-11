using DevFreela.Application.Queries.Projects.GetAllProjects;
using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Repositories.Interfaces.Projects;
using Moq;

namespace DevFreela.UnitTests.Application.Queries.Projects;

public class GetAllProjectCommandHandlerTest
{
    [Fact]
    //Given_When_Then
    public async Task ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
    {
        //Arrange
        var projects = new List<Project>
        {
            new Project("Projeto 1", "Descrição 1", 1, 1, 10),
            new Project("Projeto 2", "Descrição 2", 2, 2, 20),
            new Project("Projeto 3", "Descrição 3", 3, 3, 30)
        };

        var projectRepositoryMock = new Mock<IProjectRepository>();
        projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

        var getAllProjectsQuery = new GetAllProjectsQueryInputModel("");
        var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

        //Act
        var projectViewModelList =
            await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

        //Assert
        Assert.NotNull(projectViewModelList);
        Assert.NotEmpty(projectViewModelList);
        Assert.Equal(projects.Count, projectViewModelList.Count);

        projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
    }
}
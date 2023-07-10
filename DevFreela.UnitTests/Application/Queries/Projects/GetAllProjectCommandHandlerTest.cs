using DevFreela.Application.Queries.Projects.GetAllProjects;
using DevFreela.Core.Dtos.Paginations;
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
        var projects = new PaginationResultDto<Project>
        {
            Data = new List<Project>
            {
                new Project("Projeto 1", "Descrição 1", 1, 1, 10),
                new Project("Projeto 2", "Descrição 2", 2, 2, 20),
                new Project("Projeto 3", "Descrição 3", 3, 3, 30)
            }
        };

        var projectRepositoryMock = new Mock<IProjectRepository>();
        projectRepositoryMock.Setup(pr => pr.GetAllAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()).Result)
            .Returns(projects);

        var getAllProjectsQuery = new GetAllProjectsQueryInputModel { Query = "", Page = 1, PageSize = 10 };
        var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

        //Act
        var paginationProjectViewModelList =
            await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

        //Assert
        Assert.NotNull(paginationProjectViewModelList);
        Assert.NotEmpty(paginationProjectViewModelList.Data);
        Assert.Equal(projects.Data.Count, paginationProjectViewModelList.Data.Count);

        projectRepositoryMock.Verify(pr => pr.GetAllAsync(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()).Result,
            Times.Once);
    }
}
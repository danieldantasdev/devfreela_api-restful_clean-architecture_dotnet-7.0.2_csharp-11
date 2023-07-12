using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Services.Interfaces.UnitOfWorks;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommandInputModel, CreateProjectCommandViewModel>
{
    private readonly IUnitOfWorkService _unitOfWorkService;

    public CreateProjectCommandHandler(IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
    }

    public async Task<CreateProjectCommandViewModel> Handle(CreateProjectCommandInputModel createProjectCommandInputModel, CancellationToken cancellationToken)
    {
        var project = new Project(createProjectCommandInputModel.Title, createProjectCommandInputModel.Description, createProjectCommandInputModel.IdClient, createProjectCommandInputModel.IdFreelancer, createProjectCommandInputModel.TotalCost);

        await _unitOfWorkService.ProjectRepository.AddAsync(project);
        await _unitOfWorkService.CompleteAsync();

        return new CreateProjectCommandViewModel(project.Id);
    }
}
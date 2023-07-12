using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Services.Interfaces.UnitOfWorks;
using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateProject;

public class
    CreateProjectCommandHandler : IRequestHandler<CreateProjectCommandInputModel, CreateProjectCommandViewModel>
{
    private readonly IUnitOfWorkService _unitOfWorkService;

    public CreateProjectCommandHandler(IUnitOfWorkService unitOfWorkService)
    {
        _unitOfWorkService = unitOfWorkService;
    }

    public async Task<CreateProjectCommandViewModel> Handle(CreateProjectCommandInputModel request,
        CancellationToken cancellationToken)
    {
        var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer,
            request.TotalCost);
        project.Comments.Add(new ProjectComment("Project was created.", project.Id, request.IdClient));

        await _unitOfWorkService.BeginTransactionAsync();

        await _unitOfWorkService.ProjectRepository.AddAsync(project);

        await _unitOfWorkService.CompleteTransactionAsync();

        await _unitOfWorkService.SkillRepository.AddSkillFromProject(project);

        await _unitOfWorkService.CompleteTransactionAsync();

        await _unitOfWorkService.CommmitTransactionAsync();

        return new CreateProjectCommandViewModel(project.Id);
    }
}
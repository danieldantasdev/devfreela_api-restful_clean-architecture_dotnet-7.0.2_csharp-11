using DevFreela.Core.Dtos.Projects;
using DevFreela.Core.Repositories.Interfaces.Projects;
using DevFreela.Core.Services.Interfaces.Payments;
using MediatR;

namespace DevFreela.Application.Commands.Projects.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, bool>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IPaymentService _paymentService;

    public FinishProjectCommandHandler(IProjectRepository projectRepository, IPaymentService paymentService)
    {
        _projectRepository = projectRepository;
        _paymentService = paymentService;
    }


    public async Task<bool> Handle(FinishProjectCommand finishProjectCommand, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(finishProjectCommand.Id);

        project.Finish();

        var paymentInfoDto = new PaymentInfoDto(finishProjectCommand.Id, finishProjectCommand.CreditCardNumber,
            finishProjectCommand.Cvv, finishProjectCommand.ExpiresAt, finishProjectCommand.FullName);

        _paymentService.ProcessPayment(paymentInfoDto);

        project.SetPaymentPending();

        await _projectRepository.SaveChangesAsync();

        return true;
    }
}
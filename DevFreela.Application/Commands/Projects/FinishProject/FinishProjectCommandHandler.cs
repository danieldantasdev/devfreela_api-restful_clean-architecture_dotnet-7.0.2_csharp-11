using DevFreela.Core.Dtos.Projects;
using DevFreela.Core.Repositories.Interfaces.Projects;
using DevFreela.Core.Services.Interfaces.Payments;
using MediatR;

namespace DevFreela.Application.Commands.Projects.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommandInputModel, FinishProjectCommandViewModel>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IPaymentService _paymentService;

    public FinishProjectCommandHandler(IProjectRepository projectRepository, IPaymentService paymentService)
    {
        _projectRepository = projectRepository;
        _paymentService = paymentService;
    }


    public async Task<FinishProjectCommandViewModel> Handle(FinishProjectCommandInputModel finishProjectCommandInputModel, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(finishProjectCommandInputModel.Id);

        var paymentInfoDto = new PaymentInfoDto(finishProjectCommandInputModel.Id, finishProjectCommandInputModel.CreditCardNumber,
            finishProjectCommandInputModel.Cvv, finishProjectCommandInputModel.ExpiresAt, finishProjectCommandInputModel.FullName);

        _paymentService.ProcessPayment(paymentInfoDto);

        project.SetPaymentPending();

        await _projectRepository.SaveChangesAsync();

        return new FinishProjectCommandViewModel(true);
    }
}
using DevFreela.Core.Dtos.Projects;

namespace DevFreela.Core.Services.Interfaces.Payments;

public interface IPaymentService
{
    void ProcessPayment(PaymentInfoDto paymentInfoDto);
}
using System.Text;
using System.Text.Json;
using DevFreela.Core.Dtos.Projects;
using DevFreela.Core.Services.Interfaces.MessageBus;
using DevFreela.Core.Services.Interfaces.Payments;

namespace DevFreela.Infrastructure.Services.Implementations.Payments;

public class PaymentService : IPaymentService
{
    private readonly IMessageBusService _messageBusService;
    private const string QUEUE_NAME = "Payments";

    public PaymentService(IMessageBusService messageBusService)
    {
        _messageBusService = messageBusService;
    }

    public async void ProcessPayment(PaymentInfoDto paymentInfoDto)
    {
        var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);

        var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

        _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
    }
}
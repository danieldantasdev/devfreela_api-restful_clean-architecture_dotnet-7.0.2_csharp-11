namespace DevFreela.Core.Services.Interfaces.MessageBus;

public interface IMessageBusService
{
    void Publish(string queue, byte[] message);
}
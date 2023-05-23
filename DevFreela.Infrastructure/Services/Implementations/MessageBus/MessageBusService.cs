using DevFreela.Core.Services.Interfaces.MessageBus;
using RabbitMQ.Client;

namespace DevFreela.Infrastructure.Services.Implementations.MessageBus;

public class MessageBusService : IMessageBusService
{
    private readonly ConnectionFactory _factory;

    public MessageBusService()
    {
        _factory = new ConnectionFactory
        {
            HostName = "localhost"
        };
    }

    public void Publish(string queue, byte[] message)
    {
        using (var connection = _factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                //Garantir que a fila esteja criada
                channel.QueueDeclare(
                    queue: queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                //Publicar a mensagem
                channel.BasicPublish(
                    exchange: "",
                    routingKey: queue,
                    basicProperties: null,
                    body: message);
            }
        }
    }
}
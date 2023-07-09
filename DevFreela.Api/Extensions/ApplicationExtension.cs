using DevFreela.Application.Commands.Projects.CreateProject;
using DevFreela.Application.Consumers;
using DevFreela.Application.Validators.Users;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace DevFreela.Api.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationExtension(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddConsumersExtension()
            .AddFluentValidationExtension()
            .AddMediatRExtension();
    }
    
    private static IServiceCollection AddConsumersExtension(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHostedService<PaymentApprovedConsumer>();
        return serviceCollection;
    }

    private static IServiceCollection AddFluentValidationExtension(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddFluentValidationAutoValidation();
        serviceCollection.AddFluentValidationClientsideAdapters();
        serviceCollection.AddValidatorsFromAssemblyContaining<SignUpUserCommandValidator>();
        return serviceCollection;
    }

    private static IServiceCollection AddMediatRExtension(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly,
                typeof(CreateProjectCommandInputModel).Assembly);
        });
        return serviceCollection;
    }
}
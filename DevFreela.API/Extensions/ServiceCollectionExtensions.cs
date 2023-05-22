using DevFreela.Core.Repositories.Interfaces.Projects;
using DevFreela.Core.Repositories.Interfaces.Skills;
using DevFreela.Core.Repositories.Interfaces.Users;
using DevFreela.Core.Services.Interfaces.Auth;
using DevFreela.Core.Services.Interfaces.MessageBus;
using DevFreela.Core.Services.Interfaces.Payments;
using DevFreela.Infrastructure.Persistence.Repositories.Implementations.Projects;
using DevFreela.Infrastructure.Persistence.Repositories.Implementations.Skills;
using DevFreela.Infrastructure.Persistence.Repositories.Implementations.Users;
using DevFreela.Infrastructure.Services.Implementations.Auth;
using DevFreela.Infrastructure.Services.Implementations.MessageBus;
using DevFreela.Infrastructure.Services.Implementations.Payments;

namespace DevFreela.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IMessageBusService, MessageBusService>();

        return services;
    }
}
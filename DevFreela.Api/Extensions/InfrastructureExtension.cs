using System.Text;
using DevFreela.Core.Repositories.Interfaces.Projects;
using DevFreela.Core.Repositories.Interfaces.Skills;
using DevFreela.Core.Repositories.Interfaces.Users;
using DevFreela.Core.Services.Interfaces.Auth;
using DevFreela.Core.Services.Interfaces.MessageBus;
using DevFreela.Core.Services.Interfaces.Payments;
using DevFreela.Core.Services.Interfaces.UnitOfWorks;
using DevFreela.Infrastructure.Persistence.Context;
using DevFreela.Infrastructure.Persistence.Repositories.Implementations.Projects;
using DevFreela.Infrastructure.Persistence.Repositories.Implementations.Skills;
using DevFreela.Infrastructure.Persistence.Repositories.Implementations.Users;
using DevFreela.Infrastructure.Services.Implementations.Auth;
using DevFreela.Infrastructure.Services.Implementations.MessageBus;
using DevFreela.Infrastructure.Services.Implementations.Payments;
using DevFreela.Infrastructure.Services.Implementations.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DevFreela.Api.Extensions;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructureExtension(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection
            .AddServicesExtension()
            .AddRepositoriesExtension()
            .AddDatabaseExtension(configuration)
            .AddHttpClientExtension()
            .AddAuthenticationExtension(configuration);
    }

    private static IServiceCollection AddServicesExtension(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IPaymentService, PaymentService>();
        serviceCollection.AddScoped<IMessageBusService, MessageBusService>();
        serviceCollection.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
        return serviceCollection;
    }

    private static IServiceCollection AddRepositoriesExtension(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProjectRepository, ProjectRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<ISkillRepository, SkillRepository>();
        return serviceCollection;
    }

    private static IServiceCollection AddDatabaseExtension(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DevFreelaConnectionString");
        serviceCollection.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));
        // services.AddDbContext<DevFreelaDbContext>(options => options.UseInMemoryDatabase("DevFreelaDb"));
        return serviceCollection;
    }

    private static IServiceCollection AddHttpClientExtension(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddHttpClient();
    }

    private static IServiceCollection AddAuthenticationExtension(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? string.Empty))
                };
            });
        return serviceCollection;
    }
}
using DevFreela.Api.Filters;
using Microsoft.OpenApi.Models;

namespace DevFreela.Api.Extensions;

public static class ApiExtension
{
    public static IServiceCollection AddApiExtension(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddControllersExtension()
            .AddSwaggerExtension();
    }

    private static IServiceCollection AddSwaggerExtension(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.Api", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header usando o esquema Bearer."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
        return serviceCollection;
    }

    private static IServiceCollection AddControllersExtension(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddControllers(options => options.Filters.Add<ValidatorFilter>());
        return serviceCollection;
    }
}
using DevFreela.API.Models;
using DevFreela.Application.Commands.Projects.CreateProject;
using DevFreela.Infrastructure.Persistence.Context;
using DevFreela.Infrastructure.Persistence.Repositories.Implementations.Projects;
using DevFreela.Infrastructure.Persistence.Repositories.Implementations.Skills;
using DevFreela.Infrastructure.Persistence.Repositories.Implementations.Users;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Projects;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Skills;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.API", Version = "v1" });
});

builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

var connectionString = builder.Configuration.GetConnectionString("DevFreelaConnectionString");
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

builder.Services.AddMediatR(typeof(CreateProjectCommand));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
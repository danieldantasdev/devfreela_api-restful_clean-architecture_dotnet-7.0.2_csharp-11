using DevFreela.API.Models;
using DevFreela.Application.Services.Implementations.Projects;
using DevFreela.Application.Services.Implementations.Skills;
using DevFreela.Application.Services.Implementations.Users;
using DevFreela.Application.Services.Interfaces.Projects;
using DevFreela.Application.Services.Interfaces.Skills;
using DevFreela.Application.Services.Interfaces.Users;
using DevFreela.Infrastructure.Persistence;
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

builder.Services.AddSingleton<DevFreelaDbContext>();

builder.Services.AddScoped<ExampleClass>(e => new ExampleClass { Name = "Initial Stage" });
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISkillService, SkillService>();

builder.Services.AddControllers();

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
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Commands.Projects.StartProject;

public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _devFreelaDbContext;
    // private readonly string? _connectionString;

    public StartProjectCommandHandler(DevFreelaDbContext devFreelaDbContext, IConfiguration configuration)
    {
        _devFreelaDbContext = devFreelaDbContext;
        // _connectionString = configuration.GetConnectionString("DevFreelaConnectionString");
    }

    public async Task<Unit> Handle(StartProjectCommand startProjectCommand, CancellationToken cancellationToken)
    {
        var project = _devFreelaDbContext.Projects.SingleOrDefault(p => p.Id == startProjectCommand.Id);
        project?.Start();
        await _devFreelaDbContext.SaveChangesAsync();

        return Unit.Value;

        // using (var sqlConnection = new SqlConnection(_connectionString))
        // {
        //     sqlConnection.Open();
        //
        //     var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE Id = @id";
        //
        //     sqlConnection.Execute(script, new { status = project.Status, startedat = project.StartedAt, request.Id });
        // }
    }
}
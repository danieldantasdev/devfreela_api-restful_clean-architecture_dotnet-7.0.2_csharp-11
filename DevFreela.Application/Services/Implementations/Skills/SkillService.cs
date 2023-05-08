using Dapper;
using DevFreela.Application.Services.Interfaces.Skills;
using DevFreela.Application.ViewModels.Skills;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations.Skills;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _devFreelaDbContext;
    private readonly string _connectionString;

    public SkillService(DevFreelaDbContext devFreelaDbContext, IConfiguration connectionString)
    {
        _devFreelaDbContext = devFreelaDbContext;
        _connectionString = connectionString.GetConnectionString("DevFreelaConnectionString");
    }

    public List<GetAllSkillsViewModel> GetAll()
    {
        var skills = _devFreelaDbContext.Skills;
        var getAllSkillsViewModel = skills.Select(s => new GetAllSkillsViewModel(s.Id, s.Description)).ToList();
        return getAllSkillsViewModel;
        // using (var sqlConnection = new SqlConnection(_connectionString))
        // {
        //     sqlConnection.Open();
        //     var script = "SELECT Id, Description FROM skill";
        //     return sqlConnection.Query<GetAllSkillsViewModel>(script).ToList();
        // }
    }
}
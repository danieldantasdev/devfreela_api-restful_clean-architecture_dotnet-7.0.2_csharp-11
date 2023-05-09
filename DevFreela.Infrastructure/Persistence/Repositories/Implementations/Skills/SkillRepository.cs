using Dapper;
using DevFreela.Core.DTOs.Skills;
using DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Skills;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories.Implementations.Skills;

public class SkillRepository : ISkillRepository
{
    private readonly string? _connectionString;

    public SkillRepository(IConfiguration connectionString)
    {
        _connectionString = connectionString.GetConnectionString("DevFreelaConnectionString");
    }

    public async Task<List<SkillDto>> GetAllAsync()
    {
        await using var sqlConnection = new SqlConnection(_connectionString);
        sqlConnection.Open();

        var script = "SELECT Id, Description FROM Skills";

        var skills = await sqlConnection.QueryAsync<SkillDto>(script);

        return skills.ToList();

        // COM EF CORE
        //var skills = _dbContext.Skills;

        //var skillsViewModel = skills
        //    .Select(s => new SkillViewModel(s.Id, s.Description))
        //    .ToList();

        //return skillsViewModel;
    }
}
using Dapper;
using DevFreela.Core.Dtos.Skills;
using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Entities.Skills;
using DevFreela.Core.Repositories.Interfaces.Skills;
using DevFreela.Infrastructure.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories.Implementations.Skills;

public class SkillRepository : ISkillRepository
{
    private readonly string? _connectionString;
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public SkillRepository(IConfiguration connectionString, DevFreelaDbContext devFreelaDbContext)
    {
        _connectionString = connectionString.GetConnectionString("DevFreelaConnectionString");
        _devFreelaDbContext = devFreelaDbContext;
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
    
    public async Task AddSkillFromProject(Project project)
    {
        // App Xamarin de Marketplace
        var words = project.Description.Split(' ');
        var length = words.Length;

        var skill = $"{project.Id} - {words[length - 1]}";
        // "1 - Marketplace"
            
        await _devFreelaDbContext.Skills.AddAsync(new Skill(skill));
    }
}
using DevFreela.Application.ViewModels.Skills;
using DevFreela.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Queries.Skills.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<GetAllSkillsViewModel>>
{
    private readonly DevFreelaDbContext _devFreelaDbContext;
    // private readonly string _connectionString;

    public GetAllSkillsQueryHandler(DevFreelaDbContext devFreelaDbContext, IConfiguration connectionString)
    {
        _devFreelaDbContext = devFreelaDbContext;
        // _connectionString = connectionString.GetConnectionString("DevFreelaConnectionString");
    }

    public async Task<List<GetAllSkillsViewModel>> Handle(GetAllSkillsQuery getAllSkillsQuery,
        CancellationToken cancellationToken)
    {
        var skills = _devFreelaDbContext.Skills;
        var getAllSkillsViewModel = await skills
            .Select(s => new GetAllSkillsViewModel(s.Id, s.Description))
            .ToListAsync();

        return getAllSkillsViewModel;

        // using (var sqlConnection = new SqlConnection(_connectionString))
        // {
        //     sqlConnection.Open();
        //
        //     var script = "SELECT Id, Description FROM Skills";
        //
        //     var skills = await sqlConnection.QueryAsync<SkillViewModel>(script);
        //
        //     return skills.ToList();
        // }
    }
}
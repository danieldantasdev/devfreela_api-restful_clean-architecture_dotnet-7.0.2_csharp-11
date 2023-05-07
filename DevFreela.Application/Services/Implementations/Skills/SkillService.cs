using DevFreela.Application.Services.Interfaces.Skills;
using DevFreela.Application.ViewModels.Skills;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Application.Services.Implementations.Skills;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _devFreelaDbContext;

    public SkillService(DevFreelaDbContext devFreelaDbContext)
    {
        _devFreelaDbContext = devFreelaDbContext;
    }

    public List<GetAllSkillsViewModel> GetAll()
    {
        var skills = _devFreelaDbContext.Skills;
        var getAllSkillsViewModel = skills.Select(s => new GetAllSkillsViewModel(s.Id, s.Description)).ToList();
        return getAllSkillsViewModel;
    }
}
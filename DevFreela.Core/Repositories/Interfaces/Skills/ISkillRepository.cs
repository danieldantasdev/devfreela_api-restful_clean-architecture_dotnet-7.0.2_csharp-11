using DevFreela.Core.Dtos.Skills;

namespace DevFreela.Core.Repositories.Interfaces.Skills;

public interface ISkillRepository
{
    Task<List<SkillDto>> GetAllAsync();
}
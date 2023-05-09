using DevFreela.Core.DTOs.Skills;

namespace DevFreela.Infrastructure.Persistence.Repositories.Interfaces.Skills;

public interface ISkillRepository
{
    Task<List<SkillDto>> GetAllAsync();
}
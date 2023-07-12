using DevFreela.Core.Dtos.Skills;
using DevFreela.Core.Entities.Projects;

namespace DevFreela.Core.Repositories.Interfaces.Skills;

public interface ISkillRepository
{
    Task<List<SkillDto>> GetAllAsync();
    Task AddSkillFromProject(Project project); 
}
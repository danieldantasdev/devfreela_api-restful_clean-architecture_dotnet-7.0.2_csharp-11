using DevFreela.Application.ViewModels.Skills;

namespace DevFreela.Application.Services.Interfaces.Skills;

public interface ISkillService
{
    List<GetAllSkillsViewModel> GetAll();
}
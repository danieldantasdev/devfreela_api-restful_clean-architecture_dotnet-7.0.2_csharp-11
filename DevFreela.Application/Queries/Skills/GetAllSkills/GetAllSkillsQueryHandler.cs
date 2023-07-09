using DevFreela.Core.Dtos.Skills;
using DevFreela.Core.Repositories.Interfaces.Skills;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQueryInputModel, List<SkillDto>>
{
    private readonly ISkillRepository _skillRepository;
    public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<List<SkillDto>> Handle(GetAllSkillsQueryInputModel getAllSkillsQueryInputModel,
        CancellationToken cancellationToken)
    {
        return await _skillRepository.GetAllAsync();
    }
}
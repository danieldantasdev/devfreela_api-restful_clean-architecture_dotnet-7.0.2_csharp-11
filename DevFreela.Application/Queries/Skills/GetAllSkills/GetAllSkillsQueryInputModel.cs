using DevFreela.Core.Dtos.Skills;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetAllSkills;

public class GetAllSkillsQueryInputModel : IRequest<List<SkillDto>>
{
}
using DevFreela.Core.Dtos.Skills;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetAllSkills;

public class GetAllSkillsQuery : IRequest<List<SkillDto>>
{
}
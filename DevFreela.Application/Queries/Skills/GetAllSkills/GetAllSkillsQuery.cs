using DevFreela.Core.DTOs.Skills;
using MediatR;

namespace DevFreela.Application.Queries.Skills.GetAllSkills;

public class GetAllSkillsQuery : IRequest<List<SkillDto>>
{
}
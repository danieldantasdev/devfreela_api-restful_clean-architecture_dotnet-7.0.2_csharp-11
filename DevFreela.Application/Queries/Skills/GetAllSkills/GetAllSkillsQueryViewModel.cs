namespace DevFreela.Application.Queries.Skills.GetAllSkills;

public class GetAllSkillsQueryViewModel
{
    public int Id { get; private set; }
    public string Description { get; private set; }

    public GetAllSkillsQueryViewModel(int id, string description)
    {
        Id = id;
        Description = description;
    }
}
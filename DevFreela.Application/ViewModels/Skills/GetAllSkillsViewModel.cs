namespace DevFreela.Application.ViewModels.Skills;

public class GetAllSkillsViewModel
{
    public int Id { get; private set; }
    public string Description { get; private set; }

    public GetAllSkillsViewModel(int id, string description)
    {
        Id = id;
        Description = description;
    }
}
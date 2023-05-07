using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Entities.Skills;
using DevFreela.Core.Enums.Users;

namespace DevFreela.Core.Entities.Users;

public class User : BaseEntity
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public UserStatusEnum StatusEnum { get; private set;  }
    public List<UserSkill> Skills { get; private set; }
    public List<Project> OwnedProjects { get; private set; }
    public List<Project> FreelanceProjects { get; private set; }
    public List<ProjectComment> Comments { get; private set; }

    public User(string fullName, string email, DateTime birthDate)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        CreatedAt = DateTime.Now;
        StatusEnum = UserStatusEnum.ACTIVE;
        Skills = new List<UserSkill>();
        OwnedProjects = new List<Project>();
        FreelanceProjects = new List<Project>();
    }
}
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
    public UserStatusEnum Status { get; private set; }
    public UserRoleEnum Role { get; private set; }
    public string Password { get; private set; }
    public List<SkillUser> Skills { get; private set; }
    public List<Project> OwnedProjects { get; private set; }
    public List<Project> FreelanceProjects { get; private set; }
    public List<ProjectComment> Comments { get; private set; }

    public User(string fullName, string email, DateTime birthDate, string password, UserRoleEnum role)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        CreatedAt = DateTime.Now;
        Status = UserStatusEnum.ACTIVE;
        Skills = new List<SkillUser>();
        OwnedProjects = new List<Project>();
        FreelanceProjects = new List<Project>();
        Password = password;
        Role = role;
    }
}
using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Entities.Skills;
using DevFreela.Core.Entities.Users;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext
{
    public List<Project> Projects { get; private set; }
    public List<User> Users { get; private set; }
    public List<Skill> Skills { get; private set; }
    public List<ProjectComments> ProjectComments { get; private set; }

    public DevFreelaDbContext()
    {
        Projects = new List<Project>
        {
            new Project("Meu projeto ASPNET Core 1", "Minha descrição de projeto 1", 1, 1, 10000),
            new Project("Meu projeto ASPNET Core 2", "Minha descrição de projeto 2", 1, 1, 20000),
            new Project("Meu projeto ASPNET Core 3", "Minha descrição de projeto 3", 1, 1, 30000)
        };
        Users = new List<User>
        {
            new User("Daniel Abreu Dantas", "contatodanieldantasdev@gmail.com", new DateTime(2001, 03, 13)),
            new User("Evellin Cristine Sá de Oliveira", "evellin@gmail.com", new DateTime(1999, 06, 13)),
            new User("Luís Felipe", "luisdev@gmail.com", new DateTime(1992, 1, 1))
        };
        Skills = new List<Skill>
        {
            new Skill(".NET Core"),
            new Skill("C#"),
            new Skill("Angular"),
        };
    }
}
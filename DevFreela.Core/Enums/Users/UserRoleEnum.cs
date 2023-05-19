using System.ComponentModel;

namespace DevFreela.Core.Enums.Users;

public enum UserRoleEnum
{
    [Description("ADMINISTRATOR")]
    ADMINISTRATOR = 0,
    [Description("CLIENT")]
    CLIENT = 1,
    [Description("FREELANCER")]
    FREELANCER = 2
}
namespace DevFreela.Core.Services.Interfaces.Auth;

public interface IAuthService
{
    string GenerateJwtToken(string email, string role);
    string computeSha256Hash(string password);
}
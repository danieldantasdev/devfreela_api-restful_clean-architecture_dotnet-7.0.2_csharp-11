namespace DevFreela.Core.Services;

public interface IAuthService
{
    string GenerateJwtToken(string email, string role);
    string computeSha256Hash(string password);
}
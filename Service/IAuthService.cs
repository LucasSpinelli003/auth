using AuthApi.Models;

namespace AuthApi.Services
{
    public interface IAuthService
    {
        Task<Auth> CreateAuthAsync(Auth auth);
        Task<string> GenerateTokenAsync(string login, string password);
    }
}

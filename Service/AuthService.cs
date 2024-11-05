using AuthApi.Models;
using AuthApi.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _context;

        public AuthService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<Auth> CreateAuthAsync(Auth auth)
        {
            _context.Auths.Add(auth);
            await _context.SaveChangesAsync();
            return auth;
        }

        public async Task<string> GenerateTokenAsync(string login, string password)
        {
            var auth = await _context.Auths
                .FirstOrDefaultAsync(a => a.Login == login && a.Password == password);

            if (auth == null) return null;

            // Gerando um token aleatório
            using var rng = new RNGCryptoServiceProvider();
            var tokenData = new byte[32];
            rng.GetBytes(tokenData);
            return Convert.ToBase64String(tokenData);
        }
    }
}

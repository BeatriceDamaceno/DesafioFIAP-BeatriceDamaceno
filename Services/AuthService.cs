using Desafio_FIAP___Beatrice_Damaceno.Models;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;

namespace Desafio_FIAP___Beatrice_Damaceno.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthService(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<(bool Success, string Token, Admin Admin)> LoginAsync(string login, string password)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Login == login);

            if (admin == null || !VerifyPassword(password, admin.Senha))
            {
                return (false, null, null);
            }

            var token = _jwtService.GenerateToken(admin);
            return (true, token, admin);
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            var inputHash = HashPassword(inputPassword);
            return inputHash == storedHash;
        }
    }
}

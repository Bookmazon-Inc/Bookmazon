using Bookmazon.Server.Data;
using Bookmazon.Shared;
using Bookmazon.Shared.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Bookmazon.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DBContext _context;

        public UserController(ILogger<WeatherForecastController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("registeruser")]
        public async Task<ActionResult> RegisterUser(User user)
        {
            try
            {
                var emailExists = _context.Users.Where(e => e.Email == user.Email).FirstOrDefault();
                var userNameExists = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
                if (emailExists == null && userNameExists == null)
                {
                    user.Salt = GenerateSalt();
                    user.Password = PasswordHash(user.Salt, user.Password);
                    _context.Users.Add(user);
                    Commit(_context);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            return Ok();
        }


        public string GenerateSalt()
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                var salt = new byte[24];
                generator.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        public string PasswordHash(string salt, string password)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 56));
            return hashedPassword;
        }

        public void Commit(DBContext context)
        {
            context.SaveChangesAsync();
        }

    }
}
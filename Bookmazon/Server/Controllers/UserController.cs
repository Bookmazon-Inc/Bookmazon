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

        private readonly ILogger<UserController> _logger;
        private readonly DBContext _context;

        public UserController(ILogger<UserController> logger, DBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("registeruser")]
        public async Task<ActionResult> RegisterUser(User user)
        {
            var emailExists = _context.Users.Where(e => e.Email == user.Email).FirstOrDefault();
            var userNameExists = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
            if (emailExists == null && userNameExists == null)
            {
                user.Salt = GenerateSalt();
                user.Password = PasswordHash(user.Salt, user.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPost("loginuser")]
        public async Task<ActionResult> LoginUser(User user)
        {
            var userExists = _context.Users.Where(u => u.UserName == user.UserName || u.Email == user.Email).FirstOrDefault();
            if(userExists != null)
            {
                var password = PasswordHash(userExists.Salt, user.Password);

                if(password == userExists.Password)
                {

                }
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

    }
}